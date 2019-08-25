# -*- coding:UTF-8 -*-
from lib.singleton_meta import SingletonMeta
from protocol_services.message import Message
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class Dispatcher(object):
    """
    Description:
        消息分发器
    Attributes:

    """
    __metaclass__ = SingletonMeta

    def __init__(self):
        super(Dispatcher, self).__init__()
        self.services = {}
        self.request_msg = []
        self.response_msg = []

    def dispatch(self):
        try:
            while len(self.request_msg) > 0:
                msg = self.request_msg.pop(0)
                if msg.proto_id not in self.services:
                    raise ValueError("service command not found 0x%08d" % hex(msg.proto_id))
                self.services[msg.proto_id](msg)
        except Exception as e:
            logger.error("(dispatch) %s" % e.args[0])

    def msg_enqueue(self, req_msg):
        for msg in req_msg:
            self.request_msg.append(Message().decode(msg))

    def msg_dequeue(self):
        resp_msg = self.response_msg
        self.response_msg = []
        return resp_msg

    def add_response(self, msg):
        for hid in msg.hid:
            _msg = msg
            _msg.hid = hid
            self.response_msg.append(Message().encode(_msg))

    def register(self, proto_id, service_func):
        try:
            if proto_id not in self.services:
                self.services[proto_id] = service_func
            elif self.services[proto_id] == service_func:
                return
            else:
                raise ValueError("service conflict")
        except Exception as e:
            logger.error("(register service) %s" % e.args[0])

    def unregister(self, proto_id):
        try:
            if proto_id not in self.services:
                raise ValueError("service not exist")
            else:
                self.services.pop(proto_id)
        except Exception as e:
            logger.error("(unregister service): %s" % e.args[0])