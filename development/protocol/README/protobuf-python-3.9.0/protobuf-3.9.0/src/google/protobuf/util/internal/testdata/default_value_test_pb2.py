# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: default_value_test.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='default_value_test.proto',
  package='proto_util_converter.testing',
  syntax='proto3',
  serialized_options=None,
  serialized_pb=_b('\n\x18\x64\x65\x66\x61ult_value_test.proto\x12\x1cproto_util_converter.testing\"\xff\x02\n\x10\x44\x65\x66\x61ultValueTest\x12\x14\n\x0c\x64ouble_value\x18\x01 \x01(\x01\x12\x17\n\x0frepeated_double\x18\x02 \x03(\x01\x12\x13\n\x0b\x66loat_value\x18\x03 \x01(\x02\x12\x13\n\x0bint64_value\x18\x05 \x01(\x03\x12\x14\n\x0cuint64_value\x18\x07 \x01(\x04\x12\x13\n\x0bint32_value\x18\t \x01(\x05\x12\x14\n\x0cuint32_value\x18\x0b \x01(\r\x12\x12\n\nbool_value\x18\r \x01(\x08\x12\x14\n\x0cstring_value\x18\x0f \x01(\t\x12\x17\n\x0b\x62ytes_value\x18\x11 \x01(\x0c\x42\x02\x08\x01\x12N\n\nenum_value\x18\x12 \x01(\x0e\x32:.proto_util_converter.testing.DefaultValueTest.EnumDefault\">\n\x0b\x45numDefault\x12\x0e\n\nENUM_FIRST\x10\x00\x12\x0f\n\x0b\x45NUM_SECOND\x10\x01\x12\x0e\n\nENUM_THIRD\x10\x02\x62\x06proto3')
)



_DEFAULTVALUETEST_ENUMDEFAULT = _descriptor.EnumDescriptor(
  name='EnumDefault',
  full_name='proto_util_converter.testing.DefaultValueTest.EnumDefault',
  filename=None,
  file=DESCRIPTOR,
  values=[
    _descriptor.EnumValueDescriptor(
      name='ENUM_FIRST', index=0, number=0,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='ENUM_SECOND', index=1, number=1,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='ENUM_THIRD', index=2, number=2,
      serialized_options=None,
      type=None),
  ],
  containing_type=None,
  serialized_options=None,
  serialized_start=380,
  serialized_end=442,
)
_sym_db.RegisterEnumDescriptor(_DEFAULTVALUETEST_ENUMDEFAULT)


_DEFAULTVALUETEST = _descriptor.Descriptor(
  name='DefaultValueTest',
  full_name='proto_util_converter.testing.DefaultValueTest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='double_value', full_name='proto_util_converter.testing.DefaultValueTest.double_value', index=0,
      number=1, type=1, cpp_type=5, label=1,
      has_default_value=False, default_value=float(0),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='repeated_double', full_name='proto_util_converter.testing.DefaultValueTest.repeated_double', index=1,
      number=2, type=1, cpp_type=5, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='float_value', full_name='proto_util_converter.testing.DefaultValueTest.float_value', index=2,
      number=3, type=2, cpp_type=6, label=1,
      has_default_value=False, default_value=float(0),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='int64_value', full_name='proto_util_converter.testing.DefaultValueTest.int64_value', index=3,
      number=5, type=3, cpp_type=2, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='uint64_value', full_name='proto_util_converter.testing.DefaultValueTest.uint64_value', index=4,
      number=7, type=4, cpp_type=4, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='int32_value', full_name='proto_util_converter.testing.DefaultValueTest.int32_value', index=5,
      number=9, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='uint32_value', full_name='proto_util_converter.testing.DefaultValueTest.uint32_value', index=6,
      number=11, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='bool_value', full_name='proto_util_converter.testing.DefaultValueTest.bool_value', index=7,
      number=13, type=8, cpp_type=7, label=1,
      has_default_value=False, default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='string_value', full_name='proto_util_converter.testing.DefaultValueTest.string_value', index=8,
      number=15, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='bytes_value', full_name='proto_util_converter.testing.DefaultValueTest.bytes_value', index=9,
      number=17, type=12, cpp_type=9, label=1,
      has_default_value=False, default_value=_b(""),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=_b('\010\001'), file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='enum_value', full_name='proto_util_converter.testing.DefaultValueTest.enum_value', index=10,
      number=18, type=14, cpp_type=8, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
    _DEFAULTVALUETEST_ENUMDEFAULT,
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=59,
  serialized_end=442,
)

_DEFAULTVALUETEST.fields_by_name['enum_value'].enum_type = _DEFAULTVALUETEST_ENUMDEFAULT
_DEFAULTVALUETEST_ENUMDEFAULT.containing_type = _DEFAULTVALUETEST
DESCRIPTOR.message_types_by_name['DefaultValueTest'] = _DEFAULTVALUETEST
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

DefaultValueTest = _reflection.GeneratedProtocolMessageType('DefaultValueTest', (_message.Message,), {
  'DESCRIPTOR' : _DEFAULTVALUETEST,
  '__module__' : 'default_value_test_pb2'
  # @@protoc_insertion_point(class_scope:proto_util_converter.testing.DefaultValueTest)
  })
_sym_db.RegisterMessage(DefaultValueTest)


_DEFAULTVALUETEST.fields_by_name['bytes_value']._options = None
# @@protoc_insertion_point(module_scope)
