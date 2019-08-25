# -*- coding:utf-8 -*-
# @Time        : 2019/8/18 17:50
# @Author      : liyihang@corp.netease.com
# @File        : robot_conf.py
# @Description : 
# @API         : TODO
from protocol.pb2 import Struct

LEFT_HAND = 0
RIGHT_HAND = 1

FRIEND_SIDE = 0
ENEMY_SIDE = 1

RAW_DAMAGE = 100

LIGHT_ROBOT = {
    'transform': Struct.NetTransform(position=Struct.NetVector3(x=0, y=0, z=5),
                                     rotation=Struct.NetQuaternion(x=0, y=0.7, z=0, w=0.7)),
    'hp': 1500,
    'max_hp': 1500,
    'move_speed': 3,
    'rot_speed': 2,
    'max_armor': 600,
    'armor': 600,
    'view': 100,
    'short_range': 30,
    'mid_range': 60,
    'long_range': 90,
    'armor_recover_delay': 1,
    'armor_recover_speed': 1,
    'free_weight': 20,
    'state': Struct.Living,
    'attacked': False,
}
