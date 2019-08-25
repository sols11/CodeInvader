# -*- coding:utf-8 -*-
# @Time        : 2019/8/12 19:59
# @Author      : wuzelin@corp.netease.com
# @File        : game_user.py
# @Description : 
# @API         :

from mongoengine import *
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class GameUserDoc(Document):
    """
    MongoDB 数据集合
    """
    uid = IntField(required=True)
    username = StringField(max_length=32, required=True, unique=True)
    password = StringField(max_length=32, required=True)

    meta = {'collection': 'game_users'}


class GameUser(object):

    def __init__(self):
        super(GameUser, self).__init__()

    def find(self, **kwargs):
        try:
            query = Q()
            if 'uid' in kwargs:
                query &= Q(uid=kwargs['uid'])
            if 'username' in kwargs:
                query &= Q(username=kwargs['username'])
            user = eval(GameUserDoc.objects(query).to_json())
            if not user:
                return 0, None
            return 1, user[0]
        except Exception as e:
            logger.error("(find user) %s" % e.args[0])
            return -1, None

    def insert(self, **kwargs):
        try:
            user = GameUserDoc()
            user.uid = kwargs['uid']
            user.username = kwargs['username']
            user.password = kwargs['password']
            user.save()
            return 1
        except NotUniqueError:
            return 0   # user exist
        except KeyError:
            return -1   # attribute error
        except Exception as e:
            logger.error("(insert user) %s" % e.args[0])
            return -2   # other error

    def delete(self, ** kwargs):
        # TODO
        pass

    def update(self, **kwargs):
        # TODO
        pass
