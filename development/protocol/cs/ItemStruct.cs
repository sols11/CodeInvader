// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Struct/ItemStruct.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ItemStruct {

  /// <summary>Holder for reflection information generated from Struct/ItemStruct.proto</summary>
  public static partial class ItemStructReflection {

    #region Descriptor
    /// <summary>File descriptor for Struct/ItemStruct.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ItemStructReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChdTdHJ1Y3QvSXRlbVN0cnVjdC5wcm90bxIKSXRlbVN0cnVjdBoZU3RydWN0",
            "L0NvbW1vblN0cnVjdC5wcm90byKnAQoMQmFzZUl0ZW1EYXRhEgsKA2VpZBgB",
            "IAEoBRInCglpdGVtX3R5cGUYAiABKA4yFC5JdGVtU3RydWN0Lkl0ZW1UeXBl",
            "Eg8KB2l0ZW1faWQYAyABKAUSDAoEbmFtZRgEIAEoCRITCgtjb2xsZWN0YWJs",
            "ZRgFIAEoCBItCgl0cmFuc2Zvcm0YBiABKAsyGi5Db21tb25TdHJ1Y3QuTmV0",
            "VHJhbnNmb3JtIjkKCkFpSXRlbUluZm8SDwoHaXRlbV9pZBgBIAEoBRIMCgRu",
            "YW1lGAIgASgJEgwKBGluZm8YAyABKAkirwMKDUVxdWlwSXRlbUluZm8SEAoI",
            "ZXF1aXBfaWQYASABKAUSJwoEc2xvdBgCIAEoDjIZLkl0ZW1TdHJ1Y3QuRXF1",
            "aXBtZW50U2xvdBItCgplcXVpcF90eXBlGAMgASgOMhkuSXRlbVN0cnVjdC5F",
            "cXVpcG1lbnRUeXBlEgwKBG5hbWUYBCABKAkSDgoGd2VpZ2h0GAUgASgCEhIK",
            "CnNldHVwX3RpbWUYBiABKAISFwoPYXR0YWNrX2R1cmF0aW9uGAcgASgCEg4K",
            "BmF0dGFjaxgIIAMoBRIrCglhdGtfcmFuZ2UYCSABKAsyGC5Db21tb25TdHJ1",
            "Y3QuTmV0VmVjdG9yMxIwCg5kaWZmX3JhbmdlX2F0axgKIAMoCzIYLkNvbW1v",
            "blN0cnVjdC5OZXRWZWN0b3IyEhgKEHJvdF9zcGVlZF9yZWR1Y2UYCyABKAIS",
            "FwoPc3BlY2lhbF9lZmZlY3RzGAwgASgFEhEKCWJlYXRfYmFjaxgNIAEoAhIQ",
            "CghzcGVlZF91cBgOIAEoAhIRCglzbG93X2Rvd24YDyABKAISDwoHY2FuX2Zs",
            "eRgQIAEoCConCghJdGVtVHlwZRIMCghBSU1vZHVsZRAAEg0KCUVxdWlwbWVu",
            "dBABKiIKDUVxdWlwbWVudFNsb3QSCAoESGFuZBAAEgcKA0xlZxABKogBCg1F",
            "cXVpcG1lbnRUeXBlEhMKD2VtcHR5X2VxdWlwdHlwZRAAEgsKB1Nob3RHdW4Q",
            "ARIRCg1Bc3NhdWx0cmlmbGVzEAISCwoHR2F0bGluZxADEg4KCU5vcm1hbExl",
            "ZxCBIBIUCg9EaXNwbGFjZW1lbnRMZWcQgiASDwoKRmxpZ2h0R2VhchCDICpb",
            "Cg5TcGVjaWFsRWZmZWN0cxIQCgxlbXB0eV9lZmZlY3QQABINCgliZWF0X2Jh",
            "Y2sQARIMCghzcGVlZF91cBACEg0KCXNsb3dfZG93bhAEEgsKB2Nhbl9mbHkQ",
            "CGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::CommonStruct.CommonStructReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::ItemStruct.ItemType), typeof(global::ItemStruct.EquipmentSlot), typeof(global::ItemStruct.EquipmentType), typeof(global::ItemStruct.SpecialEffects), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ItemStruct.BaseItemData), global::ItemStruct.BaseItemData.Parser, new[]{ "Eid", "ItemType", "ItemId", "Name", "Collectable", "Transform" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ItemStruct.AiItemInfo), global::ItemStruct.AiItemInfo.Parser, new[]{ "ItemId", "Name", "Info" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ItemStruct.EquipItemInfo), global::ItemStruct.EquipItemInfo.Parser, new[]{ "EquipId", "Slot", "EquipType", "Name", "Weight", "SetupTime", "AttackDuration", "Attack", "AtkRange", "DiffRangeAtk", "RotSpeedReduce", "SpecialEffects", "BeatBack", "SpeedUp", "SlowDown", "CanFly" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum ItemType {
    [pbr::OriginalName("AIModule")] Aimodule = 0,
    [pbr::OriginalName("Equipment")] Equipment = 1,
  }

  /// <summary>
  /// 武器装备部位
  /// </summary>
  public enum EquipmentSlot {
    [pbr::OriginalName("Hand")] Hand = 0,
    [pbr::OriginalName("Leg")] Leg = 1,
  }

  public enum EquipmentType {
    [pbr::OriginalName("empty_equiptype")] EmptyEquiptype = 0,
    /// <summary>
    /// 手部装备
    /// </summary>
    [pbr::OriginalName("ShotGun")] ShotGun = 1,
    /// <summary>
    /// 突击枪
    /// </summary>
    [pbr::OriginalName("Assaultrifles")] Assaultrifles = 2,
    /// <summary>
    /// 加特林
    /// </summary>
    [pbr::OriginalName("Gatling")] Gatling = 3,
    /// <summary>
    /// 腿部装备
    /// </summary>
    [pbr::OriginalName("NormalLeg")] NormalLeg = 4097,
    /// <summary>
    /// 位移腿
    /// </summary>
    [pbr::OriginalName("DisplacementLeg")] DisplacementLeg = 4098,
    /// <summary>
    /// 飞行装置 
    /// </summary>
    [pbr::OriginalName("FlightGear")] FlightGear = 4099,
  }

  /// <summary>
  /// 战斗效果掩码
  /// </summary>
  public enum SpecialEffects {
    [pbr::OriginalName("empty_effect")] EmptyEffect = 0,
    /// <summary>
    /// 击退效果
    /// </summary>
    [pbr::OriginalName("beat_back")] BeatBack = 1,
    /// <summary>
    /// 加速效果
    /// </summary>
    [pbr::OriginalName("speed_up")] SpeedUp = 2,
    /// <summary>
    /// 敌人减速
    /// </summary>
    [pbr::OriginalName("slow_down")] SlowDown = 4,
    /// <summary>
    /// 能否飞翔
    /// </summary>
    [pbr::OriginalName("can_fly")] CanFly = 8,
  }

  #endregion

  #region Messages
  /// <summary>
  /// 物品信息项
  /// </summary>
  public sealed partial class BaseItemData : pb::IMessage<BaseItemData> {
    private static readonly pb::MessageParser<BaseItemData> _parser = new pb::MessageParser<BaseItemData>(() => new BaseItemData());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<BaseItemData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ItemStruct.ItemStructReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BaseItemData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BaseItemData(BaseItemData other) : this() {
      eid_ = other.eid_;
      itemType_ = other.itemType_;
      itemId_ = other.itemId_;
      name_ = other.name_;
      collectable_ = other.collectable_;
      transform_ = other.transform_ != null ? other.transform_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BaseItemData Clone() {
      return new BaseItemData(this);
    }

    /// <summary>Field number for the "eid" field.</summary>
    public const int EidFieldNumber = 1;
    private int eid_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Eid {
      get { return eid_; }
      set {
        eid_ = value;
      }
    }

    /// <summary>Field number for the "item_type" field.</summary>
    public const int ItemTypeFieldNumber = 2;
    private global::ItemStruct.ItemType itemType_ = global::ItemStruct.ItemType.Aimodule;
    /// <summary>
    /// 物品类型
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::ItemStruct.ItemType ItemType {
      get { return itemType_; }
      set {
        itemType_ = value;
      }
    }

    /// <summary>Field number for the "item_id" field.</summary>
    public const int ItemIdFieldNumber = 3;
    private int itemId_;
    /// <summary>
    /// 物品类型具体ID
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ItemId {
      get { return itemId_; }
      set {
        itemId_ = value;
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 4;
    private string name_ = "";
    /// <summary>
    /// 物品名称
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "collectable" field.</summary>
    public const int CollectableFieldNumber = 5;
    private bool collectable_;
    /// <summary>
    /// 物品被收集的状态
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Collectable {
      get { return collectable_; }
      set {
        collectable_ = value;
      }
    }

    /// <summary>Field number for the "transform" field.</summary>
    public const int TransformFieldNumber = 6;
    private global::CommonStruct.NetTransform transform_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CommonStruct.NetTransform Transform {
      get { return transform_; }
      set {
        transform_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as BaseItemData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(BaseItemData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Eid != other.Eid) return false;
      if (ItemType != other.ItemType) return false;
      if (ItemId != other.ItemId) return false;
      if (Name != other.Name) return false;
      if (Collectable != other.Collectable) return false;
      if (!object.Equals(Transform, other.Transform)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Eid != 0) hash ^= Eid.GetHashCode();
      if (ItemType != global::ItemStruct.ItemType.Aimodule) hash ^= ItemType.GetHashCode();
      if (ItemId != 0) hash ^= ItemId.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Collectable != false) hash ^= Collectable.GetHashCode();
      if (transform_ != null) hash ^= Transform.GetHashCode();
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
      if (Eid != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Eid);
      }
      if (ItemType != global::ItemStruct.ItemType.Aimodule) {
        output.WriteRawTag(16);
        output.WriteEnum((int) ItemType);
      }
      if (ItemId != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(ItemId);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Name);
      }
      if (Collectable != false) {
        output.WriteRawTag(40);
        output.WriteBool(Collectable);
      }
      if (transform_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(Transform);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Eid != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Eid);
      }
      if (ItemType != global::ItemStruct.ItemType.Aimodule) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) ItemType);
      }
      if (ItemId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ItemId);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Collectable != false) {
        size += 1 + 1;
      }
      if (transform_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Transform);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(BaseItemData other) {
      if (other == null) {
        return;
      }
      if (other.Eid != 0) {
        Eid = other.Eid;
      }
      if (other.ItemType != global::ItemStruct.ItemType.Aimodule) {
        ItemType = other.ItemType;
      }
      if (other.ItemId != 0) {
        ItemId = other.ItemId;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Collectable != false) {
        Collectable = other.Collectable;
      }
      if (other.transform_ != null) {
        if (transform_ == null) {
          Transform = new global::CommonStruct.NetTransform();
        }
        Transform.MergeFrom(other.Transform);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Eid = input.ReadInt32();
            break;
          }
          case 16: {
            ItemType = (global::ItemStruct.ItemType) input.ReadEnum();
            break;
          }
          case 24: {
            ItemId = input.ReadInt32();
            break;
          }
          case 34: {
            Name = input.ReadString();
            break;
          }
          case 40: {
            Collectable = input.ReadBool();
            break;
          }
          case 50: {
            if (transform_ == null) {
              Transform = new global::CommonStruct.NetTransform();
            }
            input.ReadMessage(Transform);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// AI模块相关信息
  /// </summary>
  public sealed partial class AiItemInfo : pb::IMessage<AiItemInfo> {
    private static readonly pb::MessageParser<AiItemInfo> _parser = new pb::MessageParser<AiItemInfo>(() => new AiItemInfo());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AiItemInfo> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ItemStruct.ItemStructReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AiItemInfo() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AiItemInfo(AiItemInfo other) : this() {
      itemId_ = other.itemId_;
      name_ = other.name_;
      info_ = other.info_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AiItemInfo Clone() {
      return new AiItemInfo(this);
    }

    /// <summary>Field number for the "item_id" field.</summary>
    public const int ItemIdFieldNumber = 1;
    private int itemId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ItemId {
      get { return itemId_; }
      set {
        itemId_ = value;
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "info" field.</summary>
    public const int InfoFieldNumber = 3;
    private string info_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Info {
      get { return info_; }
      set {
        info_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AiItemInfo);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AiItemInfo other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ItemId != other.ItemId) return false;
      if (Name != other.Name) return false;
      if (Info != other.Info) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ItemId != 0) hash ^= ItemId.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Info.Length != 0) hash ^= Info.GetHashCode();
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
      if (ItemId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ItemId);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (Info.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Info);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ItemId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ItemId);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Info.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Info);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AiItemInfo other) {
      if (other == null) {
        return;
      }
      if (other.ItemId != 0) {
        ItemId = other.ItemId;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Info.Length != 0) {
        Info = other.Info;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            ItemId = input.ReadInt32();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 26: {
            Info = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// 装备相关信息
  /// </summary>
  public sealed partial class EquipItemInfo : pb::IMessage<EquipItemInfo> {
    private static readonly pb::MessageParser<EquipItemInfo> _parser = new pb::MessageParser<EquipItemInfo>(() => new EquipItemInfo());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<EquipItemInfo> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ItemStruct.ItemStructReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EquipItemInfo() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EquipItemInfo(EquipItemInfo other) : this() {
      equipId_ = other.equipId_;
      slot_ = other.slot_;
      equipType_ = other.equipType_;
      name_ = other.name_;
      weight_ = other.weight_;
      setupTime_ = other.setupTime_;
      attackDuration_ = other.attackDuration_;
      attack_ = other.attack_.Clone();
      atkRange_ = other.atkRange_ != null ? other.atkRange_.Clone() : null;
      diffRangeAtk_ = other.diffRangeAtk_.Clone();
      rotSpeedReduce_ = other.rotSpeedReduce_;
      specialEffects_ = other.specialEffects_;
      beatBack_ = other.beatBack_;
      speedUp_ = other.speedUp_;
      slowDown_ = other.slowDown_;
      canFly_ = other.canFly_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EquipItemInfo Clone() {
      return new EquipItemInfo(this);
    }

    /// <summary>Field number for the "equip_id" field.</summary>
    public const int EquipIdFieldNumber = 1;
    private int equipId_;
    /// <summary>
    /// 与EquipmentID相同
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int EquipId {
      get { return equipId_; }
      set {
        equipId_ = value;
      }
    }

    /// <summary>Field number for the "slot" field.</summary>
    public const int SlotFieldNumber = 2;
    private global::ItemStruct.EquipmentSlot slot_ = global::ItemStruct.EquipmentSlot.Hand;
    /// <summary>
    /// 装备位置
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::ItemStruct.EquipmentSlot Slot {
      get { return slot_; }
      set {
        slot_ = value;
      }
    }

    /// <summary>Field number for the "equip_type" field.</summary>
    public const int EquipTypeFieldNumber = 3;
    private global::ItemStruct.EquipmentType equipType_ = global::ItemStruct.EquipmentType.EmptyEquiptype;
    /// <summary>
    /// 装备种类
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::ItemStruct.EquipmentType EquipType {
      get { return equipType_; }
      set {
        equipType_ = value;
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 4;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "weight" field.</summary>
    public const int WeightFieldNumber = 5;
    private float weight_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Weight {
      get { return weight_; }
      set {
        weight_ = value;
      }
    }

    /// <summary>Field number for the "setup_time" field.</summary>
    public const int SetupTimeFieldNumber = 6;
    private float setupTime_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float SetupTime {
      get { return setupTime_; }
      set {
        setupTime_ = value;
      }
    }

    /// <summary>Field number for the "attack_duration" field.</summary>
    public const int AttackDurationFieldNumber = 7;
    private float attackDuration_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float AttackDuration {
      get { return attackDuration_; }
      set {
        attackDuration_ = value;
      }
    }

    /// <summary>Field number for the "attack" field.</summary>
    public const int AttackFieldNumber = 8;
    private static readonly pb::FieldCodec<int> _repeated_attack_codec
        = pb::FieldCodec.ForInt32(66);
    private readonly pbc::RepeatedField<int> attack_ = new pbc::RepeatedField<int>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<int> Attack {
      get { return attack_; }
    }

    /// <summary>Field number for the "atk_range" field.</summary>
    public const int AtkRangeFieldNumber = 9;
    private global::CommonStruct.NetVector3 atkRange_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CommonStruct.NetVector3 AtkRange {
      get { return atkRange_; }
      set {
        atkRange_ = value;
      }
    }

    /// <summary>Field number for the "diff_range_atk" field.</summary>
    public const int DiffRangeAtkFieldNumber = 10;
    private static readonly pb::FieldCodec<global::CommonStruct.NetVector2> _repeated_diffRangeAtk_codec
        = pb::FieldCodec.ForMessage(82, global::CommonStruct.NetVector2.Parser);
    private readonly pbc::RepeatedField<global::CommonStruct.NetVector2> diffRangeAtk_ = new pbc::RepeatedField<global::CommonStruct.NetVector2>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::CommonStruct.NetVector2> DiffRangeAtk {
      get { return diffRangeAtk_; }
    }

    /// <summary>Field number for the "rot_speed_reduce" field.</summary>
    public const int RotSpeedReduceFieldNumber = 11;
    private float rotSpeedReduce_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float RotSpeedReduce {
      get { return rotSpeedReduce_; }
      set {
        rotSpeedReduce_ = value;
      }
    }

    /// <summary>Field number for the "special_effects" field.</summary>
    public const int SpecialEffectsFieldNumber = 12;
    private int specialEffects_;
    /// <summary>
    /// 特殊效果
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int SpecialEffects {
      get { return specialEffects_; }
      set {
        specialEffects_ = value;
      }
    }

    /// <summary>Field number for the "beat_back" field.</summary>
    public const int BeatBackFieldNumber = 13;
    private float beatBack_;
    /// <summary>
    /// 每种特殊效果对应的数值
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float BeatBack {
      get { return beatBack_; }
      set {
        beatBack_ = value;
      }
    }

    /// <summary>Field number for the "speed_up" field.</summary>
    public const int SpeedUpFieldNumber = 14;
    private float speedUp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float SpeedUp {
      get { return speedUp_; }
      set {
        speedUp_ = value;
      }
    }

    /// <summary>Field number for the "slow_down" field.</summary>
    public const int SlowDownFieldNumber = 15;
    private float slowDown_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float SlowDown {
      get { return slowDown_; }
      set {
        slowDown_ = value;
      }
    }

    /// <summary>Field number for the "can_fly" field.</summary>
    public const int CanFlyFieldNumber = 16;
    private bool canFly_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool CanFly {
      get { return canFly_; }
      set {
        canFly_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as EquipItemInfo);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(EquipItemInfo other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (EquipId != other.EquipId) return false;
      if (Slot != other.Slot) return false;
      if (EquipType != other.EquipType) return false;
      if (Name != other.Name) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Weight, other.Weight)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(SetupTime, other.SetupTime)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(AttackDuration, other.AttackDuration)) return false;
      if(!attack_.Equals(other.attack_)) return false;
      if (!object.Equals(AtkRange, other.AtkRange)) return false;
      if(!diffRangeAtk_.Equals(other.diffRangeAtk_)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(RotSpeedReduce, other.RotSpeedReduce)) return false;
      if (SpecialEffects != other.SpecialEffects) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(BeatBack, other.BeatBack)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(SpeedUp, other.SpeedUp)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(SlowDown, other.SlowDown)) return false;
      if (CanFly != other.CanFly) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (EquipId != 0) hash ^= EquipId.GetHashCode();
      if (Slot != global::ItemStruct.EquipmentSlot.Hand) hash ^= Slot.GetHashCode();
      if (EquipType != global::ItemStruct.EquipmentType.EmptyEquiptype) hash ^= EquipType.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Weight != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Weight);
      if (SetupTime != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(SetupTime);
      if (AttackDuration != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(AttackDuration);
      hash ^= attack_.GetHashCode();
      if (atkRange_ != null) hash ^= AtkRange.GetHashCode();
      hash ^= diffRangeAtk_.GetHashCode();
      if (RotSpeedReduce != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(RotSpeedReduce);
      if (SpecialEffects != 0) hash ^= SpecialEffects.GetHashCode();
      if (BeatBack != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(BeatBack);
      if (SpeedUp != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(SpeedUp);
      if (SlowDown != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(SlowDown);
      if (CanFly != false) hash ^= CanFly.GetHashCode();
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
      if (EquipId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(EquipId);
      }
      if (Slot != global::ItemStruct.EquipmentSlot.Hand) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Slot);
      }
      if (EquipType != global::ItemStruct.EquipmentType.EmptyEquiptype) {
        output.WriteRawTag(24);
        output.WriteEnum((int) EquipType);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Name);
      }
      if (Weight != 0F) {
        output.WriteRawTag(45);
        output.WriteFloat(Weight);
      }
      if (SetupTime != 0F) {
        output.WriteRawTag(53);
        output.WriteFloat(SetupTime);
      }
      if (AttackDuration != 0F) {
        output.WriteRawTag(61);
        output.WriteFloat(AttackDuration);
      }
      attack_.WriteTo(output, _repeated_attack_codec);
      if (atkRange_ != null) {
        output.WriteRawTag(74);
        output.WriteMessage(AtkRange);
      }
      diffRangeAtk_.WriteTo(output, _repeated_diffRangeAtk_codec);
      if (RotSpeedReduce != 0F) {
        output.WriteRawTag(93);
        output.WriteFloat(RotSpeedReduce);
      }
      if (SpecialEffects != 0) {
        output.WriteRawTag(96);
        output.WriteInt32(SpecialEffects);
      }
      if (BeatBack != 0F) {
        output.WriteRawTag(109);
        output.WriteFloat(BeatBack);
      }
      if (SpeedUp != 0F) {
        output.WriteRawTag(117);
        output.WriteFloat(SpeedUp);
      }
      if (SlowDown != 0F) {
        output.WriteRawTag(125);
        output.WriteFloat(SlowDown);
      }
      if (CanFly != false) {
        output.WriteRawTag(128, 1);
        output.WriteBool(CanFly);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (EquipId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(EquipId);
      }
      if (Slot != global::ItemStruct.EquipmentSlot.Hand) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Slot);
      }
      if (EquipType != global::ItemStruct.EquipmentType.EmptyEquiptype) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) EquipType);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Weight != 0F) {
        size += 1 + 4;
      }
      if (SetupTime != 0F) {
        size += 1 + 4;
      }
      if (AttackDuration != 0F) {
        size += 1 + 4;
      }
      size += attack_.CalculateSize(_repeated_attack_codec);
      if (atkRange_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(AtkRange);
      }
      size += diffRangeAtk_.CalculateSize(_repeated_diffRangeAtk_codec);
      if (RotSpeedReduce != 0F) {
        size += 1 + 4;
      }
      if (SpecialEffects != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(SpecialEffects);
      }
      if (BeatBack != 0F) {
        size += 1 + 4;
      }
      if (SpeedUp != 0F) {
        size += 1 + 4;
      }
      if (SlowDown != 0F) {
        size += 1 + 4;
      }
      if (CanFly != false) {
        size += 2 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(EquipItemInfo other) {
      if (other == null) {
        return;
      }
      if (other.EquipId != 0) {
        EquipId = other.EquipId;
      }
      if (other.Slot != global::ItemStruct.EquipmentSlot.Hand) {
        Slot = other.Slot;
      }
      if (other.EquipType != global::ItemStruct.EquipmentType.EmptyEquiptype) {
        EquipType = other.EquipType;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Weight != 0F) {
        Weight = other.Weight;
      }
      if (other.SetupTime != 0F) {
        SetupTime = other.SetupTime;
      }
      if (other.AttackDuration != 0F) {
        AttackDuration = other.AttackDuration;
      }
      attack_.Add(other.attack_);
      if (other.atkRange_ != null) {
        if (atkRange_ == null) {
          AtkRange = new global::CommonStruct.NetVector3();
        }
        AtkRange.MergeFrom(other.AtkRange);
      }
      diffRangeAtk_.Add(other.diffRangeAtk_);
      if (other.RotSpeedReduce != 0F) {
        RotSpeedReduce = other.RotSpeedReduce;
      }
      if (other.SpecialEffects != 0) {
        SpecialEffects = other.SpecialEffects;
      }
      if (other.BeatBack != 0F) {
        BeatBack = other.BeatBack;
      }
      if (other.SpeedUp != 0F) {
        SpeedUp = other.SpeedUp;
      }
      if (other.SlowDown != 0F) {
        SlowDown = other.SlowDown;
      }
      if (other.CanFly != false) {
        CanFly = other.CanFly;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            EquipId = input.ReadInt32();
            break;
          }
          case 16: {
            Slot = (global::ItemStruct.EquipmentSlot) input.ReadEnum();
            break;
          }
          case 24: {
            EquipType = (global::ItemStruct.EquipmentType) input.ReadEnum();
            break;
          }
          case 34: {
            Name = input.ReadString();
            break;
          }
          case 45: {
            Weight = input.ReadFloat();
            break;
          }
          case 53: {
            SetupTime = input.ReadFloat();
            break;
          }
          case 61: {
            AttackDuration = input.ReadFloat();
            break;
          }
          case 66:
          case 64: {
            attack_.AddEntriesFrom(input, _repeated_attack_codec);
            break;
          }
          case 74: {
            if (atkRange_ == null) {
              AtkRange = new global::CommonStruct.NetVector3();
            }
            input.ReadMessage(AtkRange);
            break;
          }
          case 82: {
            diffRangeAtk_.AddEntriesFrom(input, _repeated_diffRangeAtk_codec);
            break;
          }
          case 93: {
            RotSpeedReduce = input.ReadFloat();
            break;
          }
          case 96: {
            SpecialEffects = input.ReadInt32();
            break;
          }
          case 109: {
            BeatBack = input.ReadFloat();
            break;
          }
          case 117: {
            SpeedUp = input.ReadFloat();
            break;
          }
          case 125: {
            SlowDown = input.ReadFloat();
            break;
          }
          case 128: {
            CanFly = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
