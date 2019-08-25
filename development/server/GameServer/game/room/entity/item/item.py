# -*- coding:utf-8 -*-
# @Time        : 2019/8/14 18:01
# @Author      : liyihang@corp.netease.com
# @File        : software.py
# @Description : 软件道具实体
# @API         :

from config.entity_conf import *
from game.action.item_action.other import ItemPicked
from game.room.entity.entity_base import EntityBase
from protocol.pb2.Struct import *


class Item(EntityBase):

    def __init__(self, room_obj):
        super(Item, self).__init__(room_obj)

        # model
        self.item_type = None
        self.item_id = None
        self.collectable = True
        self.name = None

        # control
        self.picked = self._SimpleCall(ItemPicked(obj=self))

    def verify_collectable(self, player):
        if not self.collectable:
            return False
        if euc_distance(self.transform.position, player.transform.position) > COLLECTABLE_DISTANCE:
            return False
        return True

    def to_net_item_data(self):
        return NetItemData(
            eid=self.eid, item_type=self.item_type,
            item_id=self.item_id, collectable=self.collectable,
            transform=self.transform
        )


class AiModuleItem(Item):

    def __init__(self, room_obj):
        super(AiModuleItem, self).__init__(room_obj)

        # model
        self.name = None
        self.info = None

        # control


class EquipComponentItem(Item):

    def __init__(self, room_obj):
        super(EquipComponentItem, self).__init__(room_obj)

        # model
        self.equip_type = None
        self.name = None
        self.weight = None
        # 手部装备相关信息
        self.setup_time = None
        self.attack_duration = None
        self.attack = None
        self.rot_speed_reduce = None
        # 武器类型，决定攻击方式
        self.weapon_type = None
        # 伤害效果
        self.break_defense = None
        self.slow_down = None
        self.slow_down_speed = None
        self.beat_back = None
        self.beat_back_force = None
        # 腿部装备相关信息
        self.move_speed = None
        self.rot_speed = None
        self.is_fly = None

        # control
