# -*- coding:utf-8 -*-
# @Time        : 2019/8/14 20:07
# @Author      : liyihang@corp.netease.com
# @File        : robot_agencies.py
# @Description : 机器人代理类的封装, 实现自动注册
# @API         :
from dispatcher.client_agency.base.client_agency import ClientAgency
from dispatcher.client_agency.base.client_agency_meta import ClientAgencyMeta
from game.action import robot_action
from lib.proto_helper import generate_proto_id
from protocol.pb2.AIMessage_pb2 import *

robot_proto_id = generate_proto_id(ROBOT_SERVICE)


class RobotAgencies(object):
    __metaclass__ = ClientAgencyMeta

    get_behavior_tree = ClientAgency(robot_proto_id(GET_BEHAVIOR_TREE),
                                     GetBehaviorTreeRequest,
                                     GetBehaviorTreeResponse,
                                     robot_action.RobotGetBehaviorTree)

    move = ClientAgency(robot_proto_id(MOVE),
                        None,
                        RobotMoveResponse,
                        robot_action.RobotMove)

    attack = ClientAgency(robot_proto_id(ATTACK),
                          None,
                          RobotAttackResponse,
                          robot_action.RobotAttack)

    take_damage = ClientAgency(robot_proto_id(TAKE_DAMAGE),
                               None,
                               RobotTakeDamageResponse,
                               robot_action.RobotTakeDamage)
