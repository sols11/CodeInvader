# -*- coding:utf-8 -*-
# @Time        : 2019/8/14 20:07
# @Author      : liyihang@corp.netease.com
# @File        : player_agencies.py
# @Description : 玩家代理类的封装, 实现自动注册
# @API         :
from dispatcher.client_agency.base.client_agency import ClientAgency
from dispatcher.client_agency.base.client_agency_meta import ClientAgencyMeta
from game.action import player_action
from lib.proto_helper import generate_proto_id
from protocol.pb2.PlayerMessage_pb2 import *

player_proto_id = generate_proto_id(PLAYER_SERVICE)


class PlayerAgencies(object):
    __metaclass__ = ClientAgencyMeta

    move = ClientAgency(player_proto_id(MOVE),
                        PlayerMoveRequest,
                        PlayerMoveResponse,
                        player_action.PlayerMove)

    crack = ClientAgency(player_proto_id(CRACK),
                         CrackRequest,
                         CrackResponse,
                         player_action.PlayerCrack)

    pick = ClientAgency(player_proto_id(PICK_ITEM),
                        PlayerPickRequest,
                        PlayerPickResponse,
                        player_action.PlayerPick)

    take_out = ClientAgency(player_proto_id(TAKEOUT_ITEM),
                            PlayerTakeOutRequest,
                            PlayerTakeOutResponse,
                            player_action.PlayerTakeOut)
