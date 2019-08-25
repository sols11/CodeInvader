# -*- coding:utf-8 -*-
# @Time        : 2019/8/18 15:09
# @Author      : liyihang@corp.netease.com
# @File        : mgr_base.py
# @Description : 
# @API         :

# 1. 创建对象
# 2. 获取所有对象
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class MgrBase(object):

    def __init__(self, room_obj):
        self._room = room_obj
        self._entities = {}
        self._entity_cls = None
        self._TYPE_ID = None
        self._MAX_COUNT = None
        self._eid_factory = self._generate_eid()

    def create_entity(self):
        """
        生成相应类型对象, 并赋值eid
        :return: Entity Object or None
        """
        if self._entity_cls is None:
            logger.error("(mgr_base.create_entity)create a entity need entity_cls")
            return None
        try:
            entity = self._entity_cls(self._room)
            entity.eid = self._eid_factory.next()
            self._entities[entity.eid] = entity
        except StopIteration:
            logger.error("(mgr_base.create entity) this entity type max")
            return None
        return entity

    def get_all_entities(self):
        """
        获取所有实体
        :return:list, Entity Object
        """
        return self._entities.values()

    def remove_entity(self, eid):
        """
        删除eid对象
        :param eid: uint
        """
        if eid in self._entities:
            self._entities.pop(eid)

    def get_entity_by_mark(self, mark):
        """
        通过标志获取实体对象
        :param mark: str, 实体标志
        :return: list: Entity Object or None
        """
        return [entity for entity in self._entities.values() if getattr(entity, 'mark', None) == mark]

    def get_entities_by_side(self, side):
        """
        通过阵营获取实体对象
        :param side: int, 阵营标志
        :return: list: Entity Object
        """
        return [entity for entity in self._entities.values() if getattr(entity, 'side', None) == side]

    def _generate_eid(self):
        if self._TYPE_ID is None:
            logger.error("(mgr_base._generate_eid) not assign type id")
            raise ValueError
        for i in xrange(1, self._MAX_COUNT):
            yield (self._TYPE_ID << 16) + i
