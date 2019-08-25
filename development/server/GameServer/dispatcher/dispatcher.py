# -*- coding:UTF-8 -*-
from __future__ import absolute_import

from collections import deque

from dispatcher.message import Message
from lib.singleton_meta import SingletonMeta
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class Dispatcher(object):
    """
    Description:
        消息分发器, 与网络层通过Message对象交换数据
    Attributes:
        agencies: dict, proto_id(uint) -> client agency(ClientAgency)注册表，根据proto_id， 找到相应的代理
        agencies: dict, action_name(str) -> client agency(ClientAgency)注册表， 根据方法类名， 找到相应的代理
        request_msgs: list, Message Object, 从网络流解析出proto_id的Message队列
        response_msgs: list, Message Object bytes, 从Game返回的response经过decode后的队列
    """
    __metaclass__ = SingletonMeta

    def __init__(self):
        super(Dispatcher, self).__init__()
        self.agencies = {}
        self.reverse_agencies = {}
        self.request_msgs = deque()
        self.response_msgs = []

    def dispatch(self, room_mgr):
        """
        将网络层得到的消息根据代理协议，生成相应action分配到各房间
        :param room_mgr: RoomMgr Object， 单例类
        """
        try:
            # 清空回复队列
            self.response_msgs = []
            while len(self.request_msgs) > 0:
                # 取出一个消息
                msg = self.request_msgs.popleft()
                if msg.proto_id not in self.agencies:
                    raise ValueError("agency not found 0x%08d" % hex(msg.proto_id))
                # 获取代理并创建对应action，存入RoomMgr的game_msgs中
                room_mgr.game_msgs = self.agencies[msg.proto_id].new_action(msg.data), msg.hid, msg.tick
        except Exception as e:
            logger.error("(dispatch) %s" % e.args[0])

    def msg_enqueue(self, req_msg):
        """
        将网络流转换为Message Object
        :param req_msg: bytes
        """
        for msg in req_msg:
            msg = Message().decode(msg)
            self.request_msgs.append(msg)

    def msg_dequeue(self):
        """
        向网络层发送回复
        :return: list，Message Object, 回复队列
        """
        return self.response_msgs

    def add_responses(self, room_mgr):
        """
        从RoomMgr中获取回复队列
        :param room_mgr: RoomMgr Object, 单例
        """
        msgs = room_mgr.game_responses
        for msg in msgs:
            self.add_response(msg)

    def add_response(self, msg):
        """
        将回复消息处理为Message， 并加入回复队列
        :param msg: namedtuple
            .hids: set, 该response需要发往的用户hid
            .response: _Response Object 一个反射的自定义类
        """
        action_name = msg.response.action_name
        # response: proto_id(uint), data(bytes)
        if action_name not in self.reverse_agencies:
            raise ValueError("reverse agency command not found %s" % action_name)
        proto_id, data = self.reverse_agencies[action_name].new_response(msg.response)
        if data is None:
            return
        for hid in msg.hids:
            self.response_msgs.append(Message().encode(hid, proto_id, data))

    def register(self, proto_id, agency_obj):
        """
        正向注册agency对象
        :param proto_id: uint, 协议id
        :param agency_obj: ClientAgency Object, 代理对象，可生成action
        """
        try:
            if proto_id not in self.agencies:
                self.agencies[proto_id] = agency_obj
            elif self.agencies[proto_id] == agency_obj:
                return
            else:
                raise ValueError("service conflict")
        except Exception as e:
            logger.error("(register service) %s" % e.args[0])

    def reverse_register(self, action_name, agency_obj):
        """
        反向注册agency对象
        :param action_name: str, 方法类名
        :param agency_obj: ClientAgency Object, 代理对象， 可生成response
        """
        try:
            if action_name not in self.reverse_agencies:
                self.reverse_agencies[action_name] = agency_obj
            elif self.reverse_agencies[action_name] == agency_obj:
                return
            else:
                raise ValueError("service conflict")
        except Exception as e:
            logger.error("(register service) %s" % e.args[0])
