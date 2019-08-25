from __future__ import absolute_import
import struct

from protocol.pb2 import ProtocolMessage_pb2


class Message(object):

    def __init__(self):
        super(Message, self).__init__()
        self.hid = None
        self.tick = None
        self.proto_id = None
        self.data = None

    def decode(self, msg_raw):
        self.hid = msg_raw[0]
        self.tick = struct.unpack("H", msg_raw[1][0:2])[0]
        msg_raw = msg_raw[1][2:]
        proto_msg = ProtocolMessage_pb2.ProtoMessage()
        proto_msg.ParseFromString(msg_raw)
        self.proto_id = proto_msg.proto_id
        self.data = proto_msg.proto_data
        return self

    def encode(self, hid, proto_id, data):
        msg = ProtocolMessage_pb2.ProtoMessage()
        msg.proto_id = proto_id
        msg.proto_data = data
        return tuple((hid, msg.SerializeToString()))
