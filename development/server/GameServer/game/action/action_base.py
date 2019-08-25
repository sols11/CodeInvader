# -*- coding:utf-8 -*-
# @Time        : 2019/8/15 16:51
# @Author      : liyihang@corp.netease.com
# @File        : action_base.py
# @Description :
# @API         :
# 执行action： do


from config import net_conf
from game.room.entity.entity_base import EntityBase
from game.room.virtual.component.component_base import ComponentBase
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class ActionBase(object):
    """
    Description:
        指令基类， 子类实现action方法实现逻辑调用
        可以任意的在构造时或者调用时传入相关参数
        同时适用于网络调用以及本地调用
    Attributes:
        data:  request Object, action所需数据，调用方式: data.xxx
            对于无request的， 在继承的类内写内部类
        room_obj: Room Object, 所操作的实体对象所在的房间对象
        entity_obj: Entity Object, 所操作的实体对象
    """

    def __init__(self, data=None, obj=None):
        self.data = data
        self.room_obj = None
        self.entity_obj = None
        self.response = self._Response()
        self._get_obj(obj)

    def do(self, data=None, obj=None):
        """
        激活action
        :param data: dict or Request Object or None
        :param obj: Room Object or Entity Object or None
        """
        if data is not None:
            self.data = data
        # 数据处理
        self._dict_to_data()
        self._get_obj(obj)
        # 校验
        if self.room_obj is None or self.entity_obj is None:
            logger.error("(action don't have handle object)")
            return

        # 设置方法名(反向查找proto_id)
        self.response.action_name = self.__class__.__name__
        self.response.eid = self.entity_obj.eid
        self.response.send_eid = self.entity_obj.eid
        # 调用逻辑
        try:
            self._action()
        except Exception as e:
            logger.error("(action do fail %s)" % e)
        # 保存结果至房间
        self._push_response()

    def _action(self):
        """
        具体逻辑处理
        在调用前，self.entity_obj, self.room_obj,一定被指定了
        self.response.eid也指定了
        如果有消息回复，在方法里赋值self.response.result
        """
        raise NotImplementedError

    def _get_obj(self, obj):
        if obj is None:
            return
        if isinstance(obj, EntityBase):
            # 由实体调用
            self.room_obj = obj.room
            self.entity_obj = obj
        elif isinstance(obj, ComponentBase):
            # 由组件调用
            self.room_obj = obj.room
            self.entity_obj = obj.entity_obj
        else:
            # 由房间调用
            self.room_obj = obj
            if self.entity_obj is None:
                if not hasattr(self.data, 'eid'):
                    logger.error(
                        "(entity_base._get_obj) action data need has eid to find a entity when no assign entity")
                    raise ValueError
                self.entity_obj = obj.get_entity(self.data.eid)

    def _dict_to_data(self):
        """
        对于本地调用， 传入字典数据， 反射为内部类， action中方便统一调用
        """
        if not isinstance(self.data, dict):
            return
        data = self._Data()
        for k, v in self.data.iteritems():
            setattr(data, k, v)
        self.data = data

    def _push_response(self):
        """
        处理action结果， 将结果放入房间回复队列
        """
        if self.response.result is None:
            return
        self.room_obj.add_room_response(self.response)

    class _Response(object):
        """
        Description:
            用来反射的类，自动添加相关字段到实例
        Attributes:
            action_name: str, 方法名
            result: uint or None, 消息回复，默认None不回消息
            eid：uint or None, 实体id
            send_mode: enum, 决定广播方式，默认AOI
        """

        def __init__(self):
            self.action_name = None
            self.result = None
            self.eid = None
            self.send_eid = None
            self.send_mode = net_conf.SEND_AREA

        def get_values(self):
            """
            返回该类下所有实例变量的字典
            :return: dict, 自身和反射所得实例变量
            """
            return self.__dict__

    class _Data(object):
        """
        Description:
            用来反射的类， 自动添加相关字段到实例, 访问字段安全, 不抛出异常， 而是None
        """

        def __getattr__(self, item):
            """
            兜底方法， 在__dict__找不到时候， 会调用这个方法
            """
            return None
