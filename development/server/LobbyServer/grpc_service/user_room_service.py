# -*- coding:utf-8 -*-
# @Time        : 2019/8/13 14:35
# @Author      : liyihang@corp.netease.com
# @File        : user_room_service.py
# @Description : 
# @API         :
from config import result_conf
from grpc_service.pb2.UserRoomMessage_pb2 import *
from grpc_service.pb2_grpc.UserRoomMessage_pb2_grpc import UserRoomServicer, add_UserRoomServicer_to_server
from grpc_service.base_service import BaseService
from lobby.virtual_room.virtual_room_mgr import VirtualRoomMgr


class UserRoomService(UserRoomServicer, BaseService):

    def UserBuildRoom(self, request, context):
        room_mgr = VirtualRoomMgr()
        result, new_room_dict = room_mgr.user_build_room(request)
        return UserBuildRoomResponse(result=result, new_room_obj=self._construction_room_object(new_room_dict))

    def UserEnterRoom(self, request, context):
        room_mgr = VirtualRoomMgr()
        result, enter_room_dict = room_mgr.user_enter_room(request)
        return UserEnterRoomResponse(result=result, enter_room_obj=self._construction_room_object(enter_room_dict))

    def UserExitRoom(self, request, context):
        room_mgr = VirtualRoomMgr()
        result, exit_room_dict = room_mgr.user_exit_room(request)
        return UserExitRoomResponse(result=result, exit_room_obj=self._construction_room_object(exit_room_dict))

    def UserStartGame(self, request, context):
        room_mgr = VirtualRoomMgr()
        result, start_room_dict, address_dict = room_mgr.start_game(request)
        return UserStartGameResponse(result=result, start_room_obj=self._construction_room_object(start_room_dict),
                                     address=(AddressObject(**address_dict) if address_dict is not None else None))

    def GetRooms(self, request, context):
        room_mgr = VirtualRoomMgr()
        result, room_obj_lst = room_mgr.get_rooms(request)
        return GetRoomsResponse(result=result,
                                room_obj_lst=map(lambda room_obj_dict: self._construction_room_object(room_obj_dict),
                                                 room_obj_lst))

    def GetRoomByRid(self, request, context):
        room_mgr = VirtualRoomMgr()
        result, room_obj_dict = room_mgr.get_room_by_rid(request)
        return GetRoomByRidResponse(result=result, room_obj=self._construction_room_object(room_obj_dict))

    def register_self(self, server):
        add_UserRoomServicer_to_server(self, server)

    @staticmethod
    def _construction_room_object(room_object_dict):
        """
        解析room_object_dict为RoomObject
        :param room_object_dict: dict
        :return: RoomObject or None
        """
        if room_object_dict is None:
            return None

        room_object_dict["users_lst"] = map(lambda user_object_dict: UserObject(**user_object_dict),
                                            room_object_dict["users_lst"])
        return RoomObject(**room_object_dict)
