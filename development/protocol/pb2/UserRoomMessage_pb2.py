# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: UserRoomMessage.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf.internal import enum_type_wrapper
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='UserRoomMessage.proto',
  package='UserRoomMessage',
  syntax='proto3',
  serialized_options=None,
  serialized_pb=_b('\n\x15UserRoomMessage.proto\x12\x0fUserRoomMessage\"@\n\nUserObject\x12\x0b\n\x03uid\x18\x01 \x01(\x05\x12\x0b\n\x03hid\x18\x02 \x01(\x05\x12\x0b\n\x03rid\x18\x03 \x01(\x05\x12\x0b\n\x03gid\x18\x04 \x01(\x05\"d\n\nRoomObject\x12\x0b\n\x03rid\x18\x01 \x01(\x05\x12\x0c\n\x04name\x18\x02 \x01(\t\x12\x0b\n\x03gid\x18\x03 \x01(\x05\x12.\n\tusers_lst\x18\x04 \x03(\x0b\x32\x1b.UserRoomMessage.UserObject\")\n\rAddressObject\x12\n\n\x02ip\x18\x01 \x01(\t\x12\x0c\n\x04port\x18\x02 \x01(\x05\"6\n\x14UserBuildRoomRequest\x12\x0b\n\x03uid\x18\x01 \x01(\x05\x12\x11\n\troom_name\x18\x02 \x01(\t\"Z\n\x15UserBuildRoomResponse\x12\x0e\n\x06result\x18\x01 \x01(\x05\x12\x31\n\x0cnew_room_obj\x18\x02 \x01(\x0b\x32\x1b.UserRoomMessage.RoomObject\"0\n\x14UserEnterRoomRequest\x12\x0b\n\x03rid\x18\x01 \x01(\x05\x12\x0b\n\x03uid\x18\x02 \x01(\x05\"\\\n\x15UserEnterRoomResponse\x12\x0e\n\x06result\x18\x01 \x01(\x05\x12\x33\n\x0e\x65nter_room_obj\x18\x02 \x01(\x0b\x32\x1b.UserRoomMessage.RoomObject\"/\n\x13UserExitRoomRequest\x12\x0b\n\x03rid\x18\x01 \x01(\x05\x12\x0b\n\x03uid\x18\x02 \x01(\x05\"Z\n\x14UserExitRoomResponse\x12\x0e\n\x06result\x18\x01 \x01(\x05\x12\x32\n\rexit_room_obj\x18\x02 \x01(\x0b\x32\x1b.UserRoomMessage.RoomObject\"0\n\x14UserStartGameRequest\x12\x0b\n\x03rid\x18\x01 \x01(\x05\x12\x0b\n\x03uid\x18\x02 \x01(\x05\"\x8d\x01\n\x15UserStartGameResponse\x12\x0e\n\x06result\x18\x01 \x01(\x05\x12\x33\n\x0estart_room_obj\x18\x02 \x01(\x0b\x32\x1b.UserRoomMessage.RoomObject\x12/\n\x07\x61\x64\x64ress\x18\x03 \x01(\x0b\x32\x1e.UserRoomMessage.AddressObject\"\x1e\n\x0fGetRoomsRequest\x12\x0b\n\x03uid\x18\x01 \x01(\x05\"U\n\x10GetRoomsResponse\x12\x0e\n\x06result\x18\x01 \x01(\x05\x12\x31\n\x0croom_obj_lst\x18\x02 \x03(\x0b\x32\x1b.UserRoomMessage.RoomObject\"/\n\x13GetRoomByRidRequest\x12\x0b\n\x03rid\x18\x01 \x01(\x05\x12\x0b\n\x03uid\x18\x02 \x01(\x05\"U\n\x14GetRoomByRidResponse\x12\x0e\n\x06result\x18\x01 \x01(\x05\x12-\n\x08room_obj\x18\x02 \x01(\x0b\x32\x1b.UserRoomMessage.RoomObject*\xad\x01\n\tproto_ids\x12\x0f\n\x0b\x45MPTY_PROTO\x10\x00\x12\x10\n\x0cROOM_SERVICE\x10\x02\x12\x12\n\x0e\x43ID_BUILD_ROOM\x10\x01\x12\x12\n\x0e\x43ID_ENTER_ROOM\x10\x02\x12\x11\n\rCID_EXIT_ROOM\x10\x03\x12\x12\n\x0e\x43ID_START_GAME\x10\x04\x12\x11\n\rCID_GET_ROOMS\x10\x05\x12\x17\n\x13\x43ID_GET_ROOM_BY_RID\x10\x06\x1a\x02\x10\x01\x32\xc1\x04\n\x08UserRoom\x12`\n\rUserBuildRoom\x12%.UserRoomMessage.UserBuildRoomRequest\x1a&.UserRoomMessage.UserBuildRoomResponse\"\x00\x12`\n\rUserEnterRoom\x12%.UserRoomMessage.UserEnterRoomRequest\x1a&.UserRoomMessage.UserEnterRoomResponse\"\x00\x12]\n\x0cUserExitRoom\x12$.UserRoomMessage.UserExitRoomRequest\x1a%.UserRoomMessage.UserExitRoomResponse\"\x00\x12`\n\rUserStartGame\x12%.UserRoomMessage.UserStartGameRequest\x1a&.UserRoomMessage.UserStartGameResponse\"\x00\x12Q\n\x08GetRooms\x12 .UserRoomMessage.GetRoomsRequest\x1a!.UserRoomMessage.GetRoomsResponse\"\x00\x12]\n\x0cGetRoomByRid\x12$.UserRoomMessage.GetRoomByRidRequest\x1a%.UserRoomMessage.GetRoomByRidResponse\"\x00\x62\x06proto3')
)

_PROTO_IDS = _descriptor.EnumDescriptor(
  name='proto_ids',
  full_name='UserRoomMessage.proto_ids',
  filename=None,
  file=DESCRIPTOR,
  values=[
    _descriptor.EnumValueDescriptor(
      name='EMPTY_PROTO', index=0, number=0,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='ROOM_SERVICE', index=1, number=2,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='CID_BUILD_ROOM', index=2, number=1,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='CID_ENTER_ROOM', index=3, number=2,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='CID_EXIT_ROOM', index=4, number=3,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='CID_START_GAME', index=5, number=4,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='CID_GET_ROOMS', index=6, number=5,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='CID_GET_ROOM_BY_RID', index=7, number=6,
      serialized_options=None,
      type=None),
  ],
  containing_type=None,
  serialized_options=_b('\020\001'),
  serialized_start=1136,
  serialized_end=1309,
)
_sym_db.RegisterEnumDescriptor(_PROTO_IDS)

proto_ids = enum_type_wrapper.EnumTypeWrapper(_PROTO_IDS)
EMPTY_PROTO = 0
ROOM_SERVICE = 2
CID_BUILD_ROOM = 1
CID_ENTER_ROOM = 2
CID_EXIT_ROOM = 3
CID_START_GAME = 4
CID_GET_ROOMS = 5
CID_GET_ROOM_BY_RID = 6



_USEROBJECT = _descriptor.Descriptor(
  name='UserObject',
  full_name='UserRoomMessage.UserObject',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='uid', full_name='UserRoomMessage.UserObject.uid', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='hid', full_name='UserRoomMessage.UserObject.hid', index=1,
      number=2, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='rid', full_name='UserRoomMessage.UserObject.rid', index=2,
      number=3, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='gid', full_name='UserRoomMessage.UserObject.gid', index=3,
      number=4, type=5, cpp_type=1, label=1,
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
  serialized_start=42,
  serialized_end=106,
)


_ROOMOBJECT = _descriptor.Descriptor(
  name='RoomObject',
  full_name='UserRoomMessage.RoomObject',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='rid', full_name='UserRoomMessage.RoomObject.rid', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name', full_name='UserRoomMessage.RoomObject.name', index=1,
      number=2, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='gid', full_name='UserRoomMessage.RoomObject.gid', index=2,
      number=3, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='users_lst', full_name='UserRoomMessage.RoomObject.users_lst', index=3,
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
  serialized_start=108,
  serialized_end=208,
)


_ADDRESSOBJECT = _descriptor.Descriptor(
  name='AddressObject',
  full_name='UserRoomMessage.AddressObject',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='ip', full_name='UserRoomMessage.AddressObject.ip', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='port', full_name='UserRoomMessage.AddressObject.port', index=1,
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
  serialized_start=210,
  serialized_end=251,
)


_USERBUILDROOMREQUEST = _descriptor.Descriptor(
  name='UserBuildRoomRequest',
  full_name='UserRoomMessage.UserBuildRoomRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='uid', full_name='UserRoomMessage.UserBuildRoomRequest.uid', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='room_name', full_name='UserRoomMessage.UserBuildRoomRequest.room_name', index=1,
      number=2, type=9, cpp_type=9, label=1,
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
  serialized_start=253,
  serialized_end=307,
)


_USERBUILDROOMRESPONSE = _descriptor.Descriptor(
  name='UserBuildRoomResponse',
  full_name='UserRoomMessage.UserBuildRoomResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='result', full_name='UserRoomMessage.UserBuildRoomResponse.result', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='new_room_obj', full_name='UserRoomMessage.UserBuildRoomResponse.new_room_obj', index=1,
      number=2, type=11, cpp_type=10, label=1,
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
  serialized_start=309,
  serialized_end=399,
)


_USERENTERROOMREQUEST = _descriptor.Descriptor(
  name='UserEnterRoomRequest',
  full_name='UserRoomMessage.UserEnterRoomRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='rid', full_name='UserRoomMessage.UserEnterRoomRequest.rid', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='uid', full_name='UserRoomMessage.UserEnterRoomRequest.uid', index=1,
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
  serialized_start=401,
  serialized_end=449,
)


_USERENTERROOMRESPONSE = _descriptor.Descriptor(
  name='UserEnterRoomResponse',
  full_name='UserRoomMessage.UserEnterRoomResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='result', full_name='UserRoomMessage.UserEnterRoomResponse.result', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='enter_room_obj', full_name='UserRoomMessage.UserEnterRoomResponse.enter_room_obj', index=1,
      number=2, type=11, cpp_type=10, label=1,
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
  serialized_start=451,
  serialized_end=543,
)


_USEREXITROOMREQUEST = _descriptor.Descriptor(
  name='UserExitRoomRequest',
  full_name='UserRoomMessage.UserExitRoomRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='rid', full_name='UserRoomMessage.UserExitRoomRequest.rid', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='uid', full_name='UserRoomMessage.UserExitRoomRequest.uid', index=1,
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
  serialized_start=545,
  serialized_end=592,
)


_USEREXITROOMRESPONSE = _descriptor.Descriptor(
  name='UserExitRoomResponse',
  full_name='UserRoomMessage.UserExitRoomResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='result', full_name='UserRoomMessage.UserExitRoomResponse.result', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='exit_room_obj', full_name='UserRoomMessage.UserExitRoomResponse.exit_room_obj', index=1,
      number=2, type=11, cpp_type=10, label=1,
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
  serialized_start=594,
  serialized_end=684,
)


_USERSTARTGAMEREQUEST = _descriptor.Descriptor(
  name='UserStartGameRequest',
  full_name='UserRoomMessage.UserStartGameRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='rid', full_name='UserRoomMessage.UserStartGameRequest.rid', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='uid', full_name='UserRoomMessage.UserStartGameRequest.uid', index=1,
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
  serialized_start=686,
  serialized_end=734,
)


_USERSTARTGAMERESPONSE = _descriptor.Descriptor(
  name='UserStartGameResponse',
  full_name='UserRoomMessage.UserStartGameResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='result', full_name='UserRoomMessage.UserStartGameResponse.result', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='start_room_obj', full_name='UserRoomMessage.UserStartGameResponse.start_room_obj', index=1,
      number=2, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='address', full_name='UserRoomMessage.UserStartGameResponse.address', index=2,
      number=3, type=11, cpp_type=10, label=1,
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
  serialized_start=737,
  serialized_end=878,
)


_GETROOMSREQUEST = _descriptor.Descriptor(
  name='GetRoomsRequest',
  full_name='UserRoomMessage.GetRoomsRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='uid', full_name='UserRoomMessage.GetRoomsRequest.uid', index=0,
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
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=880,
  serialized_end=910,
)


_GETROOMSRESPONSE = _descriptor.Descriptor(
  name='GetRoomsResponse',
  full_name='UserRoomMessage.GetRoomsResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='result', full_name='UserRoomMessage.GetRoomsResponse.result', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='room_obj_lst', full_name='UserRoomMessage.GetRoomsResponse.room_obj_lst', index=1,
      number=2, type=11, cpp_type=10, label=3,
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
  serialized_start=912,
  serialized_end=997,
)


_GETROOMBYRIDREQUEST = _descriptor.Descriptor(
  name='GetRoomByRidRequest',
  full_name='UserRoomMessage.GetRoomByRidRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='rid', full_name='UserRoomMessage.GetRoomByRidRequest.rid', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='uid', full_name='UserRoomMessage.GetRoomByRidRequest.uid', index=1,
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
  serialized_start=999,
  serialized_end=1046,
)


_GETROOMBYRIDRESPONSE = _descriptor.Descriptor(
  name='GetRoomByRidResponse',
  full_name='UserRoomMessage.GetRoomByRidResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='result', full_name='UserRoomMessage.GetRoomByRidResponse.result', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='room_obj', full_name='UserRoomMessage.GetRoomByRidResponse.room_obj', index=1,
      number=2, type=11, cpp_type=10, label=1,
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
  serialized_start=1048,
  serialized_end=1133,
)

_ROOMOBJECT.fields_by_name['users_lst'].message_type = _USEROBJECT
_USERBUILDROOMRESPONSE.fields_by_name['new_room_obj'].message_type = _ROOMOBJECT
_USERENTERROOMRESPONSE.fields_by_name['enter_room_obj'].message_type = _ROOMOBJECT
_USEREXITROOMRESPONSE.fields_by_name['exit_room_obj'].message_type = _ROOMOBJECT
_USERSTARTGAMERESPONSE.fields_by_name['start_room_obj'].message_type = _ROOMOBJECT
_USERSTARTGAMERESPONSE.fields_by_name['address'].message_type = _ADDRESSOBJECT
_GETROOMSRESPONSE.fields_by_name['room_obj_lst'].message_type = _ROOMOBJECT
_GETROOMBYRIDRESPONSE.fields_by_name['room_obj'].message_type = _ROOMOBJECT
DESCRIPTOR.message_types_by_name['UserObject'] = _USEROBJECT
DESCRIPTOR.message_types_by_name['RoomObject'] = _ROOMOBJECT
DESCRIPTOR.message_types_by_name['AddressObject'] = _ADDRESSOBJECT
DESCRIPTOR.message_types_by_name['UserBuildRoomRequest'] = _USERBUILDROOMREQUEST
DESCRIPTOR.message_types_by_name['UserBuildRoomResponse'] = _USERBUILDROOMRESPONSE
DESCRIPTOR.message_types_by_name['UserEnterRoomRequest'] = _USERENTERROOMREQUEST
DESCRIPTOR.message_types_by_name['UserEnterRoomResponse'] = _USERENTERROOMRESPONSE
DESCRIPTOR.message_types_by_name['UserExitRoomRequest'] = _USEREXITROOMREQUEST
DESCRIPTOR.message_types_by_name['UserExitRoomResponse'] = _USEREXITROOMRESPONSE
DESCRIPTOR.message_types_by_name['UserStartGameRequest'] = _USERSTARTGAMEREQUEST
DESCRIPTOR.message_types_by_name['UserStartGameResponse'] = _USERSTARTGAMERESPONSE
DESCRIPTOR.message_types_by_name['GetRoomsRequest'] = _GETROOMSREQUEST
DESCRIPTOR.message_types_by_name['GetRoomsResponse'] = _GETROOMSRESPONSE
DESCRIPTOR.message_types_by_name['GetRoomByRidRequest'] = _GETROOMBYRIDREQUEST
DESCRIPTOR.message_types_by_name['GetRoomByRidResponse'] = _GETROOMBYRIDRESPONSE
DESCRIPTOR.enum_types_by_name['proto_ids'] = _PROTO_IDS
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

UserObject = _reflection.GeneratedProtocolMessageType('UserObject', (_message.Message,), {
  'DESCRIPTOR' : _USEROBJECT,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.UserObject)
  })
_sym_db.RegisterMessage(UserObject)

RoomObject = _reflection.GeneratedProtocolMessageType('RoomObject', (_message.Message,), {
  'DESCRIPTOR' : _ROOMOBJECT,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.RoomObject)
  })
_sym_db.RegisterMessage(RoomObject)

AddressObject = _reflection.GeneratedProtocolMessageType('AddressObject', (_message.Message,), {
  'DESCRIPTOR' : _ADDRESSOBJECT,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.AddressObject)
  })
_sym_db.RegisterMessage(AddressObject)

UserBuildRoomRequest = _reflection.GeneratedProtocolMessageType('UserBuildRoomRequest', (_message.Message,), {
  'DESCRIPTOR' : _USERBUILDROOMREQUEST,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.UserBuildRoomRequest)
  })
_sym_db.RegisterMessage(UserBuildRoomRequest)

UserBuildRoomResponse = _reflection.GeneratedProtocolMessageType('UserBuildRoomResponse', (_message.Message,), {
  'DESCRIPTOR' : _USERBUILDROOMRESPONSE,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.UserBuildRoomResponse)
  })
_sym_db.RegisterMessage(UserBuildRoomResponse)

UserEnterRoomRequest = _reflection.GeneratedProtocolMessageType('UserEnterRoomRequest', (_message.Message,), {
  'DESCRIPTOR' : _USERENTERROOMREQUEST,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.UserEnterRoomRequest)
  })
_sym_db.RegisterMessage(UserEnterRoomRequest)

UserEnterRoomResponse = _reflection.GeneratedProtocolMessageType('UserEnterRoomResponse', (_message.Message,), {
  'DESCRIPTOR' : _USERENTERROOMRESPONSE,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.UserEnterRoomResponse)
  })
_sym_db.RegisterMessage(UserEnterRoomResponse)

UserExitRoomRequest = _reflection.GeneratedProtocolMessageType('UserExitRoomRequest', (_message.Message,), {
  'DESCRIPTOR' : _USEREXITROOMREQUEST,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.UserExitRoomRequest)
  })
_sym_db.RegisterMessage(UserExitRoomRequest)

UserExitRoomResponse = _reflection.GeneratedProtocolMessageType('UserExitRoomResponse', (_message.Message,), {
  'DESCRIPTOR' : _USEREXITROOMRESPONSE,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.UserExitRoomResponse)
  })
_sym_db.RegisterMessage(UserExitRoomResponse)

UserStartGameRequest = _reflection.GeneratedProtocolMessageType('UserStartGameRequest', (_message.Message,), {
  'DESCRIPTOR' : _USERSTARTGAMEREQUEST,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.UserStartGameRequest)
  })
_sym_db.RegisterMessage(UserStartGameRequest)

UserStartGameResponse = _reflection.GeneratedProtocolMessageType('UserStartGameResponse', (_message.Message,), {
  'DESCRIPTOR' : _USERSTARTGAMERESPONSE,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.UserStartGameResponse)
  })
_sym_db.RegisterMessage(UserStartGameResponse)

GetRoomsRequest = _reflection.GeneratedProtocolMessageType('GetRoomsRequest', (_message.Message,), {
  'DESCRIPTOR' : _GETROOMSREQUEST,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.GetRoomsRequest)
  })
_sym_db.RegisterMessage(GetRoomsRequest)

GetRoomsResponse = _reflection.GeneratedProtocolMessageType('GetRoomsResponse', (_message.Message,), {
  'DESCRIPTOR' : _GETROOMSRESPONSE,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.GetRoomsResponse)
  })
_sym_db.RegisterMessage(GetRoomsResponse)

GetRoomByRidRequest = _reflection.GeneratedProtocolMessageType('GetRoomByRidRequest', (_message.Message,), {
  'DESCRIPTOR' : _GETROOMBYRIDREQUEST,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.GetRoomByRidRequest)
  })
_sym_db.RegisterMessage(GetRoomByRidRequest)

GetRoomByRidResponse = _reflection.GeneratedProtocolMessageType('GetRoomByRidResponse', (_message.Message,), {
  'DESCRIPTOR' : _GETROOMBYRIDRESPONSE,
  '__module__' : 'UserRoomMessage_pb2'
  # @@protoc_insertion_point(class_scope:UserRoomMessage.GetRoomByRidResponse)
  })
_sym_db.RegisterMessage(GetRoomByRidResponse)


_PROTO_IDS._options = None

_USERROOM = _descriptor.ServiceDescriptor(
  name='UserRoom',
  full_name='UserRoomMessage.UserRoom',
  file=DESCRIPTOR,
  index=0,
  serialized_options=None,
  serialized_start=1312,
  serialized_end=1889,
  methods=[
  _descriptor.MethodDescriptor(
    name='UserBuildRoom',
    full_name='UserRoomMessage.UserRoom.UserBuildRoom',
    index=0,
    containing_service=None,
    input_type=_USERBUILDROOMREQUEST,
    output_type=_USERBUILDROOMRESPONSE,
    serialized_options=None,
  ),
  _descriptor.MethodDescriptor(
    name='UserEnterRoom',
    full_name='UserRoomMessage.UserRoom.UserEnterRoom',
    index=1,
    containing_service=None,
    input_type=_USERENTERROOMREQUEST,
    output_type=_USERENTERROOMRESPONSE,
    serialized_options=None,
  ),
  _descriptor.MethodDescriptor(
    name='UserExitRoom',
    full_name='UserRoomMessage.UserRoom.UserExitRoom',
    index=2,
    containing_service=None,
    input_type=_USEREXITROOMREQUEST,
    output_type=_USEREXITROOMRESPONSE,
    serialized_options=None,
  ),
  _descriptor.MethodDescriptor(
    name='UserStartGame',
    full_name='UserRoomMessage.UserRoom.UserStartGame',
    index=3,
    containing_service=None,
    input_type=_USERSTARTGAMEREQUEST,
    output_type=_USERSTARTGAMERESPONSE,
    serialized_options=None,
  ),
  _descriptor.MethodDescriptor(
    name='GetRooms',
    full_name='UserRoomMessage.UserRoom.GetRooms',
    index=4,
    containing_service=None,
    input_type=_GETROOMSREQUEST,
    output_type=_GETROOMSRESPONSE,
    serialized_options=None,
  ),
  _descriptor.MethodDescriptor(
    name='GetRoomByRid',
    full_name='UserRoomMessage.UserRoom.GetRoomByRid',
    index=5,
    containing_service=None,
    input_type=_GETROOMBYRIDREQUEST,
    output_type=_GETROOMBYRIDRESPONSE,
    serialized_options=None,
  ),
])
_sym_db.RegisterServiceDescriptor(_USERROOM)

DESCRIPTOR.services_by_name['UserRoom'] = _USERROOM

# @@protoc_insertion_point(module_scope)