# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: ProtocolMessage.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='ProtocolMessage.proto',
  package='ProtocolMessage',
  syntax='proto3',
  serialized_options=None,
  serialized_pb=_b('\n\x15ProtocolMessage.proto\x12\x0fProtocolMessage\"4\n\x0cProtoMessage\x12\x10\n\x08proto_id\x18\x01 \x01(\x05\x12\x12\n\nproto_data\x18\x02 \x01(\x0c\x62\x06proto3')
)




_PROTOMESSAGE = _descriptor.Descriptor(
  name='ProtoMessage',
  full_name='ProtocolMessage.ProtoMessage',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='proto_id', full_name='ProtocolMessage.ProtoMessage.proto_id', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='proto_data', full_name='ProtocolMessage.ProtoMessage.proto_data', index=1,
      number=2, type=12, cpp_type=9, label=1,
      has_default_value=False, default_value=_b(""),
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
  serialized_start=42,
  serialized_end=94,
)

DESCRIPTOR.message_types_by_name['ProtoMessage'] = _PROTOMESSAGE
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

ProtoMessage = _reflection.GeneratedProtocolMessageType('ProtoMessage', (_message.Message,), {
  'DESCRIPTOR' : _PROTOMESSAGE,
  '__module__' : 'ProtocolMessage_pb2'
  # @@protoc_insertion_point(class_scope:ProtocolMessage.ProtoMessage)
  })
_sym_db.RegisterMessage(ProtoMessage)


# @@protoc_insertion_point(module_scope)