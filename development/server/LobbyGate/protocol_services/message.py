import struct
from protocol_services.protobuf_msg.pb2 import ProtocolMessage_pb2


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

    def encode(self, response_msg):
        hid = response_msg.hid
        msg = ProtocolMessage_pb2.ProtoMessage()
        msg.proto_id = response_msg.proto_id
        msg.proto_data = response_msg.data
        return tuple((hid, msg.SerializeToString()))
