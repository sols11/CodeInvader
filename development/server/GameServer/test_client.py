# -*- coding:utf-8 -*-
# @Time        : 2019/8/16 16:42
# @Author      : liyihang@corp.netease.com
# @File        : test_client.py
# @Description :
# @API         :


import socket
import struct

from lib.proto_helper import generate_proto_id
from protocol.pb2 import Struct
from protocol.pb2.GameMessage_pb2 import *
from protocol.pb2.PlayerMessage_pb2 import *
from protocol.pb2.ProtocolMessage_pb2 import *


class Client(object):
    def __init__(self, port, ip='localhost'):
        self.sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.ip = ip
        self.port = port

    def start(self):
        self.sock.connect((self.ip, self.port))
        data = self.sock.recv(1024)
        print struct.unpack('<IH', data)[1]

    def run(self, requests):
        for request in requests:
            self.sock.send(request)
            res = self.sock.recv(1024)
            yield res


def generate_full_request(request, proto_id):
    # 序列化原请求
    res = request.SerializeToString()
    # 增加proto_id
    res = ProtoMessage(proto_id=proto_id, proto_data=res).SerializeToString()
    # 增加序列帧
    res = struct.pack('H', 5) + res
    # 增加包头
    size = len(res) + 4
    res = struct.pack('<I', size) + res
    return res


def resolve_complete_request(raw_response, res_cls):
    # tick号
    # print struct.unpack('<IH', raw_response[:6])[1]
    raw_response = raw_response[6:]
    while len(raw_response) > 0:
        # 包长
        length = struct.unpack('<I', raw_response[0:4])[0]
        # 转Message
        raw = raw_response[4:length]
        proto_message = ProtoMessage()
        proto_message.ParseFromString(raw)
        # 转具体的
        res_obj = res_cls.next()()
        res_obj.ParseFromString(proto_message.proto_data)
        print res_obj
        print '-' * 10
        raw_response = raw_response[length:]


if __name__ == '__main__':
    client = Client(17017)
    client.start()

    proto_id_game = generate_proto_id(GAME_SERVICE)
    proto_id_player = generate_proto_id(PLAYER_SERVICE)

    deal_requests = []
    response_cls = []
    # 上线
    deal_requests.append(generate_full_request(PlayerOnlineRequest(rid=1, eid=0, uid=1),
                                               proto_id_game(PLAYERONLINE)))
    response_cls.append(PlayerOnlineResponse)
    response_cls.append(PullResponse)

    # 移动
    deal_requests.append(
        generate_full_request(PlayerMoveRequest(rid=1, eid=196609, velocity=Struct.NetVector3(x=1, y=2, z=3)),
                              proto_id_player(MOVE)))
    response_cls.append(PlayerMoveResponse)
    # 破译
    deal_requests.append(
        generate_full_request(CrackRequest(rid=1, eid=196609, computer_id=327681, decode=True),
                              proto_id_player(CRACK)))
    response_cls.append(CrackResponse)
    response_cls.append(ComputerCrackResponse)
    # 破译
    deal_requests.append(
        generate_full_request(CrackRequest(rid=1, eid=196609, computer_id=327681, decode=True),
                              proto_id_player(CRACK)))
    response_cls.append(CrackResponse)
    response_cls.append(ComputerCrackResponse)
    # 停止破译
    deal_requests.append(
        generate_full_request(CrackRequest(rid=1, eid=196609, computer_id=0, decode=False),
                              proto_id_player(CRACK)))
    response_cls.append(CrackResponse)
    response_cls.append(ComputerCrackResponse)
    # 停止破译
    deal_requests.append(
        generate_full_request(CrackRequest(rid=1, eid=196609, computer_id=0, decode=False),
                              proto_id_player(CRACK)))
    response_cls.append(CrackResponse)
    response_cls.append(ComputerCrackResponse)
    # 停止破译
    deal_requests.append(
        generate_full_request(CrackRequest(rid=1, eid=196609, computer_id=0, decode=False),
                              proto_id_player(CRACK)))
    response_cls.append(CrackResponse)
    response_cls.append(ComputerCrackResponse)
    # # 破译
    # deal_requests.append(
    #     generate_full_request(CrackRequest(rid=1, eid=196609, computer_id=327681, decode=True),
    #                           proto_id_player(CRACK)))
    # response_cls.append(CrackResponse)
    # response_cls.append(ComputerCrackResponse)
    # # 破译
    # deal_requests.append(
    #     generate_full_request(CrackRequest(rid=1, eid=196609, computer_id=327681, decode=True),
    #                           proto_id_player(CRACK)))
    # response_cls.append(CrackResponse)
    # # 停止破译
    # response_cls.append(ComputerCrackResponse)
    # deal_requests.append(
    #     generate_full_request(CrackRequest(rid=1, eid=196609, computer_id=327681, decode=True),
    #                           proto_id_player(CRACK)))
    # response_cls.append(CrackResponse)
    # response_cls.append(ComputerCrackResponse)
    # # 破译完成
    # deal_requests.append(
    #     generate_full_request(CrackCompleteRequest(rid=1, eid=327681),
    #                           proto_id_player(CRACK_COMPLETE)),
    # )
    # response_cls.append(CrackCompleteResponse)

    g = client.run(deal_requests)

    r = (cls for cls in response_cls)
    for response in g:
        resolve_complete_request(response, r)
