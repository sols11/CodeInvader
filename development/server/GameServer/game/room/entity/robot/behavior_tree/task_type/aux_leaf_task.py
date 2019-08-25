# -*- coding:utf-8 -*-
# @Time         : 2019/8/16 18:00
# @Author       : jiejianshe@corp.netease.com
# @File         : aux_leaf_task.py
# @Description: : to do
# @API          :


import leaf_task

class FindSpecificObject(leaf_task.LeafTask):
    def __init__(self, props, name=''):
        super(FindSpecificObject, self).__init__(name)
        self.properties = props

    def update(self):
        super(FindSpecificObject, self).update()
