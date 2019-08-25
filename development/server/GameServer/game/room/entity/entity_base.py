# -*- coding:utf-8 -*-
# @Time        : 2019/8/16 9:15
# @Author      : liyihang@corp.netease.com
# @File        : entity_base.py
# @Description : 
# @API         :
# 1. 实体逻辑更新 : tick

from lib import proto_helper
from protocol.pb2 import Struct


class EntityBase(object):
    """
    Description:
        实体基类，数据集合, 行为单独定义, 但是挂载其下方便调用
    Attributes:
        room: Room Object, 实体所在房间
        eid: uint， 实体id
    """

    def __init__(self, room_obj):
        super(EntityBase, self).__init__()
        self.room = room_obj
        self.eid = None
        self.transform = Struct.NetTransform()

    def __getattr__(self, item):
        return None

    def tick(self):
        pass

    def assign_data(self, entity_data):
        """
        为实体赋值数据
        :param entity_data: dict or Object or None
        """
        if entity_data is None:
            return
        if not isinstance(entity_data, dict):
            # entity_data 为对象
            entity_data = entity_data.__dict__
        for k, v in entity_data.iteritems():
            if hasattr(self, k):
                setattr(self, k, v)

    def get_struct(self, struct_cls):
        """
        获取struct对象
        :param struct_cls: protobuf struct class
        :return: Struct Class
        """
        return proto_helper.proto_object(self.__dict__, struct_cls)

    class _SimpleCall(object):
        """
        Description:
            封装action调用, 实现__call__方法, 会将通过接口生成的action存入room的action队列中
        Attributes:
            action: Action Object, 实例化的action对象, 已经赋值实例对象
        """

        def __init__(self, action):
            """
            :param action: Action实例, entity已经赋值
            """
            self.action = action

        def __call__(self, data=None, delay=None, repeat=False):
            """
            将赋值data的action放入room_actions队列中
            :param data: dict
            :return None or Action Object, 定时调用时
            """
            # self.action.do(data)
            room = self.action.room_obj
            self.action.data = data
            if delay is None:
                # 将action.do函数放入room_actions中
                room.room_actions.append(self.action)
                return None
            else:
                room.action_timer.add_action(self.action, delay, repeat)
