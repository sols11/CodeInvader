# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: unittest_import_public.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='unittest_import_public.proto',
  package='protobuf_unittest_import',
  syntax='proto2',
  serialized_options=_b('\n\030com.google.protobuf.test'),
  serialized_pb=_b('\n\x1cunittest_import_public.proto\x12\x18protobuf_unittest_import\" \n\x13PublicImportMessage\x12\t\n\x01\x65\x18\x01 \x01(\x05\x42\x1a\n\x18\x63om.google.protobuf.test')
)




_PUBLICIMPORTMESSAGE = _descriptor.Descriptor(
  name='PublicImportMessage',
  full_name='protobuf_unittest_import.PublicImportMessage',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='e', full_name='protobuf_unittest_import.PublicImportMessage.e', index=0,
      number=1, type=5, cpp_type=1, label=1,
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
  syntax='proto2',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=58,
  serialized_end=90,
)

DESCRIPTOR.message_types_by_name['PublicImportMessage'] = _PUBLICIMPORTMESSAGE
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

PublicImportMessage = _reflection.GeneratedProtocolMessageType('PublicImportMessage', (_message.Message,), {
  'DESCRIPTOR' : _PUBLICIMPORTMESSAGE,
  '__module__' : 'unittest_import_public_pb2'
  # @@protoc_insertion_point(class_scope:protobuf_unittest_import.PublicImportMessage)
  })
_sym_db.RegisterMessage(PublicImportMessage)


DESCRIPTOR._options = None
# @@protoc_insertion_point(module_scope)
