# -*- coding:utf-8 -*-
# @Time        : ${DATE} ${TIME}
# @Author      : wuzelin@corp.netease.com
# @File        : ${NAME}.py
# @Description :
# @API         : TODO

import time
from lib.tw_snowflake import SnowFlake
from mongoengine import *
from log.game_logging import GameLogging

connect(db='game', username="game_admin", password="minigame17", host="127.0.0.1", port=27017)
# logger = GameLogging().get_logger(__name__)


class GameUserDoc(Document):
    """
    MongoDB 数据集合
    """
    uid = IntField(required=True)
    username = StringField(max_length=32, required=True, unique=True)
    password = StringField(max_length=32, required=True)


class GameUser(object):
    def __init__(self):
        super(GameUser, self).__init__()

    def login(self, username, password):
        try:
            user_info = GameUserDoc.objects(username=username)[0]
            if not user_info or user_info.password != password:
                return 0, None  # password not match
            return 1, user_info.uid     # login success
        except IndexError:
            return -1, None   # user not exist
        except Exception as e:
            return -2    # Unknown error

    def register(self, username, password):
        try:
            uid = SnowFlake().make_snowflake(timestamp_ms=time.time())
            while GameUserDoc.objects(uid=uid):
                uid = SnowFlake().make_snowflake(timestamp_ms=time.time())
            user = GameUserDoc(uid=uid, username=username, password=password)
            user.save()
            return 1    # register success
        except NotUniqueError:
            return -1   # duplicate user name
        except Exception as e:
            return 0    # register error
            # logger.error("(db: register account): %s" % e.args[0])


if __name__ == "__main__":
    GameUser().register("test1", "163")
