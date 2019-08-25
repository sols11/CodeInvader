# -*- coding:utf-8 -*-
# @Time        : 2019/8/18 15:01
# @Author      : liyihang@corp.netease.com
# @File        : player_mgr.py
# @Description : 
# @API         : TODO
from config import entity_conf
from game.room.entity.player.player import Player
from game.room.virtual.mgr.mgr_base import MgrBase


class PlayerMgr(MgrBase):

    def __init__(self, room_obj):
        super(PlayerMgr, self).__init__(room_obj)
        self._entity_cls = Player
        self._TYPE_ID = entity_conf.PLAYER_TYPE_ID
        self._MAX_COUNT = entity_conf.PLAYER_MAX

    def get_player_by_uid(self, uid):
        """
        通过用户id获取player实体对象
        :param uid: uint， 用户id
        :return: Player Object or None
        """
        for entity in self._entities.values():
            if entity.uid == uid:
                return entity
        return None
