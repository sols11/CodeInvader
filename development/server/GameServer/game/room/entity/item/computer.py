# -*- coding:utf-8 -*-
# @Time        : 2019/8/18 18:51
# @Author      : liyihang@corp.netease.com
# @File        : computer.py
# @Description : 
# @API         :

from config import computer_conf, server_conf
from game.action.item_action.computer import *
from game.room.entity.entity_base import EntityBase
from protocol.pb2 import Struct


class Computer(EntityBase):
    def __init__(self, room_obj):
        super(Computer, self).__init__(room_obj)

        # model
        self.cracker_eid = None
        self.need_time = None
        # 破解进度
        self.crack_timer = 0
        self.completed = None
        self.being_decoded = False
        self.begin_crack_time = None

        # control
        self.crack = self._SimpleCall(ComputerCrack(obj=self))
        self.crack_complete = self._SimpleCall(ComputerCrackComplete(obj=self))

    def tick(self):
        if not self.being_decoded:
            return
        self.crack_timer += server_conf.TICK_REAL_TIME

    def verify_crack(self):
        # 是否被开启
        if self.completed:
            return False
        # 是否正在被破解
        if self.being_decoded:
            return False
        return True

    def do_begin_crack(self, player_eid):
        self.being_decoded = True
        self.cracker_eid = player_eid

    def do_stop_crack(self):
        self.being_decoded = False
        self.cracker_eid = None

    def verify_complete(self):
        if self.completed:
            return False
        if self.cracker_eid is None:
            return False
        if not self.being_decoded:
            return False
        if self.crack_timer < self.need_time:
            return False
        return True

    def do_crack_complete(self):
        self.being_decoded = False
        self.completed = True

    def verify_cracker_pos(self, pos):
        """
        验证电脑和玩家之间的距离
        :param pos: NetVector3
        """
        distance = self.transform.position.euc_distance(pos)
        if distance > computer_conf.MAX_CRACK_DISTANCE:
            return False
        return True

    def get_crack_transform(self):
        """
        破译时玩家应该站的位置
        :return: NetTransform
        """
        pos = self.transform.position.vec3_add(Struct.NetVector3(x=0, y=0, z=-0.5))
        rot = self.transform.rotation.opposite()
        return Struct.NetTransform(position=pos, rotation=rot)
