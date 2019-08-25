# -*- coding:utf-8 -*-
# @Time        : 2019/8/11 17:08
# @Author      : liyihang@corp.netease.com
# @File        : user.py
# @Description : 用户类, 用户级别操作


class User(object):
    """
    Description:
        大厅或房间中的玩家
    Attributes:
        _uid: uint, 用户id
        _rid: uint, 用户所在房间id
        _gid: uint, 用户游戏开始所在服务器id
        _hid: uint, 用户Gate中连接id
    """

    def __init__(self, uid, hid):
        """
        实例化玩家
        :param uid: uint, 玩家id
        """
        super(User, self).__init__()
        self._uid = uid
        self._hid = hid
        self._rid = None
        self._gid = None

    @property
    def uid(self):
        """
        获取用户id
        :return: uid, uint, 用户id
        """
        return self._uid

    @property
    def hid(self):
        """
        获取连接id
        :return: hid: uint, 连接id
        """
        return self._hid

    @property
    def rid(self):
        """
        获取玩家房间id
        :return: uint or None, 房间id
        """
        return self._rid

    @rid.setter
    def rid(self, rid):
        """
        设置玩家房间号
        :param rid: uint or None， 房间id
        """
        self._rid = rid

    @property
    def gid(self):
        """
        获取玩家游戏服务器id
        :return: uint or None, 游戏服务器id
        """
        return self._gid

    @gid.setter
    def gid(self, value):
        """
        设置玩家房间号
        :param value: uint or None， 游戏服务器id
        """
        self._gid = value

    def has_room(self):
        """
        判断玩家是否在房间
        :return: bool, 在房间返回True
        """
        return self._rid is not None

    def is_in_game(self):
        """
        判断玩家是否在游戏
        :return:bool， 在游戏返回True
        """
        return self._gid is not None

    def to_message(self):
        res = {}
        for k, v in self.__dict__.iteritems():
            # 去除开头下划线, 内部不能有_
            res[k.split('_', 2)[-1]] = v
        return res
