// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: map/api/data.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace DF.Game.Map.API.Data {

  /// <summary>Holder for reflection information generated from map/api/data.proto</summary>
  public static partial class DataReflection {

    #region Descriptor
    /// <summary>File descriptor for map/api/data.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DataReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChJtYXAvYXBpL2RhdGEucHJvdG8SEWdhbWUubWFwLmFwaS5kYXRhGg5hcGkv",
            "ZGF0YS5wcm90bxoXbWFwL2FwaS9jb25zdGFudHMucHJvdG8icAoEVGlsZRIt",
            "Cgpjb29yZGluYXRlGAEgASgLMhkuZ2FtZS5hcGkuZGF0YS5Db29yZGluYXRl",
            "EjkKDHRlcnJhaW5fdHlwZRgCIAEoDjIjLmdhbWUubWFwLmFwaS5jb25zdGFu",
            "dHMuVGVycmFpblR5cGUiVgoLVGVycmFpbkNvc3QSOQoMdGVycmFpbl90eXBl",
            "GAEgASgOMiMuZ2FtZS5tYXAuYXBpLmNvbnN0YW50cy5UZXJyYWluVHlwZRIM",
            "CgRjb3N0GAIgASgBIpYBCgdUaWxlTWFwEiwKCWRpbWVuc2lvbhgBIAEoCzIZ",
            "LmdhbWUuYXBpLmRhdGEuQ29vcmRpbmF0ZRImCgV0aWxlcxgCIAMoCzIXLmdh",
            "bWUubWFwLmFwaS5kYXRhLlRpbGUSNQoNdGVycmFpbl9jb3N0cxgDIAMoCzIe",
            "LmdhbWUubWFwLmFwaS5kYXRhLlRlcnJhaW5Db3N0QipaEWdhbWUubWFwLmFw",
            "aS5kYXRhqgIUREYuR2FtZS5NYXAuQVBJLkRhdGFiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::DF.Game.API.Data.DataReflection.Descriptor, global::DF.Game.Map.API.Constants.ConstantsReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::DF.Game.Map.API.Data.Tile), global::DF.Game.Map.API.Data.Tile.Parser, new[]{ "Coordinate", "TerrainType" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::DF.Game.Map.API.Data.TerrainCost), global::DF.Game.Map.API.Data.TerrainCost.Parser, new[]{ "TerrainType", "Cost" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::DF.Game.Map.API.Data.TileMap), global::DF.Game.Map.API.Data.TileMap.Parser, new[]{ "Dimension", "Tiles", "TerrainCosts" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Tile : pb::IMessage<Tile>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Tile> _parser = new pb::MessageParser<Tile>(() => new Tile());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Tile> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::DF.Game.Map.API.Data.DataReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Tile() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Tile(Tile other) : this() {
      coordinate_ = other.coordinate_ != null ? other.coordinate_.Clone() : null;
      terrainType_ = other.terrainType_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Tile Clone() {
      return new Tile(this);
    }

    /// <summary>Field number for the "coordinate" field.</summary>
    public const int CoordinateFieldNumber = 1;
    private global::DF.Game.API.Data.Coordinate coordinate_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::DF.Game.API.Data.Coordinate Coordinate {
      get { return coordinate_; }
      set {
        coordinate_ = value;
      }
    }

    /// <summary>Field number for the "terrain_type" field.</summary>
    public const int TerrainTypeFieldNumber = 2;
    private global::DF.Game.Map.API.Constants.TerrainType terrainType_ = global::DF.Game.Map.API.Constants.TerrainType.Unknown;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::DF.Game.Map.API.Constants.TerrainType TerrainType {
      get { return terrainType_; }
      set {
        terrainType_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Tile);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Tile other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Coordinate, other.Coordinate)) return false;
      if (TerrainType != other.TerrainType) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (coordinate_ != null) hash ^= Coordinate.GetHashCode();
      if (TerrainType != global::DF.Game.Map.API.Constants.TerrainType.Unknown) hash ^= TerrainType.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (coordinate_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Coordinate);
      }
      if (TerrainType != global::DF.Game.Map.API.Constants.TerrainType.Unknown) {
        output.WriteRawTag(16);
        output.WriteEnum((int) TerrainType);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (coordinate_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Coordinate);
      }
      if (TerrainType != global::DF.Game.Map.API.Constants.TerrainType.Unknown) {
        output.WriteRawTag(16);
        output.WriteEnum((int) TerrainType);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (coordinate_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Coordinate);
      }
      if (TerrainType != global::DF.Game.Map.API.Constants.TerrainType.Unknown) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) TerrainType);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Tile other) {
      if (other == null) {
        return;
      }
      if (other.coordinate_ != null) {
        if (coordinate_ == null) {
          Coordinate = new global::DF.Game.API.Data.Coordinate();
        }
        Coordinate.MergeFrom(other.Coordinate);
      }
      if (other.TerrainType != global::DF.Game.Map.API.Constants.TerrainType.Unknown) {
        TerrainType = other.TerrainType;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (coordinate_ == null) {
              Coordinate = new global::DF.Game.API.Data.Coordinate();
            }
            input.ReadMessage(Coordinate);
            break;
          }
          case 16: {
            TerrainType = (global::DF.Game.Map.API.Constants.TerrainType) input.ReadEnum();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (coordinate_ == null) {
              Coordinate = new global::DF.Game.API.Data.Coordinate();
            }
            input.ReadMessage(Coordinate);
            break;
          }
          case 16: {
            TerrainType = (global::DF.Game.Map.API.Constants.TerrainType) input.ReadEnum();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class TerrainCost : pb::IMessage<TerrainCost>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<TerrainCost> _parser = new pb::MessageParser<TerrainCost>(() => new TerrainCost());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TerrainCost> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::DF.Game.Map.API.Data.DataReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TerrainCost() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TerrainCost(TerrainCost other) : this() {
      terrainType_ = other.terrainType_;
      cost_ = other.cost_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TerrainCost Clone() {
      return new TerrainCost(this);
    }

    /// <summary>Field number for the "terrain_type" field.</summary>
    public const int TerrainTypeFieldNumber = 1;
    private global::DF.Game.Map.API.Constants.TerrainType terrainType_ = global::DF.Game.Map.API.Constants.TerrainType.Unknown;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::DF.Game.Map.API.Constants.TerrainType TerrainType {
      get { return terrainType_; }
      set {
        terrainType_ = value;
      }
    }

    /// <summary>Field number for the "cost" field.</summary>
    public const int CostFieldNumber = 2;
    private double cost_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Cost {
      get { return cost_; }
      set {
        cost_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TerrainCost);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TerrainCost other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (TerrainType != other.TerrainType) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Cost, other.Cost)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (TerrainType != global::DF.Game.Map.API.Constants.TerrainType.Unknown) hash ^= TerrainType.GetHashCode();
      if (Cost != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Cost);
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (TerrainType != global::DF.Game.Map.API.Constants.TerrainType.Unknown) {
        output.WriteRawTag(8);
        output.WriteEnum((int) TerrainType);
      }
      if (Cost != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Cost);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (TerrainType != global::DF.Game.Map.API.Constants.TerrainType.Unknown) {
        output.WriteRawTag(8);
        output.WriteEnum((int) TerrainType);
      }
      if (Cost != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Cost);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (TerrainType != global::DF.Game.Map.API.Constants.TerrainType.Unknown) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) TerrainType);
      }
      if (Cost != 0D) {
        size += 1 + 8;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TerrainCost other) {
      if (other == null) {
        return;
      }
      if (other.TerrainType != global::DF.Game.Map.API.Constants.TerrainType.Unknown) {
        TerrainType = other.TerrainType;
      }
      if (other.Cost != 0D) {
        Cost = other.Cost;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            TerrainType = (global::DF.Game.Map.API.Constants.TerrainType) input.ReadEnum();
            break;
          }
          case 17: {
            Cost = input.ReadDouble();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            TerrainType = (global::DF.Game.Map.API.Constants.TerrainType) input.ReadEnum();
            break;
          }
          case 17: {
            Cost = input.ReadDouble();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class TileMap : pb::IMessage<TileMap>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<TileMap> _parser = new pb::MessageParser<TileMap>(() => new TileMap());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TileMap> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::DF.Game.Map.API.Data.DataReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TileMap() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TileMap(TileMap other) : this() {
      dimension_ = other.dimension_ != null ? other.dimension_.Clone() : null;
      tiles_ = other.tiles_.Clone();
      terrainCosts_ = other.terrainCosts_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TileMap Clone() {
      return new TileMap(this);
    }

    /// <summary>Field number for the "dimension" field.</summary>
    public const int DimensionFieldNumber = 1;
    private global::DF.Game.API.Data.Coordinate dimension_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::DF.Game.API.Data.Coordinate Dimension {
      get { return dimension_; }
      set {
        dimension_ = value;
      }
    }

    /// <summary>Field number for the "tiles" field.</summary>
    public const int TilesFieldNumber = 2;
    private static readonly pb::FieldCodec<global::DF.Game.Map.API.Data.Tile> _repeated_tiles_codec
        = pb::FieldCodec.ForMessage(18, global::DF.Game.Map.API.Data.Tile.Parser);
    private readonly pbc::RepeatedField<global::DF.Game.Map.API.Data.Tile> tiles_ = new pbc::RepeatedField<global::DF.Game.Map.API.Data.Tile>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::DF.Game.Map.API.Data.Tile> Tiles {
      get { return tiles_; }
    }

    /// <summary>Field number for the "terrain_costs" field.</summary>
    public const int TerrainCostsFieldNumber = 3;
    private static readonly pb::FieldCodec<global::DF.Game.Map.API.Data.TerrainCost> _repeated_terrainCosts_codec
        = pb::FieldCodec.ForMessage(26, global::DF.Game.Map.API.Data.TerrainCost.Parser);
    private readonly pbc::RepeatedField<global::DF.Game.Map.API.Data.TerrainCost> terrainCosts_ = new pbc::RepeatedField<global::DF.Game.Map.API.Data.TerrainCost>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::DF.Game.Map.API.Data.TerrainCost> TerrainCosts {
      get { return terrainCosts_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TileMap);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TileMap other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Dimension, other.Dimension)) return false;
      if(!tiles_.Equals(other.tiles_)) return false;
      if(!terrainCosts_.Equals(other.terrainCosts_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (dimension_ != null) hash ^= Dimension.GetHashCode();
      hash ^= tiles_.GetHashCode();
      hash ^= terrainCosts_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (dimension_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Dimension);
      }
      tiles_.WriteTo(output, _repeated_tiles_codec);
      terrainCosts_.WriteTo(output, _repeated_terrainCosts_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (dimension_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Dimension);
      }
      tiles_.WriteTo(ref output, _repeated_tiles_codec);
      terrainCosts_.WriteTo(ref output, _repeated_terrainCosts_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (dimension_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Dimension);
      }
      size += tiles_.CalculateSize(_repeated_tiles_codec);
      size += terrainCosts_.CalculateSize(_repeated_terrainCosts_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TileMap other) {
      if (other == null) {
        return;
      }
      if (other.dimension_ != null) {
        if (dimension_ == null) {
          Dimension = new global::DF.Game.API.Data.Coordinate();
        }
        Dimension.MergeFrom(other.Dimension);
      }
      tiles_.Add(other.tiles_);
      terrainCosts_.Add(other.terrainCosts_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (dimension_ == null) {
              Dimension = new global::DF.Game.API.Data.Coordinate();
            }
            input.ReadMessage(Dimension);
            break;
          }
          case 18: {
            tiles_.AddEntriesFrom(input, _repeated_tiles_codec);
            break;
          }
          case 26: {
            terrainCosts_.AddEntriesFrom(input, _repeated_terrainCosts_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (dimension_ == null) {
              Dimension = new global::DF.Game.API.Data.Coordinate();
            }
            input.ReadMessage(Dimension);
            break;
          }
          case 18: {
            tiles_.AddEntriesFrom(ref input, _repeated_tiles_codec);
            break;
          }
          case 26: {
            terrainCosts_.AddEntriesFrom(ref input, _repeated_terrainCosts_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
