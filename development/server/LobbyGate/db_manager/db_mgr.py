# -*- coding:utf-8 -*-
# @Time        : 2019/8/12 19:57
# @Author      : wuzelin@corp.netease.com
# @File        : db_mgr.py
# @Description :
#    管理游戏数据库
# @API         : TODO

from lib.singleton_meta import SingletonMeta
from mongoengine import *
from db_manager.db_conf import *
from db_manager.game_user import GameUser


connect(db=DB_NAME, username=DB_USER, password=DB_PWD, host=DB_HOST, port=DB_PORT)


class DBMgr(object):
    __metaclass__ = SingletonMeta

    def __init__(self):
        super(DBMgr, self).__init__()
        self.user_doc = GameUser()


if __name__ == "__main__":
    db_mgr = DBMgr()
    db_mgr.user_doc.insert(uid=1, username="test1", password="163")
