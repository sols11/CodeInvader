# -*- coding:utf-8 -*-
# @Time         : 2019/8/14 9:36
# @Author       : jiejianshe@corp.netease.com
# @File         : leaf_task.py
# @Description: : to do
# @API          :


import task
from game.room.entity.robot.behavior_tree.utils import enums_used


class LeafTask(task.Task):
    def __init__(self, name=''):
        super(LeafTask, self).__init__(name)
        self.ind_in_parent = -1

    def update(self):
        super(LeafTask, self).update()

class Action(LeafTask):
    def __init__(self, name=''):
        super(Action, self).__init__(name)

    def update(self):
        super(Action, self).update()
        if self.tree.current_task_ind!=self.ind_in_tree:
            self.tree.tasks[self.tree.current_task_ind].stop()
        state = self.execute()
        if state != enums_used.TaskState.RUNNING:
            self.parent.on_child_finish(state, self.ind_in_parent)
        else:
            self.tree.current_task_ind = self.ind_in_tree

    def execute(self):
        return enums_used.TaskState.RUNNING

    def stop(self):
        pass

class Condition(LeafTask):
    def __init__(self, name=''):
        super(Condition, self).__init__(name)

    def update(self):
        super(Condition, self).update()
        is_success = self.is_condition_fulfilled()
        if is_success:
            self.parent.on_child_finish(enums_used.TaskState.SUCCESS, self.ind_in_parent)
        else:
            self.parent.on_child_finish(enums_used.TaskState.FAILURE, self.ind_in_parent)

    def is_condition_fulfilled(self):
        return True