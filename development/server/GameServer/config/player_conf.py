# -*- coding:utf-8 -*-
# @Time        : 2019/8/19 16:15
# @Author      : liyihang@corp.netease.com
# @File        : player_conf.py
# @Description : 
# @API         : TODO
from protocol.pb2 import Struct

BORN_PLAYER = {
    'hp ': 100,
    'max_hp': 100,
    'move_speed': 5,
    'rot_speed': 5,
    'state': Struct.Living,
    'transform': Struct.NetTransform(position=Struct.NetVector3(x=0, y=0, z=0),
                                     rotation=Struct.NetQuaternion(x=0, y=0, z=0, w=0))
}

VERIFY_SPEED_RATE = 1.5
