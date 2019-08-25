# -*- coding:utf-8 -*-
# @Time        : 2019/8/12 17:51
# @Author      : liyihang@corp.netease.com
# @File        : account_service.py
# @Description : 线程式被动响应
# @API         :
from grpc_service.base_service import BaseService
from grpc_service.pb2.AccountMessage_pb2 import LoginResponse, RegisterResponse
from grpc_service.pb2_grpc.AccountMessage_pb2_grpc import AccountServicer, add_AccountServicer_to_server
from lobby.lobby import Lobby


class AccountService(AccountServicer, BaseService):
    def __init__(self):
        super(AccountService, self).__init__()
        self.lobby = Lobby()

    def login(self, request, context):
        result, uid = self.lobby.user_login(request)
        return LoginResponse(result=result, uid=uid)

    def register(self, request, context):
        result = self.lobby.user_register(request)
        return RegisterResponse(result=result)

    def register_self(self, server):
        add_AccountServicer_to_server(self, server)
