# -*- coding:utf-8 -*-
# @Time        : 2019/8/15 21:57
# @Author      : liyihang@corp.netease.com
# @File        : item_agencies.py
# @Description : 道具代理类的封装, 实现自动注册
# @API         :
from dispatcher.client_agency.base.client_agency import ClientAgency
from dispatcher.client_agency.base.client_agency_meta import ClientAgencyMeta
from game.action import item_action
from lib.proto_helper import generate_proto_id
from protocol.pb2.PlayerMessage_pb2 import *

tmp_computer_proto_id = generate_proto_id(PLAYER_SERVICE)


class ItemAgencies(object):
    __metaclass__ = ClientAgencyMeta


class ComputerAgencies(object):
    __metaclass__ = ClientAgencyMeta
    crack = ClientAgency(tmp_computer_proto_id(COMPUTER_CRACK),
                         None,
                         ComputerCrackResponse,
                         item_action.ComputerCrack)

    crack_complete = ClientAgency(tmp_computer_proto_id(CRACK_COMPLETE),
                                  CrackCompleteRequest,
                                  CrackCompleteResponse,
                                  item_action.ComputerCrackComplete)
