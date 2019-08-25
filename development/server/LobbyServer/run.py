# -*- coding:utf-8 -*-
# @Time        : 2019/8/11 15:17
# @Author      : liyihang@corp.netease.com
# @File        : run.py
# @Description : 注册服务，启动服务器
import time
from config import server_conf
from grpc_server import GRPCServer
from grpc_service.account_service import AccountService
from grpc_service.game_service import GameService
from grpc_service.user_room_service import UserRoomService


def run():
    # 服务器
    grpc_server = GRPCServer(server_conf.PORT)
    # 服务注册
    grpc_server.add_service(AccountService())
    grpc_server.add_service(GameService())
    grpc_server.add_service(UserRoomService())
    # 启动服务器
    grpc_server.start()
    try:
        while True:
            time.sleep(server_conf.ONE_DAY_IN_SECONDS)
    except KeyboardInterrupt:
        grpc_server.stop(0)


if __name__ == '__main__':
    run()
