# -*- coding:utf-8 -*-
# @Time        : 2019/8/11 16:25
# @Author      : liyihang@corp.netease.com
# @File        : virtual_room_mgr.py
# @Description : lobby节点房间管理系统
# @API         :
# 1. 用户创建房间: user_new_build
# 2. 用户加入已有房间: user_enter_room
# 3. 用户退出所在房间: user_exit_room
# 4. 用户自动加入房间（无适合房间，自动创建）: user_auto_match TODO
# 5. 获取所有房间信息: get_rooms
# 6. 获取单个房间信息: get_room_by_rid
# 7. 用户开始游戏： user_start_game


from config import room_conf, result_conf
from lib.singleton_meta import SingletonMeta
from lobby.lobby import Lobby
from lobby.virtual_room.virtual_room import VirtualRoom
import heapq


class VirtualRoomMgr(object):
    """
    Description:
        单例类， 管理大厅下所有虚拟房间
    Attributes:
        _rooms: list, room object, 已创建的房间对象
        _users: dict, (uint)uid->(uint))rid, 全部在房间的玩家
        _index: uint, 辅助rid的获取
        _count: uint, 当前房间数量
        _max_users_pq: list, max_heap, 自动加入房间
        _lobby: Lobby, lobby_object， 单例
    """
    __metaclass__ = SingletonMeta

    def __init__(self):
        super(VirtualRoomMgr, self).__init__()
        self._rooms = []
        self._users = {}
        self._index = 1
        self._count = 0
        self._max_users_pq = []
        self._lobby = Lobby()

    def user_build_room(self, request):
        """
        用户创建房间RoomObject
        :param: request: BuildRoomRequest
            .uid: uint, 用户id
            .room_name: str, 房间名
        :return:
            new_room_obj:VirtualRoom Object dict, 新创建房间对象
            result: uint
        """
        # TODO DEBUG
        print "build room"
        # 房间上限验证
        if self._count > room_conf.MAX_ROOMS_INDEX:
            return result_conf.RESULT_CODE_FAIL, None
        # uid校验
        user_obj = self._lobby.get_user_by_uid(request.uid)
        if user_obj is None:
            return result_conf.RESULT_CODE_FAIL, None
        # 房间创建
        new_room_obj = self._build_room(request.room_name)
        # 将创建房间用户加入房间
        self._users[user_obj.uid] = user_obj
        new_room_obj.add_user(user_obj)
        return result_conf.RESULT_CODE_SUCCESS, new_room_obj.to_message()

    def user_enter_room(self, request):
        """
        用户加入房间, 玩家默认退出原先房间
        :param request: EnterRoomRequest
            .uid: uint, 用户id
            .rid: uint, 房间id
        :return:
            enter_room_obj: VirtualRoom Object dict or None, 进入房间对象
            result: uint
            -1 rid到rooms列表的索引的转换异常
            -2 索引查询得到空的房间对象
            -3 索引得到的房间rid与查询使用的rid不一致
            -4 房间已满
            -5 玩家uid不正常(不在线)
             0 加入房间成功
        """
        # TODO DEBUG
        print "enter room"
        # uid校验
        user_obj = self._lobby.get_user_by_uid(request.uid)
        if user_obj is None:
            # return -5, None
            return result_conf.RESULT_CODE_FAIL, None
        # rid校验
        state_code, enter_room_obj = self._get_room(request.rid)
        if enter_room_obj is None:
            # return state_code, None
            return result_conf.RESULT_CODE_FAIL, None
        # 验证房间是否已满
        if enter_room_obj.user_count >= room_conf.MAX_ROOM_USERS_COUNT:
            # return -4, None
            return result_conf.RESULT_CODE_FAIL, None

        # 用户加入
        enter_room_obj.add_user(user_obj)
        self._users[user_obj.uid] = user_obj
        return result_conf.RESULT_CODE_SUCCESS, enter_room_obj.to_message()

    def user_exit_room(self, request):
        """
        用户退出房间
        :param request: EnterRoomRequest
            .rid: uint, 房间id
            .uid: uint, 用户id
        :return:
            result: uint, 0 or 1, 0为成功
            exit_room_obj: VirtualRoom Object or None
        """
        # TODO DEBUG
        print "exit room"
        # uid校验
        user_obj = self._lobby.get_user_by_uid(request.uid)
        if user_obj is None or user_obj.uid not in self._users:
            return result_conf.RESULT_CODE_FAIL, None
        # rid校验
        state_code, exit_room_obj = self._get_room(user_obj.rid)
        if exit_room_obj is None:
            return result_conf.RESULT_CODE_FAIL, None

        # 玩家退出
        exit_room_obj.remove_user(user_obj.uid)
        self._users.pop(user_obj.uid)

        # 房间人数不足1人， 自动销毁
        if exit_room_obj.user_count == 0:
            self._destroy_room(exit_room_obj.rid)
            return result_conf.RESULT_CODE_SUCCESS, None

        return result_conf.RESULT_CODE_SUCCESS, exit_room_obj.to_message()

    def user_auto_match(self, request):
        # TODO 自动匹配
        # 使用heap，注意关于heap的维护时机。
        raise NotImplementedError

    def start_game(self, request):
        """
        玩家开始游戏
        :param request: StartGameRequest
            .rid: uint, 房间id
            .uid: uint, 用户id
        :return:
            result: uint, 0 or 1，0为成功
            start_room_obj: VirtualRoom Object dict, 开始房间对象
            address: dict, {ip: str, port: uint}, GameServer 地址
        """
        # TODO DEBUG
        print "start game"
        # uid校验
        if not self._verify_uid(request.uid, True):
            return result_conf.RESULT_CODE_FAIL, None, None
        # rid校验
        state_code, start_room_obj = self._get_room(request.rid)
        if start_room_obj is None:
            return result_conf.RESULT_CODE_FAIL, None, None

        # 获取GameSever
        game_server = self._lobby.get_best_server()
        # 房间内所有玩家自动设置gid
        start_room_obj.gid = game_server.gid
        return result_conf.RESULT_CODE_SUCCESS, start_room_obj.to_message(), game_server.address

    def end_game(self, request):
        # TODO GameSever发起请求
        raise NotImplementedError

    def get_rooms(self, request):
        """
        获取房间列表
        :param: request:
            .uid: uint, 用户id
        :return:
            result: uint, 0 or 1，0为成功
            VirtualRoom Object dict list or None
        """
        # TODO DEBUG
        print "get rooms"
        # 验证uid
        if not self._verify_uid(request.uid, False):
            return result_conf.RESULT_CODE_FAIL, None

        return result_conf.RESULT_CODE_SUCCESS, [room_obj.to_message() for room_obj in self._rooms]

    def get_room_by_rid(self, request):
        """
        封装_get_room，
        :param request: GetRoomByRidRequest
            .uid: uint, 用户id
            .rid: uint, 房间id
        :return:
            result: uint, 0 or 1，0为成功
            VirtualRoom Object dict or None
        """
        # TODO DEBUG
        print "get room by rid"
        # 验证uid
        if not self._verify_uid(request.uid, False):
            return result_conf.RESULT_CODE_FAIL, None
        # 验证rid
        state_code, room_obj = self._get_room(request.rid)
        if room_obj is None:
            return result_conf.RESULT_CODE_FAIL, None

        return result_conf.RESULT_CODE_SUCCESS, room_obj.to_message()

    def _get_room(self, rid):
        """
        查找房间列表，返回房间信息，通过rid到pos的映射完成用房间的查询
        :param rid: uint, 指定查询的房间rid
        :return:
            -1,None rid到rooms列表的索引的转换异常，房间对象返回None
            -2,None 索引查询得到空的房间对象，房间对象返回None
            -3,None 索引得到的房间rid与查询使用的rid不一致，房间返回None
             0,room object 房间查询成功，返回房间对象
        """
        pos = rid & room_conf.MAX_ROOMS_INDEX
        if (pos < 0) or (pos >= len(self._rooms)):
            return -1, None

        room_object = self._rooms[pos]
        if room_object is None:
            return -2, None
        if room_object.rid != rid:
            return -3, None

        return 0, room_object

    def _build_room(self, room_name):
        """
        创建新的房间
        :return:
            VirtualRoom Object 房间对象
        """
        rid, pos = self._generate_rid()
        new_room_obj = VirtualRoom(rid, room_name)
        self._rooms[pos] = new_room_obj
        self._count += 1
        return new_room_obj

    def _destroy_room(self, rid):
        """
        查找房间列表，返回房间连接信息，通过rid到pos的映射完成用房间的查询
        :param rid: 指定删除的房间rid
        :return:
            -1 rid到rooms列表的索引的转换异常
            -2 索引查询得到空的房间对象
            -3 索引得到的房间rid与查询使用的rid不一致
            -4 房间还存在玩家
             0 房间删除成功
        """
        pos = rid & room_conf.MAX_ROOMS_INDEX
        if (pos < 0) or (pos >= len(self._rooms)):
            return -1

        room_object = self._rooms[pos]
        if room_object is None:
            return -2
        if room_object.rid != rid:
            return -3
        if room_object.user_count != 0:
            return -4
        self._rooms.remove(room_object)
        self._rooms[pos] = None
        return 0

    def _generate_rid(self):
        """
        为新开的房间分配rid
        :return: tuple
            rid, 新开房间rid
            pos，新房间在_rooms中的位置
        """
        pos = -1
        for i in xrange(len(self._rooms)):
            if self._rooms[i] is None:
                pos = i
                break
        if pos < 0:
            pos = len(self._rooms)
            self._rooms.append(None)

        rid = (pos & room_conf.MAX_ROOMS_INDEX) | (self._index << room_conf.MAX_ROOMS_BYTES)

        self._index += 1
        if self._index >= room_conf.MAX_ROOMS_INDEX:
            self._index = 1

        return rid, pos

    def _verify_uid(self, uid, need_in_room):
        if not need_in_room:
            return self._lobby.get_user_by_uid(uid) is not None
        user_obj = self._lobby.get_user_by_uid(uid)
        return user_obj is not None and user_obj.uid in self._users
