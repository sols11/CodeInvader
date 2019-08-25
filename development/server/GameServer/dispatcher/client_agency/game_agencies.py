# -*- coding:utf-8 -*-
# @Time        : 2019/8/16 9:02
# @Author      : liyihang@corp.netease.com
# @File        : game_agencies.py
# @Description : 房间代理类的封装, 实现自动注册
# @API         :
from dispatcher.client_agency.base.client_agency import ClientAgency
from dispatcher.client_agency.base.client_agency_meta import ClientAgencyMeta
from game.action import game_action
from lib.proto_helper import generate_proto_id
from protocol.pb2.GameMessage_pb2 import *

game_proto_id = generate_proto_id(GAME_SERVICE)


class GameAgencies(object):
    __metaclass__ = ClientAgencyMeta

    playerOnline = ClientAgency(game_proto_id(PLAYERONLINE),
                                PlayerOnlineRequest,
                                PlayerOnlineResponse,
                                game_action.GamePlayerOnline)

    pull = ClientAgency(game_proto_id(PULL),
                        None,
                        PullResponse,
                        game_action.GamePull)
