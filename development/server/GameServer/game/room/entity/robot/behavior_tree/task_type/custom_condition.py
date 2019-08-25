# -*- coding:utf-8 -*-
# @Time         : 2019/8/14 11:37
# @Author       : jiejianshe@corp.netease.com
# @File         : custom_condition.py
# @Description: : to do
# @API          :


import numpy as np
from game.room.entity.robot.behavior_tree.task_type import leaf_task
from game.room.entity.robot.behavior_tree.task_type import parent_task
from protocol.pb2.Struct import CommonStruct_pb2
from protocol.pb2.Struct import AIStruct_pb2
from game.room.entity.robot.behavior_tree.utils import named_tuples


class CustomCondition(leaf_task.Condition):
    def __init__(self, status, adjs=None, sub=None):
        super(CustomCondition, self).__init__()
        self.status = status
        self.adjs = adjs
        if sub is None:
            sub = named_tuples.Entity(
                type=AIStruct_pb2.EntityType.Self, parameter=-1)
        self.sub = sub

    def is_condition_fulfilled(self):
        entity_data = self.get_entity_data()
        data = entity_data.get_data(self.status.type)
        if self.matches(data):
            return True
        return False

    def get_entity_data(self):
        sub = self.sub
        adjs = self.adjs

    def matches(self, data):
        parameters = self.status.parameters
        return True


def get_data(subject, property_type):
    property_dict = {
        AIStruct_pb2.ConditionType.Health: 'hp',
        AIStruct_pb2.ConditionType.Armor: 'armor',
        AIStruct_pb2.ConditionType.State: 'state',
        AIStruct_pb2.ConditionType.Distance: 'view',
    }
    if property_type == 'position':
        return subject.transform.position
    else:
        try:
            return getattr(subject, property_dict[property_type])
        except:
            raise ValueError('not implemented yet')


class ValuePropertyCondition(leaf_task.Condition):
    def __init__(self, entity_class, side, entity_id, property_type, operator, value, name=''):
        super(ValuePropertyCondition, self).__init__(name)
        self.entity_class = entity_class
        self.side = side
        self.entity_id = entity_id
        self.property = property_type
        self.operator = operator
        self.value = value

    def is_condition_fulfilled(self):
        if self.entity_id < 0:
            data = get_data(self.tree.robot, self.property)
        else:
            mark = '{:d}_{:s}_{:d}'.format(
                self.side, self.entity_class, self.entity_id)
            if self.entity_class == 'robot':
                data = get_data(
                    self.tree.robot.room.robot_mgr.get_entity_by_mark(mark), self.property)
            elif self.entity_class == 'player':
                data = get_data(
                    self.tree.robot.room.player_mgr.get_entity_by_mark(mark), self.property)
            else:
                raise ValueError('只有自己、玩家和机器人可以作为条件主语')

        if self.value == AIStruct_pb2.SpecialInt.CompareWithSelf:
            self.value = get_data(self.tree.robot, self.property)

        if self.value == AIStruct_pb2.SpecialInt.CompareWithAll:
            if self.entity_class == 'player':
                entity_list = self.tree.robot.room.player_mgr.get_entities_by_side(
                    self.side)
            else:
                entity_list = self.tree.robot.room.robot_mgr.get_entities_by_side(
                    self.side)
            if self.operator == AIStruct_pb2.SpecialInt.LessEqual:
                for entity in entity_list:
                    if data > get_data(entity, self.property):
                        return False
                return True
            if self.operator == AIStruct_pb2.SpecialInt.MoreEqual:
                for entity in entity_list:
                    if data < get_data(entity, self.property):
                        return False
                return True
            raise ValueError('并不支持判断是否与其他所有人相等')
        else:
            if self.operator == AIStruct_pb2.SpecialInt.LessEqual:
                return data <= self.value
            elif self.operator == AIStruct_pb2.SpecialInt.MoreEqual:
                return data >= self.value
            else:
                if not self.entity_class == 'robot' and self.property == AIStruct_pb2.ConditionType.Armor and self.value == 0:
                    raise ValueError('数值性质只有判断护甲是否为0或是否时能以相等为条件')
                return data == self.value


class StatePropertyCondition(leaf_task.Condition):
    def __init__(self, entity_class, side, entity_id, value, name=''):
        super(StatePropertyCondition, self).__init__(name)
        self.entity_class = entity_class
        self.side = side
        self.entity_id = entity_id
        self.value = value

    def is_condition_fulfilled(self):
        mark = '{:d}_{:s}_{:d}'.format(
            self.side, self.entity_class, self.entity_id)
        if self.entity_id < 0:
            data = self.tree.robot.state
        elif self.entity_class == 'robot':
            data = self.tree.robot.room.robot_mgr.get_entity_by_mark(
                mark).state
        elif self.entity_class == 'player':
            data = self.tree.robot.room.player_mgr.get_entity_by_mark(
                mark).state
        else:
            raise ValueError('只有自己、玩家和机器人可以作为条件主语')
        return data == self.value


# to modify
class SetPropertyCondition(leaf_task.Condition):
    def __init__(self, type, side, id, property, value, name=''):
        super(SetPropertyCondition, self).__init__(name)
        self.type = type
        self.side = side
        self.id = id
        self.property = property
        self.value = value

    def is_condition_fulfilled(self):
        if self.type == AIStruct_pb2.EntityType.SELF:
            data = self.tree.get_self_data()[self.property]
        elif self.type == AIStruct_pb2.EntityType.FRIENDLY_ROBOT or self.type == AIStruct_pb2.EntityType.ENEMY_ROBOT:
            data = self.tree.get_robot_data(self.side, self.id)[self.property]
        elif self.type == AIStruct_pb2.EntityType.FRIENDLY_PLAYER or self.type == AIStruct_pb2.EntityType.ENEMY_PLAYER:
            data = self.tree.get_player_net_data(
                self.side, self.id)[self.property]
        else:
            raise ValueError('只有自己、玩家和机器人可以作为条件主语')
        return self.value in data


# to modify
class ObjectPropertyCondition(leaf_task.Condition):
    def __init__(self, type, side, id, property, name=''):
        super(ObjectPropertyCondition, self).__init__(name)
        self.type = type
        self.side = side
        self.id = id
        self.property = property

    def is_condition_fulfilled(self):
        if self.type == AIStruct_pb2.EntityType.SELF:
            data = self.tree.get_self_data()[self.property]
        elif self.type == AIStruct_pb2.EntityType.FRIENDLY_ROBOT or self.type == AIStruct_pb2.EntityType.ENEMY_ROBOT:
            data = self.tree.get_robot_data(self.side, self.id)[self.property]
        elif self.type == AIStruct_pb2.EntityType.FRIENDLY_PLAYER or self.type == AIStruct_pb2.EntityType.ENEMY_PLAYER:
            data = self.tree.get_player_net_data(
                self.side, self.id)[self.property]
        else:
            raise ValueError('只有自己、玩家和机器人可以作为条件主语')
        return data is None


class DistanceCondition(leaf_task.Condition):
    def __init__(self, entity_class, side, entity_id, dist_type, name=''):
        super(DistanceCondition, self).__init__(name)
        self.entity_class = entity_class
        self.side = side
        self.entity_id = entity_id
        self.dist_type = dist_type

    def is_condition_fulfilled(self):
        self_position = self.tree.robot.transform.position
        mark = '{:d}_{:s}_{:d}'.format(
            self.side, self.entity_class, self.entity_id)
        if self.entity_id < 0:
            raise ValueError('不能以自己为主语')
        elif self.entity_class == 'robot':
            other_position = self.tree.robot.room.robot_mgr.get_entity_by_mark(
                mark).transform.position
        elif self.entity_class == 'player':
            other_position = self.tree.robot.room.player_mgr.get_entity_by_mark(
                mark).transform.position
        else:
            raise ValueError('只能以玩家或机器人作为条件主语')
        other_distance = np.linalg.norm(
            np.array((self_position.x, self_position.y, self_position.z)) - np.array(
                (other_position.x, other_position.y, other_position.z))
        )

        if self.dist_type == AIStruct_pb2.DistanceType.Closest or self.dist_type == AIStruct_pb2.DistanceType.Farthest:
            if self.entity_id == -1:
                return True
            if self.entity_class == 'player':
                entity_list = self.tree.robot.room.player_mgr.get_entities_by_side(
                    self.side)
            else:
                entity_list = self.tree.robot.room.robot_mgr.get_entities_by_side(
                    self.side)
            # 暂时还没有加入路点

            if self.dist_type == AIStruct_pb2.DistanceType.Closest:
                for entity in entity_list:
                    position = entity.transform.position
                    distance = np.linalg.norm(
                        np.array((self_position.x, self_position.y, self_position.z)) - np.array(
                            (position.x, position.y, position.z))
                    )
                    if distance < other_distance:
                        return False
                return True
            if self.dist_type == AIStruct_pb2.DistanceType.Farthest:
                for entity in entity_list:
                    position = entity.transform.position
                    distance = np.linalg.norm(
                        np.array((self_position.x, self_position.y, self_position.z)) - np.array(
                            (position.x, position.y, position.z))
                    )
                    if distance > other_distance:
                        return False
                return True

        else:
            if self.dist_type == AIStruct_pb2.DistanceType.Sight:
                dist_range = self.tree.robot.view
            elif self.dist_type == AIStruct_pb2.DistanceType.NearAttack:
                dist_range = self.tree.robot.short_range
            elif self.dist_type == AIStruct_pb2.DistanceType.MidAttack:
                dist_range = self.tree.robot.mid_range
            else:
                dist_range = self.tree.robot.long_range
            if dist_range[0] <= other_distance < dist_range[1]:
                return True
            return False
