# -*- coding:utf-8 -*-
# @Time        : 2019/8/15 16:36
# @Author      : liyihang@corp.netease.com
# @File        : other.py
# @Description : 道具行为，与其他实体产生交互， 如被拾取
# @API         :


from game.action.action_base import ActionBase


class ItemPicked(ActionBase):
    # 道具被拾取

    def _action(self):
        print "Item Picked..."


class SyncBackpack(ActionBase):
    # 背包信息同步

    def _action(self):
        pass