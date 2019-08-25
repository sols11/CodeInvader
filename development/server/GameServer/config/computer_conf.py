# -*- coding:utf-8 -*-
# @Time        : 2019/8/19 16:28
# @Author      : liyihang@corp.netease.com
# @File        : computer_conf.py
# @Description : 
# @API         : TODO
from protocol.pb2 import Struct

BORN_COMPUTER = {
    'need_time': 10,
    'completed': False,
    'being_decode': False,
    'transform': Struct.NetTransform(position=Struct.NetVector3(x=-4.91, y=0, z=3.57),
                                     rotation=Struct.NetQuaternion(x=0, y=1, z=0, w=0))
}

MAX_CRACK_DISTANCE = 8
