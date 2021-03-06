package delta

import (
	"reflect"

	"github.com/downflux/game/engine/curve/curve"
	"github.com/downflux/game/engine/id/id"
	"google.golang.org/grpc/codes"
	"google.golang.org/grpc/status"

	gcpb "github.com/downflux/game/api/constants_go_proto"
)

const (
	curveType = gcpb.CurveType_CURVE_TYPE_DELTA
)

type Curve struct {
	curve.Curve
}

func New(c curve.Curve) *Curve { return &Curve{Curve: c} }

func (c *Curve) Type() gcpb.CurveType { return curveType }

func (c *Curve) Merge(o curve.Curve) error {
	if o.Type() != curveType {
		return status.Errorf(codes.FailedPrecondition, "cannot merge %v curve", o.Type())
	}

	return c.Curve.Merge(o.(*Curve).Curve)
}

func (c *Curve) Add(t id.Tick, v interface{}) error {
	if c.DatumType() != reflect.TypeOf(float64(0)) {
		return status.Errorf(codes.FailedPrecondition, "cannot add a curve delta for %v type curve", c.DatumType())
	}

	c.Data().Set(t, c.Get(t).(float64)+v.(float64))
	for i := c.Data().Search(t); i < c.Data().Len(); i++ {
		tick := c.Data().Tick(i)
		if t != tick {
			value := c.Data().Get(tick).(float64)
			c.Data().Set(tick, value+v.(float64))
		}
	}
	return nil
}
