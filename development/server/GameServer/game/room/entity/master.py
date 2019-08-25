# -*- coding:utf-8 -*-
# @Time        : 2019/8/18 19:32
# @Author      : liyihang@corp.netease.com
# @File        : master.py
# @Description : 房间内的单例实体
# @API         : TODO
import time

from game.action.game_action.own import *
from game.room.entity.entity_base import EntityBase


class Master(EntityBase):

    def __init__(self, room_obj):
        super(Master, self).__init__(room_obj)
        # 唯一预赋值eid
        self.eid = 0
        self.transform = None

        # model
        self.time = time.time()

        # control
        self.player_online = self._SimpleCall(GamePlayerOnline(obj=self))
        self.pull = self._SimpleCall(GamePull(obj=self))
