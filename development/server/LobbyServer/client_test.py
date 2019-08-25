# -*- coding:utf-8 -*-
# @Time        : 2019/8/12 20:42
# @Author      : liyihang@corp.netease.com
# @File        : client_test.py
# @Description : 
# @API         :


import grpc
from google.protobuf.internal.python_message import _FieldProperty

from grpc_service.pb2.AccountMessage_pb2 import LoginRequest
from grpc_service.pb2.GameServerMessage_pb2 import *
from grpc_service.pb2.UserRoomMessage_pb2 import *
from grpc_service.pb2_grpc.AccountMessage_pb2_grpc import AccountStub
from grpc_service.pb2_grpc.GameServerMessage_pb2_grpc import GameServerStub
from grpc_service.pb2_grpc.UserRoomMessage_pb2_grpc import UserRoomStub


def main():
    channel = grpc.insecure_channel('localhost:50505')

    # account_stub = AccountStub(channel)
    # login_response = account_stub.login(LoginRequest(user_name="123", password="123"))
    # if login_response.result == 1:
    #     print "Login ok"

    game_server_stub = GameServerStub(channel)
    server_register_response = game_server_stub.ServerRegister(ServerRegisterRequest(gid=1, ip='0.0.0.0', port=11111))
    if server_register_response.result == 0:
        print "Server register ok"
    server_update_response = game_server_stub.ServerUpdate(ServerUpdateRequest(gid=1, sleep_total_time=2.0))
    if server_update_response.result == 0:
        print "Server update ok"
    else:
        print "Server update fail"

    user_room_stub = UserRoomStub(channel)
    user_build_response = user_room_stub.UserBuildRoom(UserBuildRoomRequest(uid=1, room_name='mini17'))
    print "-" * 10
    print UserBuildRoomResponse


    params_name = []
    # 获取变量名
    for k, v in GetRoomByRidResponse.__dict__.iteritems():
        if isinstance(v, _FieldProperty):
            params_name.append(k)
    print params_name

    # user_enter_response = user_room_stub.UserEnterRoom(UserEnterRoomRequest(uid=2, rid=65536))
    # print "-" * 10
    # print user_enter_response
    #
    # user_exit_response = user_room_stub.UserExitRoom(UserExitRoomRequest(rid=65536, uid=1))
    # print "-" * 10
    # print user_exit_response
    #
    # get_rooms_response = user_room_stub.GetRooms(GetRoomsRequest(uid=1))
    # print "-" * 10
    # print get_rooms_response
    #
    # get_room_response = user_room_stub.GetRoomByRid(GetRoomByRidRequest(rid=65536, uid=1))
    # print "-" * 10
    # print get_room_response
    #
    # start_game = user_room_stub.UserStartGame(UserStartGameRequest(rid=65536, uid=2))
    # print "-" * 10
    # print start_game


if __name__ == '__main__':
    main()
