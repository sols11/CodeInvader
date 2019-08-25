# -*- coding:utf-8 -*-
# @Time        : ${DATE} ${TIME}
# @Author      : wuzelin@corp.netease.com
# @File        : ${NAME}.py
# @Description :
# @API         : TODO

from lib.singleton_meta import SingletonMeta
from protocol_services.dispatcher import Dispatcher
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class BaseService(object):
    """

    """
    __metaclass__ = SingletonMeta

    def __init__(self, service_id):
        super(BaseService, self).__init__()
        self.service_id = service_id
        self.dispatcher = Dispatcher()

    def register(self, cid, service_func):
        try:
            proto_id = (self.service_id << 16) + cid
            self.dispatcher.register(proto_id, service_func=service_func)
        except Exception as e:
            logger.error("(register command): %s" % e.args[0])

    def unregister(self, cid):
        try:
            proto_id = (self.service_id << 16) + cid
            self.dispatcher.unregister(proto_id)
        except Exception as e:
            logger.error("(unregister command): %s" % e.args[0])

    def unpack(self, protobuf_class, msg_data):
        protobuf_msg = protobuf_class()
        protobuf_msg.ParseFromString(msg_data)
        return protobuf_msg

    def pack(self, response):
        return response.SerializeToString()
