# -*- coding:utf-8 -*-
# @Time        : 2019/8/14 20:02
# @Author      : liyihang@corp.netease.com
# @File        : aoi.py
# @Description : 状态同步
# @API         : TODO


class Aoi(object):
    """
    Description:
        AOI模块，根据实体选择广播对象
    Attributes:
        hid : 玩家eid到hid的映射， 非广播用
        hids : 广播集合
        eid_mul_hid : dict，eid(uint) -> list(hid), eid到多个hid的映射, 广播某实体操作, aoi
    """

    def __init__(self):
        self.hid = {}
        self.hids = set()
        # TODO 维护
        self.eid_mul_hid = {}

    def broadcast(self):
        """
        全局广播
        :return list: hid: uint
        """
        return self.hids

    def uni_cast(self, eid):
        """
        单播
        :param eid: 需要单播的player_eid
        :return: list, 1个元素， hid: uint, or None
        """
        return [self.hid.get(eid, None)]

    def area_cast(self, eid):
        """
        区域广播用
        :param eid: 该区域发生行为的实体eid
        :return list: hid: uint
        """
        # TODO
        # return self.eid_mul_hid[eid]
        return self.hids

    def others_cast(self, eid):
        """
        屏蔽广播
        :param eid: 需要屏蔽广播的player_eid
        :return: list: hid: uint
        """
        return [hid for player_eid, hid in self.hid.iteritems() if player_eid != eid]

    def new_client_enter(self, eid, hid):
        """
        新的客户端加入到房间
        玩家断线重连，hid不同，会默认覆盖
        :param eid:  用户对应玩家实体eid
        :param hid:  客户端对应hid
        """
        self.hid[eid] = hid
        self.hids.add(hid)
