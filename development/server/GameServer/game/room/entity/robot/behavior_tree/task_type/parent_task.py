# -*- coding:utf-8 -*-
# @Time         : 2019/8/14 10:12
# @Author       : jiejianshe@corp.netease.com
# @File         : parent_task.py
# @Description: : to do
# @API          :

import sys
import time
import task
from game.room.entity.robot.behavior_tree.utils import enums_used


class ParentTask(task.Task):
    def __init__(self, name=''):
        super(ParentTask, self).__init__(name)
        self.ind_in_parent = 0
        self.max_children_number = sys.maxint

    def add_child(self, child):
        self.children.append(child)
        child.parent = self
        child.ind_in_parent = len(self.children) - 1

    def update(self):
        super(ParentTask, self).update()

    def on_child_finish(self, state, child_ind):
        self.tree.current_task_ind = self.ind_in_tree


class EntryTask(ParentTask):
    def __init__(self, name=''):
        super(EntryTask, self).__init__(name)
        self.max_children_number = 1

    def update(self):
        super(EntryTask, self).update()
        if self.children:
            self.children[0].update()

    def on_child_finish(self, state, child_ind):
        super(EntryTask, self).on_child_finish(state, child_ind)
        # if state != enums_used.TaskState.FAILURE:
        #     self.children[0].update()


class Composite(ParentTask):
    def __init__(self, name=''):
        super(Composite, self).__init__(name)
        self.current_child_ind = 0

    def update(self):
        super(Composite, self).update()
        if self.children:
            self.children[self.current_child_ind].update()

    def on_child_finish(self, state, child_ind):
        super(Composite, self).on_child_finish(state, child_ind)


class Sequence(Composite):
    def __init__(self, name=''):
        super(Sequence, self).__init__()

    def update(self):
        super(Sequence, self).update()

    def on_child_finish(self, state, child_ind):
        super(Sequence, self).on_child_finish(state, child_ind)
        if state == enums_used.TaskState.FAILURE:
            self.current_child_ind = 0
            self.parent.on_child_finish(enums_used.TaskState.FAILURE, self.ind_in_parent)
        elif child_ind < len(self.children) - 1:
            self.current_child_ind += 1
            self.children[child_ind + 1].update()
        else:
            self.current_child_ind = 0
            self.parent.on_child_finish(enums_used.TaskState.SUCCESS, self.ind_in_parent)


class Selector(Composite):
    def __init__(self, name=''):
        super(Selector, self).__init__()

    def update(self):
        super(Selector, self).update()

    def on_child_finish(self, state, child_ind):
        super(Selector, self).on_child_finish(state, child_ind)
        if state == enums_used.TaskState.SUCCESS:
            self.current_child_ind = 0
            self.parent.on_child_finish(enums_used.TaskState.SUCCESS, self.ind_in_parent)
        elif child_ind < len(self.children) - 1:
            self.current_child_ind += 1
            self.children[child_ind + 1].update()
        else:
            self.current_child_ind = 0
            self.parent.on_child_finish(enums_used.TaskState.FAILURE, self.ind_in_parent)


class Decorator(ParentTask):
    def __init__(self, name=''):
        super(Decorator, self).__init__(name)
        self.current_child_ind = 0
        self.max_children_number = 1

    def update(self):
        super(Decorator, self).update()
        if self.children:
            self.children[0].update()

    def on_child_finish(self, state, child_ind):
        super(Decorator, self).on_child_finish(state, child_ind)


class Repeater(Decorator):
    def __init__(self, count, name=''):
        super(Repeater, self).__init__(name)
        self.count = count
        self.repeat_times = 0

    def update(self):
        if self.count <= 0:
            self.parent.on_child_finish(enums_used.TaskState.SUCCESS, self.ind_in_parent)
        else:
            super(Repeater, self).update()

    def on_child_finish(self, state, child_ind):
        super(Repeater, self).on_child_finish(state, child_ind)
        if state == enums_used.TaskState.FAILURE:
            self.parent.on_child_finish(enums_used.TaskState.FAILURE, self.ind_in_parent)
        else:
            self.repeat_times += 1
            if self.repeat_times >= self.count:
                self.parent.on_child_finish(enums_used.TaskState.SUCCESS, self.ind_in_parent)
            else:
                self.children[0].update()

class Timer(Decorator):
    def __init__(self, duration, name=''):
        super(Timer, self).__init__(name)
        self.duration = duration
        self.time = -1

    def update(self):
        if self.time < 0:
            self.time = time.time() + self.duration
            super(Timer, self).update()
            self.tree.current_task_ind = self.ind_in_tree
        else:
            if time.time() >= self.time:
                self.parent.on_child_finish(enums_used.TaskState.SUCCESS, self.ind_in_parent)
            else:
                self.children[0].update()
                self.tree.current_task_ind = self.ind_in_tree

    def on_child_finish(self, state, child_ind):
        super(Timer, self).on_child_finish(state, child_ind)
        if state == enums_used.TaskState.FAILURE:
            self.parent.on_child_finish(enums_used.TaskState.FAILURE, self.ind_in_parent)
        else:
            if time.time() >= self.time:
                self.parent.on_child_finish(enums_used.TaskState.SUCCESS, self.ind_in_parent)
            else:
                self.children[0].update()