# -*- coding:utf-8 -*-
# @Time        : 2019/8/12 21:16
# @Author      : liyihang@corp.netease.com
# @File        : game_service.py
# @Description : 
# @API         :
from grpc_service.base_service import BaseService
from grpc_service.pb2.GameServerMessage_pb2 import *
from grpc_service.pb2_grpc.GameServerMessage_pb2_grpc import GameServerServicer, add_GameServerServicer_to_server
from lobby.lobby import Lobby


class GameService(GameServerServicer, BaseService):

    def ServerRegister(self, request, context):
        lobby = Lobby()
        result = lobby.server_register(request)
        return ServerRegisterResponse(result=result)

    def ServerUpdate(self, request, context):
        lobby = Lobby()
        result = lobby.server_update(request)
        return ServerUpdateResponse(result=result)

    def register_self(self, server):
        add_GameServerServicer_to_server(self, server)
