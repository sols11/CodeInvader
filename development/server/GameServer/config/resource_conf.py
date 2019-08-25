# -*- coding:utf-8 -*-
# @Time        : 2019/8/21 16:40
# @Author      : wuzelin@corp.netease.com
# @File        : resource_conf.py
# @Description : 
# @API         : TODO
from protocol.pb2.Struct.CommonStruct_pb2 import *


BORN_RESOURCE_ITEM = {
    'item_type': ItemType.Equipment,
    'item_id': 0x1001,
    'collectable': True,
    'name': "Spas",
    'transform': NetTransform(position=NetVector3(x=-4.0, y=0, z=3.57),
                              rotation=NetQuaternion(x=0, y=0.7, z=0, w=-0.7))
}