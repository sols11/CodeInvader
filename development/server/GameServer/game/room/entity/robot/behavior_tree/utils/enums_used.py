# -*- coding:utf-8 -*-
# @Time         : 2019-08-14 08:45:57
# @Author       : jiejianshu@corp.netease.com
# @File         : Enums_used.py
# @Description  : to do
# @API          :


from enum import IntEnum


class ClauseType(IntEnum):
    CONDITION = 0
    ACTION = 1


class EntityType(IntEnum):
    SELF = 0
    ENEMY_ROBOT = 1
    FRIENDLY_ROBOT = 2
    ENEMY_PLAYER = 3
    FRIENDLY_PLAYER = 4
    WAYPOINT = 5


class PropertyType(IntEnum):
    STATE = 0,
    HEALTH = 1,
    ARMOR = 2,
    DISTANCE = 3,
    SIGNAL = 4,
    ATTACKER = 5,
    ATTACKEE = 6,
    ENEMY_FLEE = 7,
    POSITION = 8,
    VIEW = 9,
    SHORT_RANGE = 10,
    MID_RANGE = 11,
    LONG_RANGE = 12,

class DistType(IntEnum):
    WITHIN_SIGHT = 0
    WITHIN_NEAR = 1
    NEAR_MID = 2
    MID_FAR = 3
    CLOSEST = 4
    FARTHEST = 5


class StatusType(IntEnum):
    PATROL = 0
    RETREAT = 1


class ActionType(IntEnum):
    ATTACK_LEFT = 0
    ATTACK_RIGHT = 1
    ATTACK = 2
    MOVE_TOWARDS = 3
    SEND_SIGNAL = 4
    STOP_SIGNAL = 5
    PATROL = 6
    SUICIDE = 7
    RETREAT = 8
    STILL = 9


class PlayerState(IntEnum):
    RUN = 0
    SHOOT = 1


class TaskState(IntEnum):
    INVALID = 0
    RUNNING = 1
    SUCCESS = 2
    FAILURE = 3


class SpecialInt(IntEnum):
    COMPARE_WITH_SELF = -1
    COMPARE_WITH_ALL = -2


class AIOperator(IntEnum):
    LessEqual = 0,
    Equal = 1,
    MoreEqual = 2,
