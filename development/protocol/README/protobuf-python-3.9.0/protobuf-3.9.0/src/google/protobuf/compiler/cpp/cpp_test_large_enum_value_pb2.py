# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: cpp_test_large_enum_value.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='cpp_test_large_enum_value.proto',
  package='protobuf_unittest',
  syntax='proto2',
  serialized_options=None,
  serialized_pb=_b('\n\x1f\x63pp_test_large_enum_value.proto\x12\x11protobuf_unittest\"J\n\x12TestLargeEnumValue\"4\n\x12\x45numWithLargeValue\x12\x0b\n\x07VALUE_1\x10\x01\x12\x11\n\tVALUE_MAX\x10\xff\xff\xff\xff\x07')
)



_TESTLARGEENUMVALUE_ENUMWITHLARGEVALUE = _descriptor.EnumDescriptor(
  name='EnumWithLargeValue',
  full_name='protobuf_unittest.TestLargeEnumValue.EnumWithLargeValue',
  filename=None,
  file=DESCRIPTOR,
  values=[
    _descriptor.EnumValueDescriptor(
      name='VALUE_1', index=0, number=1,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='VALUE_MAX', index=1, number=2147483647,
      serialized_options=None,
      type=None),
  ],
  containing_type=None,
  serialized_options=None,
  serialized_start=76,
  serialized_end=128,
)
_sym_db.RegisterEnumDescriptor(_TESTLARGEENUMVALUE_ENUMWITHLARGEVALUE)


_TESTLARGEENUMVALUE = _descriptor.Descriptor(
  name='TestLargeEnumValue',
  full_name='protobuf_unittest.TestLargeEnumValue',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
    _TESTLARGEENUMVALUE_ENUMWITHLARGEVALUE,
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto2',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=54,
  serialized_end=128,
)

_TESTLARGEENUMVALUE_ENUMWITHLARGEVALUE.containing_type = _TESTLARGEENUMVALUE
DESCRIPTOR.message_types_by_name['TestLargeEnumValue'] = _TESTLARGEENUMVALUE
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

TestLargeEnumValue = _reflection.GeneratedProtocolMessageType('TestLargeEnumValue', (_message.Message,), {
  'DESCRIPTOR' : _TESTLARGEENUMVALUE,
  '__module__' : 'cpp_test_large_enum_value_pb2'
  # @@protoc_insertion_point(class_scope:protobuf_unittest.TestLargeEnumValue)
  })
_sym_db.RegisterMessage(TestLargeEnumValue)


# @@protoc_insertion_point(module_scope)