# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: unittest_mset_wire_format.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='unittest_mset_wire_format.proto',
  package='proto2_wireformat_unittest',
  syntax='proto2',
  serialized_options=_b('H\001\370\001\001\252\002!Google.ProtocolBuffers.TestProtos'),
  serialized_pb=_b('\n\x1funittest_mset_wire_format.proto\x12\x1aproto2_wireformat_unittest\"\x1e\n\x0eTestMessageSet*\x08\x08\x04\x10\xff\xff\xff\xff\x07:\x02\x08\x01\"d\n!TestMessageSetWireFormatContainer\x12?\n\x0bmessage_set\x18\x01 \x01(\x0b\x32*.proto2_wireformat_unittest.TestMessageSetB)H\x01\xf8\x01\x01\xaa\x02!Google.ProtocolBuffers.TestProtos')
)




_TESTMESSAGESET = _descriptor.Descriptor(
  name='TestMessageSet',
  full_name='proto2_wireformat_unittest.TestMessageSet',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=_b('\010\001'),
  is_extendable=True,
  syntax='proto2',
  extension_ranges=[(4, 2147483647), ],
  oneofs=[
  ],
  serialized_start=63,
  serialized_end=93,
)


_TESTMESSAGESETWIREFORMATCONTAINER = _descriptor.Descriptor(
  name='TestMessageSetWireFormatContainer',
  full_name='proto2_wireformat_unittest.TestMessageSetWireFormatContainer',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='message_set', full_name='proto2_wireformat_unittest.TestMessageSetWireFormatContainer.message_set', index=0,
      number=1, type=11, cpp_type=10, label=1,
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
  syntax='proto2',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=95,
  serialized_end=195,
)

_TESTMESSAGESETWIREFORMATCONTAINER.fields_by_name['message_set'].message_type = _TESTMESSAGESET
DESCRIPTOR.message_types_by_name['TestMessageSet'] = _TESTMESSAGESET
DESCRIPTOR.message_types_by_name['TestMessageSetWireFormatContainer'] = _TESTMESSAGESETWIREFORMATCONTAINER
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

TestMessageSet = _reflection.GeneratedProtocolMessageType('TestMessageSet', (_message.Message,), {
  'DESCRIPTOR' : _TESTMESSAGESET,
  '__module__' : 'unittest_mset_wire_format_pb2'
  # @@protoc_insertion_point(class_scope:proto2_wireformat_unittest.TestMessageSet)
  })
_sym_db.RegisterMessage(TestMessageSet)

TestMessageSetWireFormatContainer = _reflection.GeneratedProtocolMessageType('TestMessageSetWireFormatContainer', (_message.Message,), {
  'DESCRIPTOR' : _TESTMESSAGESETWIREFORMATCONTAINER,
  '__module__' : 'unittest_mset_wire_format_pb2'
  # @@protoc_insertion_point(class_scope:proto2_wireformat_unittest.TestMessageSetWireFormatContainer)
  })
_sym_db.RegisterMessage(TestMessageSetWireFormatContainer)


DESCRIPTOR._options = None
_TESTMESSAGESET._options = None
# @@protoc_insertion_point(module_scope)
