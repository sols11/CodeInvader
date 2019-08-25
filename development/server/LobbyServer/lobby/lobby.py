# -*- coding:utf-8 -*-
# @Time        : 2019/8/11 20:49
# @Author      : liyihang@corp.netease.com
# @File        : lobby.py
# @Description : 单例大厅类
# @Api:
# 1. 用户登陆:user_login
# 2. 用户注册:user_register
# 3. 游戏服注册:sever_register
# 4. 游戏服更新:server_update

from __future__ import absolute_import
import time
import heapq

from config import result_conf
from db_manager.db_mgr import DBMgr
from lib.singleton_meta import SingletonMeta
from lobby.game_server_info.game_server_info import GameServerInfo
from lobby.user.user import User
from lib.id_generator32 import SnowFlake
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class Lobby(object):
    """
    Description:
        单例类， 提供大厅相关操作
    Attributes:
        _online_users : dict (uint)uid-(User)user_obj, 统计所有在线玩家
        _game_servers: dict (uint)gid->(GameServerInfo)game_server_info_obj, 记录GameServer服务器状态
        _game_servers_pq: heap, (GameSeverInfo)game_server_info_obj, 优先队列
    """
    __metaclass__ = SingletonMeta

    def __init__(self):
        super(Lobby, self).__init__()
        self._online_users = {}
        self._game_servers = {}
        self._game_servers_pq = []
        # TODO DEBUG
        self.test_add_user(1, 1)
        self.test_add_user(2, 2)

    def user_login(self, request):
        try:
            username = request.username
            password = self._encrypt(request.password)
            result, user = DBMgr().user_doc.find(username=username)
            if result == 1:
                if user['password'] == password:
                    # TODO
                    # self._online_users[user['uid']] = User(uid=uid)
                    return 1, user['uid']
                else:
                    return 0, 0  # password not match
            if result == 0:
                return -1, 0  # user not exist
            return -2, 0  # Unkown error
        except Exception as e:
            logger.error("(login) %s" % e.args[0])
            return -2, 0  # Unknown error

    def user_register(self, request):
        try:
            username = request.username
            password = self._encrypt(request.password)
            uid = SnowFlake().make_snowflake(timestamp_ms=time.time())
            while True:
                result, _ = DBMgr().user_doc.find(uid=uid)
                if result == 1:
                    uid = SnowFlake().make_snowflake(timestamp_ms=time.time())
                    continue
                if result == 0:
                    break
            result = DBMgr().user_doc.insert(uid=uid, username=username, password=password)
            if result >= 0:
                # 1: register error, 0: user exist
                return result
            if result < 0:
                return -1  # other error
        except Exception as e:
            logger.error("(register) %s" % e.args[0])
            return -1  # other error

    def _encrypt(self, password):
        # TODO
        return password

    def user_exit(self, request):
        # TODO 用户正常退出
        # 维护online_users
        raise NotImplementedError

    def get_user_by_uid(self, uid):
        """
        根据uid获取在线玩家对象
        :param uid: uint， 玩家id
        :return: None or User Object
        """
        return self._online_users.setdefault(uid, None)

    def server_register(self, request):
        """
        游戏服务器发现，如果重复，直接置换为新服务器状态
        :param request: ServerRegisterRequest
            .uint gid
            .str ip
            .uint port
        :return: result， uint, 0, 默认成功
        """
        print "server register"
        game_server_info_obj = GameServerInfo(request.gid, request.ip, request.port)
        self._game_servers[game_server_info_obj.gid] = game_server_info_obj
        return result_conf.RESULT_CODE_SUCCESS

    def server_update(self, request):
        """
        游戏服务器状态更新
        :param request: SeverUpdateRequest
            .gid : uint
            .sleep_total_time: float
        :return: result, uint
        0 更新成功
        1 更新失败，找不到对应服务器
        """
        print "server update"
        if request.gid not in self._game_servers:
            return result_conf.RESULT_CODE_FAIL
        self._game_servers[request.gid].sleep_total_time = request.sleep_total_time
        # 维护游戏服务器优先队列
        self._game_servers_pq = list(self._game_servers.values())
        heapq.heapify(self._game_servers_pq)
        return result_conf.RESULT_CODE_SUCCESS

    def get_best_server(self):
        """
        获取状态最好的服务器
        :return: GameServerInfo object
        """
        return self._game_servers_pq[0]

    # TODO DEBUG
    def test_add_user(self, uid, hid):
        test_user = User(uid, hid)
        self._online_users[test_user.uid] = test_user
