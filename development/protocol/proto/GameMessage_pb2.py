# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: GameMessage.proto

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
  name='GameMessage.proto',
  package='GameMessage',
  syntax='proto3',
  serialized_options=None,
  serialized_pb=_b('\n\x11GameMessage.proto\x12\x0bGameMessage\x1a\x19Struct/CommonStruct.proto\"<\n\x13PlayerOnlineRequest\x12\x0b\n\x03rid\x18\x01 \x01(\x05\x12\x0b\n\x03\x65id\x18\x02 \x01(\x05\x12\x0b\n\x03uid\x18\x03 \x01(\x05\"3\n\x14PlayerOnlineResponse\x12\x0e\n\x06result\x18\x01 \x01(\x05\x12\x0b\n\x03\x65id\x18\x02 \x01(\x05\"\xaa\x01\n\x0cPullResponse\x12\x0e\n\x06result\x18\x01 \x01(\x05\x12,\n\x07players\x18\x02 \x03(\x0b\x32\x1b.CommonStruct.NetPlayerData\x12*\n\x06robots\x18\x03 \x03(\x0b\x32\x1a.CommonStruct.NetRobotData\x12\x30\n\tcomputers\x18\x04 \x03(\x0b\x32\x1d.CommonStruct.NetComputerData*J\n\tproto_ids\x12\x0f\n\x0b\x45MPTY_PROTO\x10\x00\x12\x10\n\x0cGAME_SERVICE\x10\x10\x12\x10\n\x0cPLAYERONLINE\x10\x01\x12\x08\n\x04PULL\x10\x02\x62\x06proto3')
  ,
  dependencies=[Struct_dot_CommonStruct__pb2.DESCRIPTOR,])

_PROTO_IDS = _descriptor.EnumDescriptor(
  name='proto_ids',
  full_name='GameMessage.proto_ids',
  filename=None,
  file=DESCRIPTOR,
  values=[
    _descriptor.EnumValueDescriptor(
      name='EMPTY_PROTO', index=0, number=0,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='GAME_SERVICE', index=1, number=16,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='PLAYERONLINE', index=2, number=1,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='PULL', index=3, number=2,
      serialized_options=None,
      type=None),
  ],
  containing_type=None,
  serialized_options=None,
  serialized_start=349,
  serialized_end=423,
)
_sym_db.RegisterEnumDescriptor(_PROTO_IDS)

proto_ids = enum_type_wrapper.EnumTypeWrapper(_PROTO_IDS)
EMPTY_PROTO = 0
GAME_SERVICE = 16
PLAYERONLINE = 1
PULL = 2



_PLAYERONLINEREQUEST = _descriptor.Descriptor(
  name='PlayerOnlineRequest',
  full_name='GameMessage.PlayerOnlineRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='rid', full_name='GameMessage.PlayerOnlineRequest.rid', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='eid', full_name='GameMessage.PlayerOnlineRequest.eid', index=1,
      number=2, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='uid', full_name='GameMessage.PlayerOnlineRequest.uid', index=2,
      number=3, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
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
  serialized_start=61,
  serialized_end=121,
)


_PLAYERONLINERESPONSE = _descriptor.Descriptor(
  name='PlayerOnlineResponse',
  full_name='GameMessage.PlayerOnlineResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='result', full_name='GameMessage.PlayerOnlineResponse.result', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='eid', full_name='GameMessage.PlayerOnlineResponse.eid', index=1,
      number=2, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
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
  serialized_start=123,
  serialized_end=174,
)


_PULLRESPONSE = _descriptor.Descriptor(
  name='PullResponse',
  full_name='GameMessage.PullResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='result', full_name='GameMessage.PullResponse.result', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='players', full_name='GameMessage.PullResponse.players', index=1,
      number=2, type=11, cpp_type=10, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='robots', full_name='GameMessage.PullResponse.robots', index=2,
      number=3, type=11, cpp_type=10, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='computers', full_name='GameMessage.PullResponse.computers', index=3,
      number=4, type=11, cpp_type=10, label=3,
      has_default_value=False, default_value=[],
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
  serialized_start=177,
  serialized_end=347,
)

_PULLRESPONSE.fields_by_name['players'].message_type = Struct_dot_CommonStruct__pb2._NETPLAYERDATA
_PULLRESPONSE.fields_by_name['robots'].message_type = Struct_dot_CommonStruct__pb2._NETROBOTDATA
_PULLRESPONSE.fields_by_name['computers'].message_type = Struct_dot_CommonStruct__pb2._NETCOMPUTERDATA
DESCRIPTOR.message_types_by_name['PlayerOnlineRequest'] = _PLAYERONLINEREQUEST
DESCRIPTOR.message_types_by_name['PlayerOnlineResponse'] = _PLAYERONLINERESPONSE
DESCRIPTOR.message_types_by_name['PullResponse'] = _PULLRESPONSE
DESCRIPTOR.enum_types_by_name['proto_ids'] = _PROTO_IDS
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

PlayerOnlineRequest = _reflection.GeneratedProtocolMessageType('PlayerOnlineRequest', (_message.Message,), {
  'DESCRIPTOR' : _PLAYERONLINEREQUEST,
  '__module__' : 'GameMessage_pb2'
  # @@protoc_insertion_point(class_scope:GameMessage.PlayerOnlineRequest)
  })
_sym_db.RegisterMessage(PlayerOnlineRequest)

PlayerOnlineResponse = _reflection.GeneratedProtocolMessageType('PlayerOnlineResponse', (_message.Message,), {
  'DESCRIPTOR' : _PLAYERONLINERESPONSE,
  '__module__' : 'GameMessage_pb2'
  # @@protoc_insertion_point(class_scope:GameMessage.PlayerOnlineResponse)
  })
_sym_db.RegisterMessage(PlayerOnlineResponse)

PullResponse = _reflection.GeneratedProtocolMessageType('PullResponse', (_message.Message,), {
  'DESCRIPTOR' : _PULLRESPONSE,
  '__module__' : 'GameMessage_pb2'
  # @@protoc_insertion_point(class_scope:GameMessage.PullResponse)
  })
_sym_db.RegisterMessage(PullResponse)


# @@protoc_insertion_point(module_scope)