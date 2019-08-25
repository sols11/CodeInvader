# -*- coding:utf-8 -*-
# @Time        : 2019/8/12 17:34
# @Author      : liyihang@corp.netease.com
# @File        : game_server_info.py
# @Description : GameServer状态记录
# @API         :
# 1.更新GameServer负载状态: update
# 2.获取定长时间内sleep时长： sleep_total_time
# 3.获取GameServer id： gid
# 4.获取GameServer 地址： address

import time


class GameServerInfo(object):
    """
    Description:
        记录GameServer状态记录
    Attributes:
        _gid: uint, GameServer id
        _update_time: float， 最近报备时间
        _sleep_total_time: float, 最近定长时间内sleep时长
    """

    def __init__(self, gid, ip, port):
        """
        实例化GameServer信息对象
        :param gid: uint, GameServer id
        :param ip: str, GameServer ip
        :param port: uint, GameServer port
        """
        self._gid = gid
        self._ip = ip
        self._port = port
        self._update_time = None
        self._sleep_total_time = None

    def update(self, sleep_total_time):
        """
        :param sleep_total_time: float， 定长时间内sleep时长
        """
        self._update_time = time.time()
        self._sleep_total_time = sleep_total_time

    @property
    def update_time(self):
        return self._update_time

    @property
    def gid(self):
        return self._gid

    @property
    def sleep_total_time(self):
        """
        获取最近定长时间内sleep时长
        :return: float or None, 定长时间内sleep时长
        """
        return self._sleep_total_time

    @sleep_total_time.setter
    def sleep_total_time(self, value):
        self._sleep_total_time = value

    @property
    def address(self):
        """
        获取该GameServer地址
        :return: dict, {ip: str, port: uint}
        """
        return {'ip': self._ip, 'port': self._port}

    def __le__(self, other):
        if self.sleep_total_time is None or other.sleep_total_time is None:
            raise ValueError("can't compare None")
        return self.sleep_total_time < other.sleep_total_time
