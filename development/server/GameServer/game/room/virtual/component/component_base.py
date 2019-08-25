# -*- coding:utf-8 -*-
# @Time        : 2019/8/22 19:29
# @Author      : liyihang@corp.netease.com
# @File        : component_base.py
# @Description : 
# @API         : TODO
from lib import proto_helper


class ComponentBase(object):
    """
    Description:
        组件基类, 组件数据集合, 行为单独定义, 但是挂载其下方便调用
    Attributes:
        entity_obj: EntityBase, 组件所在的实体对象
        room: Room Object, 组件所在房间
    """

    def __init__(self, entity_obj):
        super(ComponentBase, self).__init__()
        self.entity_obj = entity_obj
        self.room = entity_obj.room

    def __getattr__(self, item):
        return None

    def assign_data(self, component_data):
        """
        为组件赋值数据
        :param component_data: dict or Object or None
        """
        if component_data is None:
            return
        if not isinstance(component_data, dict):
            # component_data 为对象
            component_data = component_data.__dict__
        for k, v in component_data.iteritems():
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
