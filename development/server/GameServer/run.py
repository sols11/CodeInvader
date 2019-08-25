# -*- coding:utf-8 -*-
# @Time        : 2019/8/14 15:00
# @Author      : liyihang@corp.netease.com
# @File        : run.py
# @Description :
# @API         :


from server import GameServer
from config import server_conf


def run():
    server = GameServer(gid=1)
    server.run(server_conf.PORT)


if __name__ == '__main__':
    run()
