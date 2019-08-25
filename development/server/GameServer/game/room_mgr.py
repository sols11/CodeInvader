# -*- coding:utf-8 -*-
# @Time        : 2019/8/14 15:27
# @Author      : liyihang@corp.netease.com
# @File        : room_mgr.py
# @Description : 内部管理所有房间(游戏局)，整个服务器级别管理， 向外部开放相关接口
# @API         :
# 1.新建房间： new_room
# 2.销毁房间： destroy_room
# 3.逻辑帧更新: tick
import gc

from game.room.room import Room
from lib.singleton_meta import SingletonMeta
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class RoomMgr(object):
    """
    Description:
        单例类，管理该服务器下所有房间
    Attributes:
        rooms: dict, rid(uint) -> room_obj(Room Object)
        _game_msgs: 从dispatcher中获取的msg队列
        _game_responses: 从各个Room中获取的回复队列
    """
    __metaclass__ = SingletonMeta

    def __init__(self):
        self.rooms = {}
        self._game_msgs = {}
        self._game_responses = []

        # TODO DEBUG
        self.test_init(1)

    def test_init(self, rid):
        room = Room(rid=rid)
        self.rooms[room.rid] = room
        self._game_msgs[room.rid] = []

    def tick(self):
        """
        服务器Tick
        按顺序对房间执行Tick
        """
        # 清空上轮回复
        self._game_responses = []

        for room in self.rooms.values():
            # 传递action给房间
            room.room_msgs = self._game_msgs[room.rid]

            # 房间tick
            room.tick()

            # 清空房间actions
            self._game_msgs[room.rid] = []
            # 房间回复
            self._game_responses.extend(room.room_responses)

    '''
    对外接口
    '''

    def new_room(self, request):
        # TODO RPC调用
        self.rooms[request.rid] = Room(request.rid)
        self._game_msgs[request.rid] = []

    def destroy_room(self, rid):
        # TODO RPC调用
        room = self.rooms.pop(rid)
        self._game_msgs.pop(rid)
        # 内部循环引用，显式gc
        del room
        gc.collect()

    '''
    外部访问
    '''

    @property
    def game_msgs(self):
        return self._game_msgs

    @game_msgs.setter
    def game_msgs(self, msg):
        """
        增加action
        :param msg: tuple ((rid(uint), action(Action Object)), hid(uint), tick(uint))
        """
        (rid, action), hid, tick_num = msg
        if rid is None:
            logger.error("request need have rid%s")
            return
        self._game_msgs[rid].append((action, hid, tick_num))

    @property
    def game_responses(self):
        return self._game_responses
