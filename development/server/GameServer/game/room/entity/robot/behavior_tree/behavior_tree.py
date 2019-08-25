# -*- coding:utf-8 -*-
# @Time         : 2019/08/13 21:57
# @Author       : jiejianshu@corp.netease.com
# @File         : behavior_tree.py
# @Description  : to do
# @API          :


import numpy as np
from game.room.entity.robot.behavior_tree.task_type import parent_task
from game.room.entity.robot.behavior_tree.task_type import leaf_task
from game.room.entity.robot.behavior_tree.task_type import custom_condition
from game.room.entity.robot.behavior_tree.task_type import custom_action
from game.room.entity.robot.behavior_tree.utils import enums_used
from protocol.pb2.Struct import AIStruct_pb2
from game.room.entity.robot.behavior_tree.auxiliary_data import robot


class BehaviorTree(object):
    def __init__(self):
        self.side = 0
        self.robot_id = 0
        entry = parent_task.EntryTask()
        self.tasks = [entry]
        entry.tree = self
        self.current_task_ind = 0
        self.actions_count = 0
        self.robot = None

        # these are for comment_test, other_test, simple_tree_test and other_test
        self.test_intlist = []
        self.test_positions = []
        self.test_state = enums_used.PlayerState.RUN
        self.test_player_data = {}
        self.test_robot_data = {}

        # these are for custom_condition_test and condition_parser_test
        self.player_data = []
        self.robot_data = []
        self.waypoint_position = []
        self.current_player_side = 0
        self.current_player_ind = 0
        self.current_robot_side = 0
        self.current_robot_ind = 0
        self.dist_range = {
            AIStruct_pb2.DistanceType.Sight: [0, 40],
            AIStruct_pb2.DistanceType.NearAtrtack: [0, 5.5],
            AIStruct_pb2.DistanceType.MidAttack: [5.5, 20],
            AIStruct_pb2.DistanceType.FarAttack: [20, 40],
        }

    def log(self):
        return 1

    @staticmethod
    def from_model_list(model_list):
        tree = BehaviorTree()
        selInd = tree.add_task(parent_task.Selector(), 0)
        for sentence in model_list:
            seqInd = tree.add_task(parent_task.Sequence(), selInd)
            for clause in sentence:
                tree.add_task(get_task_from_clause(clause, tree.side), seqInd)
        return tree

    def get_player_data(self, side, ind):
        try:
            return self.player_data[side][ind]
        except:
            return

    def get_player_side_data(self, side):
        try:
            return self.player_data[side]
        except:
            return

    def get_robot_data(self, side, ind):
        try:
            return self.robot_data[side][ind]
        except:
            return

    def get_robot_side_data(self, side):
        try:
            return self.robot_data[side]
        except:
            return

    def get_self_data(self):
        return self.get_robot_data(self.side, self.robot_id)

    def get_waypoint_position(self, ind):
        return self.waypoint_position[ind]

    def add_task(self, task, parent_ind):
        if parent_ind > len(self.tasks):
            return -1
        if not isinstance(self.tasks[parent_ind], parent_task.ParentTask):
            return -1
        parent = self.tasks[parent_ind]
        if len(parent.children) >= parent.max_children_number:
            return -1
        task.tree = self
        parent.add_child(task)
        if isinstance(task, leaf_task.Action):
            self.actions_count += 1
        task.ind_in_tree = len(self.tasks)
        self.tasks.append(task)
        return len(self.tasks) - 1

    def run(self):
        if self.actions_count <= 0:
            return
        self.tasks[self.current_task_ind].update()

    def tick(self):
        self.run()


def get_class_and_side(entity_type, self_side):
    if entity_type == AIStruct_pb2.EntityType.EnemyRobot or entity_type == AIStruct_pb2.EntityType.FriendlyRobot or entity_type == AIStruct_pb2.EntityType.Self:
        _class = 'robot'
    elif entity_type == AIStruct_pb2.EntityType.EnemyPlayer or entity_type == AIStruct_pb2.EntityType.FriendlyPlayer:
        _class = 'player'
    elif entity_type == AIStruct_pb2.EntityType.Waypoint:
        _class = 'waypoint'
    else:
        raise ValueError('invalid entity type')
    if entity_type == AIStruct_pb2.EntityType.EnemyRobot or entity_type == AIStruct_pb2.EntityType.EnemyPlayer:
        side = 1 - self_side
    elif entity_type == AIStruct_pb2.EntityType.FriendlyRobot or entity_type == AIStruct_pb2.EntityType.FriendlyPlayer or \
            entity_type == AIStruct_pb2.EntityType.Self:
        side = self_side
    else:
        side = -1
    return (_class, side)


def get_task_from_clause(clause, self_side):
    action_with_noun_dict = {
        AIStruct_pb2.ActionType.SEND_SIGNAL: custom_action.SendSignalAction,
        AIStruct_pb2.ActionType.STOP_SIGNAL: custom_action.StopSignalAction,
        AIStruct_pb2.ActionType.PATROL: custom_action.PatrollAction,
    }
    action_without_noun_dict = {
        AIStruct_pb2.ActionType.SUICIDE: custom_action.SuicideAction,
        AIStruct_pb2.ActionType.RETREAT: custom_action.RetreatAction,
        AIStruct_pb2.ActionType.STILL: custom_action.StillAction,
    }

    if clause[0] == AIStruct_pb2.ClauseType.ACTION:
        # action clause: [ACTION, ACTION_TYPE, OTHER_PARAMETERS]
        # for attack/move, parameters are entity type and id
        if clause[1] == AIStruct_pb2.ActionType.ATTACK_LEFT:
            entity_class, side = get_class_and_side(clause[2], self_side)
            return custom_action.AttackLeftAction(side, entity_class, clause[3])
        if clause[1] == AIStruct_pb2.ActionType.ATTACK_RIGHT:
            entity_class, side = get_class_and_side(clause[2], self_side)
            return custom_action.AttackRightAction(side, entity_class, clause[3])
        if clause[1] == AIStruct_pb2.ActionType.ATTACK:
            entity_class, side = get_class_and_side(clause[2], self_side)
            return custom_action.AttackAction(side, entity_class, clause[3])
        if clause[1] == AIStruct_pb2.ActionType.MOVE_TOWARDS:
            entity_class, side = get_class_and_side(clause[2], self_side)
            return custom_action.MoveTowardsAction(side, entity_class, clause[3])

        if clause[1] in action_with_noun_dict:
            return action_with_noun_dict[clause[1]](clause[3])

        if clause[1] in action_without_noun_dict:
            return action_without_noun_dict[clause[1]]()

        raise ValueError('无效的行动类型')

    if clause[0] == AIStruct_pb2.ClauseType.CONDITION:
        entity_class, entity_side = get_class_and_side(clause[1], self_side)
        subject_id = clause[2]

        if clause[3] == AIStruct_pb2.ConditionType.State:
            return custom_condition.StatePropertyCondition(entity_class, entity_side, subject_id, clause[4])
        if clause[3] == AIStruct_pb2.ConditionType.Health or clause[3] == AIStruct_pb2.ConditionType.Armor:
            return custom_condition.ValuePropertyCondition(entity_class, entity_side, subject_id, clause[3], clause[4],
                                                           clause[5])
        if clause[3] == AIStruct_pb2.ConditionType.Signal:
            return custom_condition.SetPropertyCondition(entity_class, entity_side, subject_id, clause[3], clause[4])
        # if clause[3] == AIStruct_pb2.ConditionType.ATTACKEE or clause[3] == AIStruct_pb2.ConditionType.ATTACKER:
        #     return custom_condition.ObjectPropertyCondition(entity_class, entity_side, subject_id, clause[3])
        if clause[3] == AIStruct_pb2.ConditionType.Distance:
            return custom_condition.DistanceCondition(entity_class, entity_side, subject_id, clause[4])
        else:
            raise NotImplementedError()

    raise ValueError('无效的节点类型')
