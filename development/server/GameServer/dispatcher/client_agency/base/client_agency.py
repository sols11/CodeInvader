# -*- coding:utf-8 -*-
# @Time        : 2019/8/15 19:58
# @Author      : liyihang@corp.netease.com
# @File        : client_agency.py
# @Description : 客户端代理基类
# @API         :
# 1. 生成指令: new_action
# 2. 生成回复: new_response


from lib import proto_helper
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class ClientAgency(object):
    """
    Description:
        客户端代理类，根据网络流生成action， 根据回复生成response
    Attributes:
        proto_id: uint， 协议号
        request_cls: class object, 请求消息类
        response_cls: class object, 回复消息类
        action_cls: class object，指令
    """

    def __init__(self, proto_id, request_cls, response_cls, action_cls):
        self.proto_id = proto_id
        self.request_cls = request_cls
        self.response_cls = response_cls
        self.action_cls = action_cls

    def new_action(self, raw_data):
        """
        解析protobuf对象，并生成相应的方法对象
        :param raw_data: bytes，网络流数据
        :return:tuple
                rid or None: action对应房间
                action Object: 指令对象
        """
        if self.request_cls is None:
            logger.error("(new action fail, Request Cls is None)")
        # 为request class 创建创建兜方法
        self.request_cls.__getattr__ = lambda obj, item: logger.error("(action data get attr %s fail )" % str(obj))
        data = self.request_cls()
        data.ParseFromString(raw_data)
        return getattr(data, 'rid', None), self.action_cls(data=data)

    def new_response(self, response):
        """
        根据action结果生成response对象
        :param response: _Response Object, 一个反射的自定义类
        :return:
            Response Object or None
            proto_id: uint or None, 回复所对应协议号
        """
        if self.response_cls is None or response is None:
            return None, None
        try:
            data = proto_helper.proto_object(response.get_values(), self.response_cls)
            return self.proto_id, data.SerializeToString()
        except Exception as e:
            logger.info("(agency new response) (%s)" % e.args[0])
            return None, None

    @property
    def action_name(self):
        """
        获取该代理对应的方法名
        :return: str, 协议对应方法名
        """
        return self.action_cls().__class__.__name__
