# -*- coding:utf-8 -*-
# @Time        : 2019/8/22 14:11
# @Author      : wuzelin@corp.netease.com
# @File        : inventory.py
# @Description :
#       用户背包
# @API         : TODO
from game.room.virtual.component.component_base import ComponentBase
from collections import deque
from protocol.pb2.Struct.CommonStruct_pb2 import ItemType
from protocol.pb2.InventoryMessage_pb2 import BackpackInfo, ItemInfo


class Inventory(ComponentBase):
    def __init__(self, player):
        super(Inventory, self).__init__(player)
        # self.backpack = {
        #     ItemType.Aimodule: dict(),
        #     ItemType.Equipment: dict()
        # }
        # 测试用，初始背包已有数据
        self.backpack = {
            ItemType.AIModule: {0x1001: deque([1, 2, 3, 4]), 0x2001: deque([5, 6, 7])},
            ItemType.Equipment: {0x1001: deque([8, 9]), 0x2001: deque([10, 11, 12, 13, 14])}
        }

    def get_backpack_info(self):
        info = []
        for item_type, values in self.backpack.iteritems():
            backpack_info = BackpackInfo(item_type=item_type, items=[])
            for item_id, items in values.iteritems():
                backpack_info.items.append(ItemInfo(item_id=item_id, count=len(items)))
            info.append(backpack_info)
        return info




