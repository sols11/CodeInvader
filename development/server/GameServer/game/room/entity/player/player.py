# -*- coding:utf-8 -*-
# @Time        : 2019/8/14 17:10
# @Author      : liyihang@corp.netease.com
# @File        : player_agencies.py
# @Description : 玩家实体，保存数据, 方法都是修改数据
# @API         :

from protocol.pb2.Struct import *
from config import player_conf
from game.action.player_action.other import *
from game.action.player_action.own import *
from game.room.entity.entity_base import EntityBase
from game.room.virtual.component.inventory import Inventory


class Player(EntityBase):

    def __init__(self, room_obj):
        super(Player, self).__init__(room_obj)

        # model
        self.uid = None
        self.hp = None
        self.max_hp = None
        self.move_speed = None
        self.rot_speed = None
        self.view = None
        self.state = None
        self.side = None
        # 玩家A、B...
        self.mark = None
        self.crack_computer_eid = None
        self.backpack = Inventory(self)
        # control
        self.move = self._SimpleCall(PlayerMove(obj=self))
        self.crack = self._SimpleCall(PlayerCrack(obj=self))
        self.pick = self._SimpleCall(PlayerPick(obj=self))
        self.take_out = self._SimpleCall(PlayerTakeOut(obj=self))

    def verify_speed(self, velocity):
        # 速度校验
        if np.linalg.norm([velocity.x, velocity.z]) > self.move_speed * player_conf.VERIFY_SPEED_RATE:
            return False
        return True

    def verify_pos(self, pos):
        # TODO 位置校验
        if False:
            return False
        return True

    def do_move(self, transform):
        self.transform = transform

    def do_pos(self, position):
        self.transform = Struct.NetTransform(position=position,
                                             rotation=self.transform.rotation)

    def do_rota(self, rotation):
        self.transform = Struct.NetTransform(position=self.transform.position,
                                             rotation=rotation)

    def verify_crack_state(self):
        return self.crack_computer_eid is None

    def do_crack(self, computer_eid):
        self.crack_computer_eid = computer_eid

    def do_cancel_crack(self):
        self.crack_computer_eid = None
