# -*- coding:utf-8 -*-
# @Time        : ${DATE} ${TIME}
# @Author      : wuzelin@corp.netease.com
# @File        : ${NAME}.py
# @Description :
# @API         : TODO

from lib.singleton_meta import SingletonMeta
from mongoengine import *
from db_manager.game_user import GameUser


connect(db='game', username="game_admin", password="minigame17", host="127.0.0.1", port=27017)


class DBMgr(object):
    __metaclass__ = SingletonMeta

    def __init__(self):
        super(DBMgr, self).__init__()
        self.access_user = GameUser()


if __name__ == "__main__":
    db_mgr = DBMgr()
    db_mgr.access_user.register(username="test1", password="163")
