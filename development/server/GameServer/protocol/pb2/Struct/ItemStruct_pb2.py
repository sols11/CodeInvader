# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: Struct/ItemStruct.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf.internal import enum_type_wrapper
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()


from Struct import CommonStruct_pb2 as Struct_dot_CommonStruct__pb2


DESCRIPTOR = _descriptor.FileDescriptor(
  name='Struct/ItemStruct.proto',
  package='ItemStruct',
  syntax='proto3',
  serialized_options=None,
  serialized_pb=_b('\n\x17Struct/ItemStruct.proto\x12\nItemStruct\x1a\x19Struct/CommonStruct.proto\"\xa7\x01\n\x0c\x42\x61seItemData\x12\x0b\n\x03\x65id\x18\x01 \x01(\x05\x12\'\n\titem_type\x18\x02 \x01(\x0e\x32\x14.ItemStruct.ItemType\x12\x0f\n\x07item_id\x18\x03 \x01(\x05\x12\x0c\n\x04name\x18\x04 \x01(\t\x12\x13\n\x0b\x63ollectable\x18\x05 \x01(\x08\x12-\n\ttransform\x18\x06 \x01(\x0b\x32\x1a.CommonStruct.NetTransform\"9\n\nAiItemInfo\x12\x0f\n\x07item_id\x18\x01 \x01(\x05\x12\x0c\n\x04name\x18\x02 \x01(\t\x12\x0c\n\x04info\x18\x03 \x01(\t\"\xae\x03\n\rEquipItemInfo\x12\x0f\n\x07item_id\x18\x01 \x01(\x05\x12\'\n\x04slot\x18\x02 \x01(\x0e\x32\x19.ItemStruct.EquipmentSlot\x12-\n\nequip_type\x18\x03 \x01(\x0e\x32\x19.ItemStruct.EquipmentType\x12\x0c\n\x04name\x18\x04 \x01(\t\x12\x0e\n\x06weight\x18\x05 \x01(\x05\x12\x12\n\nsetup_time\x18\x06 \x01(\x02\x12\x17\n\x0f\x61ttack_duration\x18\x07 \x01(\x02\x12\x0e\n\x06\x61ttack\x18\x08 \x01(\x05\x12+\n\tatk_range\x18\t \x01(\x0b\x32\x18.CommonStruct.NetVector3\x12\x30\n\x0e\x64iff_range_atk\x18\n \x03(\x0b\x32\x18.CommonStruct.NetVector2\x12\x18\n\x10rot_speed_reduce\x18\x0b \x01(\x02\x12\x17\n\x0fspecial_effects\x18\x0c \x01(\x05\x12\x11\n\tbeat_back\x18\r \x01(\x05\x12\x10\n\x08speed_up\x18\x0e \x01(\x05\x12\x11\n\tslow_down\x18\x0f \x01(\x05\x12\x0f\n\x07\x63\x61n_fly\x18\x10 \x01(\x08*\'\n\x08ItemType\x12\x0c\n\x08\x41IModule\x10\x00\x12\r\n\tEquipment\x10\x01*\"\n\rEquipmentSlot\x12\x08\n\x04Hand\x10\x00\x12\x07\n\x03Leg\x10\x01*\x88\x01\n\rEquipmentType\x12\x13\n\x0f\x65mpty_equiptype\x10\x00\x12\x0b\n\x07ShotGun\x10\x01\x12\x11\n\rAssaultrifles\x10\x02\x12\x0b\n\x07Gatling\x10\x03\x12\x0e\n\tNormalLeg\x10\x81 \x12\x14\n\x0f\x44isplacementLeg\x10\x82 \x12\x0f\n\nFlightGear\x10\x83 *[\n\x0eSpecialEffects\x12\x10\n\x0c\x65mpty_effect\x10\x00\x12\r\n\tbeat_back\x10\x01\x12\x0c\n\x08speed_up\x10\x02\x12\r\n\tslow_down\x10\x04\x12\x0b\n\x07\x63\x61n_fly\x10\x08\x62\x06proto3')
  ,
  dependencies=[Struct_dot_CommonStruct__pb2.DESCRIPTOR,])

_ITEMTYPE = _descriptor.EnumDescriptor(
  name='ItemType',
  full_name='ItemStruct.ItemType',
  filename=None,
  file=DESCRIPTOR,
  values=[
    _descriptor.EnumValueDescriptor(
      name='AIModule', index=0, number=0,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='Equipment', index=1, number=1,
      serialized_options=None,
      type=None),
  ],
  containing_type=None,
  serialized_options=None,
  serialized_start=728,
  serialized_end=767,
)
_sym_db.RegisterEnumDescriptor(_ITEMTYPE)

ItemType = enum_type_wrapper.EnumTypeWrapper(_ITEMTYPE)
_EQUIPMENTSLOT = _descriptor.EnumDescriptor(
  name='EquipmentSlot',
  full_name='ItemStruct.EquipmentSlot',
  filename=None,
  file=DESCRIPTOR,
  values=[
    _descriptor.EnumValueDescriptor(
      name='Hand', index=0, number=0,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='Leg', index=1, number=1,
      serialized_options=None,
      type=None),
  ],
  containing_type=None,
  serialized_options=None,
  serialized_start=769,
  serialized_end=803,
)
_sym_db.RegisterEnumDescriptor(_EQUIPMENTSLOT)

EquipmentSlot = enum_type_wrapper.EnumTypeWrapper(_EQUIPMENTSLOT)
_EQUIPMENTTYPE = _descriptor.EnumDescriptor(
  name='EquipmentType',
  full_name='ItemStruct.EquipmentType',
  filename=None,
  file=DESCRIPTOR,
  values=[
    _descriptor.EnumValueDescriptor(
      name='empty_equiptype', index=0, number=0,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='ShotGun', index=1, number=1,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='Assaultrifles', index=2, number=2,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='Gatling', index=3, number=3,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='NormalLeg', index=4, number=4097,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='DisplacementLeg', index=5, number=4098,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='FlightGear', index=6, number=4099,
      serialized_options=None,
      type=None),
  ],
  containing_type=None,
  serialized_options=None,
  serialized_start=806,
  serialized_end=942,
)
_sym_db.RegisterEnumDescriptor(_EQUIPMENTTYPE)

EquipmentType = enum_type_wrapper.EnumTypeWrapper(_EQUIPMENTTYPE)
_SPECIALEFFECTS = _descriptor.EnumDescriptor(
  name='SpecialEffects',
  full_name='ItemStruct.SpecialEffects',
  filename=None,
  file=DESCRIPTOR,
  values=[
    _descriptor.EnumValueDescriptor(
      name='empty_effect', index=0, number=0,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='beat_back', index=1, number=1,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='speed_up', index=2, number=2,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='slow_down', index=3, number=4,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='can_fly', index=4, number=8,
      serialized_options=None,
      type=None),
  ],
  containing_type=None,
  serialized_options=None,
  serialized_start=944,
  serialized_end=1035,
)
_sym_db.RegisterEnumDescriptor(_SPECIALEFFECTS)

SpecialEffects = enum_type_wrapper.EnumTypeWrapper(_SPECIALEFFECTS)
AIModule = 0
Equipment = 1
Hand = 0
Leg = 1
empty_equiptype = 0
ShotGun = 1
Assaultrifles = 2
Gatling = 3
NormalLeg = 4097
DisplacementLeg = 4098
FlightGear = 4099
empty_effect = 0
beat_back = 1
speed_up = 2
slow_down = 4
can_fly = 8



_BASEITEMDATA = _descriptor.Descriptor(
  name='BaseItemData',
  full_name='ItemStruct.BaseItemData',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='eid', full_name='ItemStruct.BaseItemData.eid', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='item_type', full_name='ItemStruct.BaseItemData.item_type', index=1,
      number=2, type=14, cpp_type=8, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='item_id', full_name='ItemStruct.BaseItemData.item_id', index=2,
      number=3, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name', full_name='ItemStruct.BaseItemData.name', index=3,
      number=4, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='collectable', full_name='ItemStruct.BaseItemData.collectable', index=4,
      number=5, type=8, cpp_type=7, label=1,
      has_default_value=False, default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='transform', full_name='ItemStruct.BaseItemData.transform', index=5,
      number=6, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=67,
  serialized_end=234,
)


_AIITEMINFO = _descriptor.Descriptor(
  name='AiItemInfo',
  full_name='ItemStruct.AiItemInfo',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='item_id', full_name='ItemStruct.AiItemInfo.item_id', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name', full_name='ItemStruct.AiItemInfo.name', index=1,
      number=2, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='info', full_name='ItemStruct.AiItemInfo.info', index=2,
      number=3, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=236,
  serialized_end=293,
)


_EQUIPITEMINFO = _descriptor.Descriptor(
  name='EquipItemInfo',
  full_name='ItemStruct.EquipItemInfo',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='item_id', full_name='ItemStruct.EquipItemInfo.item_id', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='slot', full_name='ItemStruct.EquipItemInfo.slot', index=1,
      number=2, type=14, cpp_type=8, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='equip_type', full_name='ItemStruct.EquipItemInfo.equip_type', index=2,
      number=3, type=14, cpp_type=8, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name', full_name='ItemStruct.EquipItemInfo.name', index=3,
      number=4, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='weight', full_name='ItemStruct.EquipItemInfo.weight', index=4,
      number=5, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='setup_time', full_name='ItemStruct.EquipItemInfo.setup_time', index=5,
      number=6, type=2, cpp_type=6, label=1,
      has_default_value=False, default_value=float(0),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='attack_duration', full_name='ItemStruct.EquipItemInfo.attack_duration', index=6,
      number=7, type=2, cpp_type=6, label=1,
      has_default_value=False, default_value=float(0),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='attack', full_name='ItemStruct.EquipItemInfo.attack', index=7,
      number=8, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='atk_range', full_name='ItemStruct.EquipItemInfo.atk_range', index=8,
      number=9, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='diff_range_atk', full_name='ItemStruct.EquipItemInfo.diff_range_atk', index=9,
      number=10, type=11, cpp_type=10, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='rot_speed_reduce', full_name='ItemStruct.EquipItemInfo.rot_speed_reduce', index=10,
      number=11, type=2, cpp_type=6, label=1,
      has_default_value=False, default_value=float(0),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='special_effects', full_name='ItemStruct.EquipItemInfo.special_effects', index=11,
      number=12, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='beat_back', full_name='ItemStruct.EquipItemInfo.beat_back', index=12,
      number=13, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='speed_up', full_name='ItemStruct.EquipItemInfo.speed_up', index=13,
      number=14, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='slow_down', full_name='ItemStruct.EquipItemInfo.slow_down', index=14,
      number=15, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='can_fly', full_name='ItemStruct.EquipItemInfo.can_fly', index=15,
      number=16, type=8, cpp_type=7, label=1,
      has_default_value=False, default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=296,
  serialized_end=726,
)

_BASEITEMDATA.fields_by_name['item_type'].enum_type = _ITEMTYPE
_BASEITEMDATA.fields_by_name['transform'].message_type = Struct_dot_CommonStruct__pb2._NETTRANSFORM
_EQUIPITEMINFO.fields_by_name['slot'].enum_type = _EQUIPMENTSLOT
_EQUIPITEMINFO.fields_by_name['equip_type'].enum_type = _EQUIPMENTTYPE
_EQUIPITEMINFO.fields_by_name['atk_range'].message_type = Struct_dot_CommonStruct__pb2._NETVECTOR3
_EQUIPITEMINFO.fields_by_name['diff_range_atk'].message_type = Struct_dot_CommonStruct__pb2._NETVECTOR2
DESCRIPTOR.message_types_by_name['BaseItemData'] = _BASEITEMDATA
DESCRIPTOR.message_types_by_name['AiItemInfo'] = _AIITEMINFO
DESCRIPTOR.message_types_by_name['EquipItemInfo'] = _EQUIPITEMINFO
DESCRIPTOR.enum_types_by_name['ItemType'] = _ITEMTYPE
DESCRIPTOR.enum_types_by_name['EquipmentSlot'] = _EQUIPMENTSLOT
DESCRIPTOR.enum_types_by_name['EquipmentType'] = _EQUIPMENTTYPE
DESCRIPTOR.enum_types_by_name['SpecialEffects'] = _SPECIALEFFECTS
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

BaseItemData = _reflection.GeneratedProtocolMessageType('BaseItemData', (_message.Message,), {
  'DESCRIPTOR' : _BASEITEMDATA,
  '__module__' : 'Struct.ItemStruct_pb2'
  # @@protoc_insertion_point(class_scope:ItemStruct.BaseItemData)
  })
_sym_db.RegisterMessage(BaseItemData)

AiItemInfo = _reflection.GeneratedProtocolMessageType('AiItemInfo', (_message.Message,), {
  'DESCRIPTOR' : _AIITEMINFO,
  '__module__' : 'Struct.ItemStruct_pb2'
  # @@protoc_insertion_point(class_scope:ItemStruct.AiItemInfo)
  })
_sym_db.RegisterMessage(AiItemInfo)

EquipItemInfo = _reflection.GeneratedProtocolMessageType('EquipItemInfo', (_message.Message,), {
  'DESCRIPTOR' : _EQUIPITEMINFO,
  '__module__' : 'Struct.ItemStruct_pb2'
  # @@protoc_insertion_point(class_scope:ItemStruct.EquipItemInfo)
  })
_sym_db.RegisterMessage(EquipItemInfo)


# @@protoc_insertion_point(module_scope)
