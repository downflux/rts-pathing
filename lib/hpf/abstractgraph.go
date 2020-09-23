// Package abstractgraph constructs and manages the abstract node space corresponding to a tile.Map object.
// This package will be used ast he underlying topology for hiearchical A* searching.
package abstractgraph

import (
	"math"

	rtscpb "github.com/minkezhang/rts-pathing/lib/proto/constants_go_proto"
	rtsspb "github.com/minkezhang/rts-pathing/lib/proto/structs_go_proto"

	"github.com/minkezhang/rts-pathing/lib/hpf/abstractedgemap"
	"github.com/minkezhang/rts-pathing/lib/hpf/abstractnodemap"
	"github.com/minkezhang/rts-pathing/lib/hpf/astar"
	"github.com/minkezhang/rts-pathing/lib/hpf/cluster"
	"github.com/minkezhang/rts-pathing/lib/hpf/entrance"
	"github.com/minkezhang/rts-pathing/lib/hpf/tile"
	"github.com/minkezhang/rts-pathing/lib/hpf/utils"
	"github.com/golang/protobuf/proto"
	"google.golang.org/grpc/codes"
	"google.golang.org/grpc/status"
)

var (
	notImplemented = status.Error(
		codes.Unimplemented, "function not implemented")
)

// AbstractGraph contains the necessary state information to make an efficient
// path planning call on very large maps via hierarchical A* search, as
// described in Botea 2004.
type AbstractGraph struct {
	// Level is the maximum hierarchy of AbstractNodes in this graph;
	// this is a positive, non-zero integer. The 0th level here loosely
	// refers to the underlying base map.
	Level int32

	// NodeMap contains a Level: abstractnodemap.Map dict representing the
	// AbstractNodes per Level. As per AbstractGraph.ClusterMap, there
	// is a corresponding abstractnodemap.Map object per level. Nodes
	// within a specific abstractnodemap.Map may move between levels, and
	// may be deleted when the underlying terrain changes.
	//
	// The index of the map is L - 1 -- that is, the first element
	// of the list is the first level of abstraction.
	NodeMap []*abstractnodemap.Map

	// EdgeMap contains a Level: abstractedgemap.Map dict representing the
	// AbstractEdges per Level. Edges may move between levels and may
	// be deleted when the underlying terrain changes.
	//
	// The index of the map is L - 1 -- that is, the first element
	// of the list is the first level of abstraction.
	EdgeMap []*abstractedgemap.Map
}

// listIndex transforms a proto abstract hierarchy L into the appropriate
// addressable index for an AbstractGraph.
func listIndex(l int32) int32 {
	return l - 1
}

// abstractHierarchyLevel transforms an AbstractGraph object index into a proto
// abstract hierarchy L.
func abstractHierarchyLevel(i int32) int32 {
	return i + 1
}

// BuildAbstractGraph build a higher-level representation of a tile.Map
// populated with information about how to travel between different subsections
// between tiles. The level specified in input represents the number of
// abstractions that should be built for this map (l > 1 is useful for very,
// very large maps), and the tileDimension represents a subsection size.
func BuildAbstractGraph(tm *tile.Map, tileDimension *rtsspb.Coordinate, level int32) (*AbstractGraph, error) {
	if level < 1 {
		return nil, status.Error(codes.FailedPrecondition, "level must be a positive non-zero integer")
	}

	// TODO(minkezhang): Add higher-level node generation.
	if level > 1 {
		return nil, notImplemented
	}

	// Highest level cluster.Map should still have more than one Cluster,
	// otherwise we'll be routing units to the edge first before going back
	// inwards.
	if (int32(math.Pow(float64(tileDimension.GetX()), float64(level))) >= tm.D.GetX()) || (int32(math.Pow(float64(tileDimension.GetY()), float64(level))) >= tm.D.GetY()) {
		return nil, status.Error(codes.FailedPrecondition, "given tileDimension and level will result in too large a cluster.Map")
	}

	// This does not add any value for an AbstractGraph.
	if tileDimension.GetX() <= 1 && tileDimension.GetY() <= 1 {
		return nil, status.Error(codes.FailedPrecondition, "invalid tileDimension")
	}

	g := &AbstractGraph{
		Level: level,
	}

	// Create all node and edge map instances. These will be referenced and
	// mutated later on by passing the AbstractGraph object as a function
	// arg.
	for i := int32(0); i < level; i++ {
		cm, err := cluster.BuildMap(tm.D, &rtsspb.Coordinate{
			X: int32(math.Pow(float64(tileDimension.GetX()), float64(abstractHierarchyLevel(i)))),
			Y: int32(math.Pow(float64(tileDimension.GetY()), float64(abstractHierarchyLevel(i)))),
		}, abstractHierarchyLevel(i))
		if err != nil {
			return nil, err
		}

		g.NodeMap = append(g.NodeMap, &abstractnodemap.Map{
			ClusterMap: cm,
		})
		g.EdgeMap = append(g.EdgeMap, &abstractedgemap.Map{})
	}

	// Build the Tile-Tile edges which connect between two adjacent
	// clusters in the L-1 cluster.Map object and store this data into the
	// AbstractGraph.
	transitions, err := buildTransitions(tm, g.NodeMap[listIndex(1)].ClusterMap)
	if err != nil {
		return nil, err
	}
	for _, t := range transitions {
		g.NodeMap[listIndex(1)].Add(t.GetN1())
		g.NodeMap[listIndex(1)].Add(t.GetN2())
		g.EdgeMap[listIndex(1)].Add(&rtsspb.AbstractEdge{
			Level:       1,
			Source:      t.GetN1().GetTileCoordinate(),
			Destination: t.GetN2().GetTileCoordinate(),
			EdgeType:    rtscpb.EdgeType_EDGE_TYPE_INTER,
			Weight:      1, // Inter-edges are always of cost 1, per Botea.
		})
	}

	// Build Tile-Tile edges within a cluster of an L-1 cluster.Map.
	for _, c := range cluster.Iterator(g.NodeMap[listIndex(1)].ClusterMap) {
		nodes, err := g.NodeMap[listIndex(1)].GetByCluster(c)
		if err != nil {
			return nil, err
		}
		for _, n1 := range nodes {
			for _, n2 := range nodes {
				if n1 != n2 {
					e, err := buildIntraEdge(tm, g.NodeMap[listIndex(1)].ClusterMap, n1, n2)
					if err != nil {
						return nil, err
					}

					if e != nil {
						g.EdgeMap[listIndex(1)].Add(e)
					}
				}
			}
		}
	}

	for i := int32(1); i < level; i++ {
		// TODO(minkezhang): Implement for L > 1.
	}

	return g, nil
}

// buildIntraEdge constructs a single AbstractEdge instance with the correct
// traversal cost between two underlying AbstractNode objects. The cost
// function is calculated from the tile.Map entity, which holds information
// on e.g. the terrain information of the map.
func buildIntraEdge(tm *tile.Map, cm *cluster.Map, n1, n2 *rtsspb.AbstractNode) (*rtsspb.AbstractEdge, error) {
	c1, err := cluster.ClusterCoordinateFromTileCoordinate(cm, utils.MC(n1.GetTileCoordinate()))
	if err != nil {
		return nil, err
	}
	c2, err := cluster.ClusterCoordinateFromTileCoordinate(cm, utils.MC(n2.GetTileCoordinate()))
	if err != nil {
		return nil, err
	}
	if c1 != c2 {
		return nil, status.Errorf(codes.FailedPrecondition, "input AbstractNode instances are not bounded by the same cluster")
	}

	tileBoundary, err := cluster.TileBoundary(cm, c1)
	if err != nil {
		return nil, err
	}
	tileDimension, err := cluster.TileDimension(cm, c1)
	if err != nil {
		return nil, err
	}

	p, cost, err := astar.TileMapPath(
		tm,
		tm.TileFromCoordinate(n1.GetTileCoordinate()),
		tm.TileFromCoordinate(n2.GetTileCoordinate()),
		utils.PB(tileBoundary),
		utils.PB(tileDimension))
	if err != nil {
		return nil, err
	}

	if p != nil {
		return &rtsspb.AbstractEdge{
			Level:       cm.Val.GetLevel(),
			Source:      n1.GetTileCoordinate(),
			Destination: n2.GetTileCoordinate(),
			EdgeType:    rtscpb.EdgeType_EDGE_TYPE_INTRA,
			Weight:      cost,
		}, nil
	}
	return nil, nil
}

// buildTransitions iterates over the tile.Map for the input cluster.Map overlay
// and look for adjacent, open nodes along cluster-cluster borders.
func buildTransitions(tm *tile.Map, cm *cluster.Map) ([]*rtsspb.Transition, error) {
	var ts []*rtsspb.Transition
	for _, c1 := range cluster.Iterator(cm) {
		neighbors, err := cluster.Neighbors(cm, c1)
		if err != nil {
			return nil, err
		}

		for _, c2 := range neighbors {
			if cluster.IsAdjacent(cm, c1, c2) && utils.LessThan(c1, c2) {
				transitions, err := entrance.BuildTransitions(tm, cm, c1, c2)
				if err != nil {
					return nil, err
				}
				ts = append(ts, transitions...)
			}
		}
	}
	for _, t := range ts {
		t.GetN1().Level = cm.Val.GetLevel()
		t.GetN2().Level = cm.Val.GetLevel()
	}
	return ts, nil
}

// Neighbors returns all adjacent AbstractNode instances of the same hierarchy
// level of the input. Two AbstractNode instances are considered adjacent if
// there exists an edge defined between the two instances. Note that the
// instances returned here also include ephemeral AbstractNodes
// (n.GetEphemeralKey() > 0) -- DFS should take care not to expand these
// secondary neighbors.
func (g *AbstractGraph) Neighbors(n *rtsspb.AbstractNode) ([]*rtsspb.AbstractNode, error) {
	i := listIndex(n.GetLevel())
	if i < 0 || i > int32(len(g.NodeMap)) || i > int32(len(g.EdgeMap)) {
		return nil, status.Error(codes.FailedPrecondition, "invalid level specified for input")
	}

	nm := g.NodeMap[i]

	node, err := nm.Get(utils.MC(n.GetTileCoordinate()))
	if err != nil {
		return nil, err
	}
	if node == nil {
		return nil, status.Error(codes.FailedPrecondition, "cannot find specified node")
	}

	em := g.EdgeMap[i]
	edges, err := em.GetBySource(utils.MC(node.GetTileCoordinate()))
	if err != nil {
		return nil, err
	}

	var neighbors []*rtsspb.AbstractNode
	for _, e := range edges {
		var d *rtsspb.Coordinate
		if proto.Equal(node.GetTileCoordinate(), e.GetSource()) {
			d = e.GetDestination()
		} else {
			d = e.GetSource()
		}

		t, err := nm.Get(utils.MC(d))
		if err != nil {
			return nil, err
		}
		if t == nil {
			return nil, status.Errorf(codes.NotFound, "invalid node coordinate %v specified for edge %v", d, e)
		}

		neighbors = append(neighbors, t)
	}
	return neighbors, nil
}
