# -*- coding:utf-8 -*-
# @Time        : 2019/8/14 17:58
# @Author      : liyihang@corp.netease.com
# @File        : robot_agencies.py
# @Description : robot实体
# @API         :
import collections

from game.action.robot_action.other import *
from game.action.robot_action.own import *
from game.room.entity.entity_base import EntityBase


class Robot(EntityBase):

    def __init__(self, room_obj):
        super(Robot, self).__init__(room_obj)
        # model
        '''
        初始化数据
        '''
        self.hp = None
        self.max_hp = None
        self.move_speed = None
        self.rot_speed = None
        self.max_armor = None
        self.armor = None
        self.view = None  # 视野范围
        self.side = None  # 阵营
        self.free_weight = None  # 负重
        self.armor_recover_delay = None
        self.armor_recover_speed = None
        self.state = None

        '''
        后赋值数据
        '''
        self.ai_state = None
        self.target = None  # 攻击目标
        self.targeted = None  # 被作为目标攻击
        self.behavior_tree = None
        self.left_hand = None
        self.right_hand = None
        self.attacked = None
        self.attack_target_eid = None
        self.action_state = None
        self.signal_sending = None

        self.mark = None  # 标志，eg. "1_robot_1"

        '''
        服务端辅助数据
        '''
        self.way_points = collections.deque()
        # 断线重连的转向提供计算
        self.from_point = None

        # control
        self.move = self._SimpleCall(RobotMove(obj=self))
        self.moveto = self._SimpleCall(RobotMoveTo(obj=self))
        self.attack = self._SimpleCall(RobotAttack(obj=self))
        self.take_damage = self._SimpleCall(RobotTakeDamage(obj=self))
        self.get_behavior_tree = self._SimpleCall(RobotGetBehaviorTree(obj=self))

    def tick(self):
        if self.behavior_tree is not None:
            self.behavior_tree.tick()

        self.do_move()

    def do_clear_points(self):
        self.way_points = collections.deque()

    def do_add_points(self, way_point):
        try:
            self.way_points.extend(way_point)
        except TypeError:
            self.way_points.append(way_point)

    def do_move(self):
        if self.way_points:
            self.from_point = self.transform.position
            self.transform = Struct.NetTransform(position=self.way_points.popleft(),
                                                 rotation=self.transform.rotation)
