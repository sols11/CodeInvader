# -*- coding:utf-8 -*-
# @Time        : 2019/8/11 16:55
# @Author      : liyihang@corp.netease.com
# @File        : virtual_room.py
# @Description : lobby下的虚拟房间
# @API         :
# 1. 获取房间rid： rid
# 2. 获取房间内玩家数量： user_count
# 3. 添加玩家: add _user
# 4. 删除玩家：remove_user
# 5. 判断房间是否开局: is_start

from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class VirtualRoom(object):
    """
    Description:
        虚拟房间
    Attributes:
        _name: 房间名
        _rid: uid, 房间id
        _gid: None or uint, 房间所在游戏服务器id
        _users: dict, (uint)uid->(User)user_obj, 玩家对象
    """

    def __init__(self, rid, room_name):
        """
        实例化一个虚拟房间
        :param rid: uint, 房间rid
        :param room_name: str, 房间名称
        """
        super(VirtualRoom, self).__init__()
        self._rid = rid
        self._name = room_name
        self._gid = None
        self._users = {}

    @property
    def rid(self):
        """
        获取房间rid
        :return: uint
        """
        return self._rid

    @property
    def user_count(self):
        """
        获取房间玩家数量
        :return: uint
        """
        return len(self._users)

    def add_user(self, user_obj):
        """
        玩家加入房间
        :param user_obj: user object, 玩家对象
        """
        self._users[user_obj.uid] = user_obj
        # 设置用户在当前房间
        user_obj.rid = self.rid

    def remove_user(self, user_uid):
        """
        玩家退出房间
        :param user_uid: uint, 玩家id
        :return:user_obj: UserObject, 所删除玩家对象
        """
        if user_uid not in self._users:
            return

        user_obj = self._users.pop(user_uid)
        user_obj.rid = None
        return user_obj

    def get_user_by_uid(self, user_uid):
        """
        通过uid获取玩家对象
        :param user_uid: uint, 用户id
        :return: User Object or None
        """
        return self._users.setdefault(user_uid, None)

    @property
    def gid(self):
        """
        获取房间所在游戏服务器id
        :return: uint or None, None代表房间未开始游戏
        """
        return self._gid

    @gid.setter
    def gid(self, value):
        """
        为房间分配游戏服务器id， 房间开始游戏或者结束游戏
        并为房间内玩家设置gid
        :param value: uint or None
        """
        self._gid = value
        # 更改房间下所有玩家游戏状态
        for user_obj in self._users.values():
            user_obj.gid = value

    def to_message(self):
        """
        返回相应message object所需要的实例变量字典
        :return: dict
        """
        res = {}
        for k, v in self.__dict__.iteritems():
            # users dict 转 users list
            if isinstance(v, dict):
                res['users_lst'] = []
                for user_obj in v.values():
                    res['users_lst'].append(user_obj.to_message())
                continue
            # 去除开头下划线, 内部不能有_
            res[k.split('_', 1)[-1]] = v
        return res

    def __le__(self, other):
        return self.user_count > other.user_count
