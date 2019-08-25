# -*- coding:utf-8 -*-
# @Time         : 2019/08/14 07:31
# @Author       : jiejianshu@corp.netease.com
# @File         : task.py
# @Description  : to do
# @API          :


from game.room.entity.robot.behavior_tree.utils import enums_used


class Task(object):

    def __init__(self, name=''):
        self.state = enums_used.TaskState.INVALID
        self.parent = None
        self.children = []
        self.name = name
        self.ind_in_tree = 0
        self.tree = None

    def update(self):
        self.tree.current_task_ind = self.ind_in_tree

    def stop(self):
        pass
