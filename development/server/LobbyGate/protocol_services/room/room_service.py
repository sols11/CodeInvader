# -*- coding:utf-8 -*-
# @Time        : 2019/8/14 21:04
# @Author      : wuzelin@corp.netease.com
# @File        : room_service.py
# @Description : 
# @API         : TODO

import grpc
from config import GRPC_HOST, GRPC_PORT
from protocol_services.base_service import BaseService
from protocol_services.protobuf_msg.pb2 import UserRoomMessage_pb2
from protocol_services.protobuf_msg.pb2_grpc import UserRoomMessage_pb2_grpc
from protocol_services.dispatcher import Dispatcher


class RoomService(BaseService):
    """

    """
    def __init__(self):
        super(RoomService, self).__init__(UserRoomMessage_pb2.ROOM_SERVICE)
        channel = grpc.insecure_channel("%s:%s" % (GRPC_HOST, GRPC_PORT))
        self.stub = UserRoomMessage_pb2_grpc.UserRoomStub(channel)

    def init(self):
        self.register(UserRoomMessage_pb2.CID_BUILD_ROOM, self.build_room)
        self.register(UserRoomMessage_pb2.CID_ENTER_ROOM, self.enter_room)
        self.register(UserRoomMessage_pb2.CID_EXIT_ROOM, self.exit_room)
        self.register(UserRoomMessage_pb2.CID_START_GAME, self.start_game)
        self.register(UserRoomMessage_pb2.CID_GET_ROOMS, self.get_rooms)
        self.register(UserRoomMessage_pb2.CID_GET_ROOM_BY_RID, self.get_room_by_rid)

    def build_room(self, msg):
        build_room_request = self.unpack(UserRoomMessage_pb2.UserBuildRoomRequest, msg.data)
        build_room_response = self.stub.UserBuildRoom(build_room_request)

        msg.hid = [msg.hid]
        msg.data = self.pack(build_room_response)
        Dispatcher().add_response(msg)

    def enter_room(self, msg):
        enter_room_request = self.unpack(UserRoomMessage_pb2.UserEnterRoomRequest, msg.data)
        enter_room_response = self.stub.UserEnterRoom(enter_room_request)
        room = enter_room_response.enter_room_obj
        _hid = msg.hid
        msg.hid = []
        for user in room.users_lst:
            msg.hid.append(user.hid)
        if not msg.hid:
            msg.hid = [_hid]
        msg.data = self.pack(enter_room_response)
        Dispatcher().add_response(msg)

    def exit_room(self, msg):
        exit_room_request = self.unpack(UserRoomMessage_pb2.UserExitRoomRequest, msg.data)
        exit_room_response = self.stub.UserExitRoom(exit_room_request)
        room = exit_room_response.exit_room_obj
        _hid = msg.hid
        msg.hid = []
        for user in room.users_lst:
            msg.hid.append(user.hid)
        if not msg.hid:
            msg.hid = [_hid]
        msg.data = self.pack(exit_room_response)
        Dispatcher().add_response(msg)

    def start_game(self, msg):
        start_game_request = self.unpack(UserRoomMessage_pb2.UserExitRoomRequest, msg.data)
        start_game_response = self.stub.UserStartGame(start_game_request)
        room = start_game_response.start_room_obj
        _hid = msg.hid
        msg.hid = []
        for user in room.users_lst:
            msg.hid.append(user.hid)
        if not msg.hid:
            msg.hid = [_hid]
        msg.data = self.pack(start_game_response)
        Dispatcher().add_response(msg)

    def get_rooms(self, msg):
        get_rooms_request = self.unpack(UserRoomMessage_pb2.GetRoomsRequest, msg.data)
        get_rooms_response = self.stub.GetRooms(get_rooms_request)

        msg.hid = [msg.hid]
        msg.data = self.pack(get_rooms_response)
        Dispatcher().add_response(msg)

    def get_room_by_rid(self, msg):
        get_room_by_rid_request = self.unpack(UserRoomMessage_pb2.GetRoomByRidRequest, msg.data)
        get_room_by_rid_response = self.stub.GetRoomByRid(get_room_by_rid_request)

        msg.hid = [msg.hid]
        msg.data = self.pack(get_room_by_rid_response)
        Dispatcher().add_response(msg)
