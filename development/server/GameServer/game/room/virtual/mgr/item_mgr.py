# -*- coding:utf-8 -*-
# @Time        : 2019/8/18 15:07
# @Author      : liyihang@corp.netease.com
# @File        : item_mgr.py
# @Description : 
# @API         : TODO
from config import entity_conf
from game.room.entity.item import computer, item
from game.room.virtual.mgr.mgr_base import MgrBase


class ComputerMgr(MgrBase):

    def __init__(self, room_obj):
        super(ComputerMgr, self).__init__(room_obj)
        self._entity_cls = computer.Computer
        self._TYPE_ID = entity_conf.COMPUTER_TYPE_ID
        self._MAX_COUNT = entity_conf.COMPUTER_MAX


class ItemMgr(MgrBase):
    def __init__(self, room_obj):
        super(ItemMgr, self).__init__(room_obj)
        self._entity_cls = item.Item
        self._TYPE_ID = entity_conf.ITEM_TYPE_ID
        self._MAX_COUNT = entity_conf.ITEM_MAX
