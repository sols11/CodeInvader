# -*- coding:utf-8 -*-
# @Time        : 2019/8/18 15:04
# @Author      : liyihang@corp.netease.com
# @File        : robot_mgr.py
# @Description : 
# @API         : TODO
from config import entity_conf, robot_conf
from game.room.entity.robot.robot import Robot
from game.room.virtual.mgr.mgr_base import MgrBase


class FriendRobotMgr(MgrBase):

    def __init__(self, room_obj):
        super(FriendRobotMgr, self).__init__(room_obj)
        self._entity_cls = Robot
        self._TYPE_ID = entity_conf.FRIEND_ROBOT_TYPE_ID
        self._MAX_COUNT = entity_conf.FRIEND_ROBOT_MAX

    def create_entity(self):
        """
        为友方机器人赋值side
        :return: Robot Object
        """
        robot = super(FriendRobotMgr, self).create_entity()
        robot.side = robot_conf.FRIEND_SIDE
        return robot


class EnemyRobotMgr(MgrBase):
    def __init__(self, room_obj):
        super(EnemyRobotMgr, self).__init__(room_obj)
        self._entity_cls = Robot
        self._TYPE_ID = entity_conf.ENEMY_ROBOT_TYPE_ID
        self._MAX_COUNT = entity_conf.ENEMY_ROBOT_MAX

    def create_entity(self):
        """
        为敌方机器人赋值side
        :return: Robot Object
        """
        robot = super(EnemyRobotMgr, self).create_entity()
        robot.side = robot_conf.ENEMY_SIDE
        return robot
