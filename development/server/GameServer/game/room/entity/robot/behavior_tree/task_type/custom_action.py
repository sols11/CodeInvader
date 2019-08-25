# -*- coding:utf-8 -*-
# @Time			: 2019/8/15 15:00
# @Author		: jiejianshu@corp.netease.com
# @File			: custom_action.py
# @Description	: to do
# @API			:

import leaf_task
from game.room.entity.robot.behavior_tree.utils import enums_used


class SuicideAction(leaf_task.Action):
    def execute(self):
        self.tree.robot.suicide()
        return enums_used.TaskState.SUCCESS


class RetreatAction(leaf_task.Action):
    def execute(self):
        self.tree.robot.retreat()
        return enums_used.TaskState.SUCCESS

    def stop(self):
        self.tree.robot.stop_retreat()


class StillAction(leaf_task.Action):
    def execute(self):
        self.tree.robot.stop_action()
        return enums_used.TaskState.SUCCESS

    def stop(self):
        return


class AttackLeftAction(leaf_task.Action):
    def __init__(self, target_side, target_class, target_id, name=''):
        super(AttackLeftAction, self).__init__(name)
        self.target_side = target_side
        self.target_class = target_class
        self.target_id = target_id

    def execute(self):
        mark = '{:d}_{:s}_{:d}'.format(
            self.target_side, self.target_class, self.target_id)
        if self.target_class == 'robot':
            eid = self.tree.robot.room.robot_mgr.get_entity_by_mark(mark).eid
        else:
            eid = self.tree.robot.room.player_mgr.get_entity_by_mark(mark).eid
        self.tree.robot.attack(data={'target_eid': eid, 'hand': 0})
        return enums_used.TaskState.SUCCESS

    def stop(self):
        self.tree.robot.stop_attack_left()


class AttackRightAction(leaf_task.Action):
    def __init__(self, target_side, target_class, target_id, name=''):
        super(AttackRightAction, self).__init__(name)
        self.target_side = target_side
        self.target_class = target_class
        self.target_id = target_id

    def execute(self):
        mark = '{:d}_{:s}_{:d}'.format(
            self.target_side, self.target_class, self.target_id)
        if self.target_class == 'robot':
            eid = self.tree.robot.room.robot_mgr.get_entity_by_mark(mark).eid
        else:
            eid = self.tree.robot.room.player_mgr.get_entity_by_mark(mark).eid
        self.tree.robot.attack(data={'target_eid': eid, 'hand': 1})
        return enums_used.TaskState.SUCCESS

    def stop(self):
        self.tree.robot.stop_attack_right()


class AttackAction(leaf_task.Action):
    def __init__(self, target_side, target_class, target_id, name=''):
        super(AttackAction, self).__init__(name)
        self.target_side = target_side
        self.target_class = target_class
        self.target_id = target_id

    def execute(self):
        mark = '{:d}_{:s}_{:d}'.format(
            self.target_side, self.target_class, self.target_id)
        if self.target_class == 'robot':
            eid = self.tree.robot.room.robot_mgr.get_entity_by_mark(mark).eid
        else:
            eid = self.tree.robot.room.player_mgr.get_entity_by_mark(mark).eid
        self.tree.robot.attack(data={'target_eid': eid, 'hand': 0})
        self.tree.robot.attack(data={'target_eid': eid, 'hand': 1})
        return enums_used.TaskState.SUCCESS

    def stop(self):
        self.tree.robot.stop_attack_left()
        self.tree.robot.stop_attack_right()


class MoveTowardsAction(leaf_task.Action):
    def __init__(self, target_side, target_class, target_id, name=''):
        super(MoveTowardsAction, self).__init__(name)
        self.target_side = target_side
        self.target_class = target_class
        self.target_id = target_id

    def execute(self):
        mark = '{:d}_{:s}_{:d}'.format(
            self.target_side, self.target_class, self.target_id)
        if self.target_class == 'robot':
            eid = self.tree.robot.room.robot_mgr.get_entity_by_mark(mark).eid
        else:
            eid = self.tree.robot.room.player_mgr.get_entity_by_mark(mark).eid
        self.tree.robot.moveto(data={'target_eid': eid})
        return enums_used.TaskState.SUCCESS


class SendSignalAction(leaf_task.Action):
    def __init__(self, signal, name=''):
        super(SendSignalAction, self).__init__(name)
        self.signal = signal

    def execute(self):
        self.tree.robot.send_signal(self.signal)


class StopSignalAction(leaf_task.Action):
    def __init__(self, signal, name=''):
        super(StopSignalAction, self).__init__(name)
        self.signal = signal

    def execute(self):
        self.tree.robot.stop_signal(self.signal)


class PatrollAction(leaf_task.Action):
    def __init__(self, waypoints, name=''):
        super(PatrollAction, self).__init__(name)
        self.waypoints = waypoints

    def execute(self):
        self.tree.robot.patrol(self.waypoints)
