# -*- coding:utf-8 -*-
# @Time        : 2019/8/18 19:44
# @Author      : liyihang@corp.netease.com
# @File        : own.py
# @Description :
# @API         : TODO


from config import result_conf, player_conf, net_conf
from game.action.action_base import ActionBase
from log.game_logging import GameLogging
from protocol.pb2 import Struct

logger = GameLogging().get_logger(__name__)


class GamePlayerOnline(ActionBase):
    # 玩家上线
    """
    message PlayerOnlineRequest
    {
        int32 rid = 1;
        int32 eid = 2;
        int32 uid = 3;
    }

    message PlayerOnlineResponse
    {
        int32 result = 1;
        int32 eid = 2;
    }
    """

    def _action(self):
        logger.debug("Player Online...")
        self.response.result = result_conf.SUCCESS
        # 检测玩家是否在线
        player = self.room_obj.player_mgr.get_player_by_uid(self.data.uid)
        if player is None:
            # 新玩家进入游戏, 创建玩家
            player = self.room_obj.create_player(player_conf.BORN_PLAYER)
            player.uid = self.data.uid
            self.response.eid = player.eid
            logger.debug("Create Player...")
            # TODO 其他客户端创建该玩家对应角色
        else:
            # 玩家已在线, 断线重连
            self.response.eid = player.eid
            logger.debug("Reconnect...")
        # aoi系统更新
        self.room_obj.aoi.new_client_enter(self.response.eid, self.room_obj.msg_hid)
        # 配置单播放
        self.response.send_mode = net_conf.SEND_UNI
        self.response.send_eid = player.eid
        # 该玩家获取场景资源
        self.entity_obj.pull(data={'player_eid': player.eid})


class GamePull(ActionBase):
    # 某玩家拉取场景资源
    """
    message PullResponse
    {
        int32 result = 1;
        repeated CommonStruct.NetPlayerData players = 2;
        repeated CommonStruct.NetRobotData robots = 3;
        repeated CommonStruct.NetComputerData computers = 4;
    }
    """

    def _action(self):
        logger.debug("Pull all...")
        self.response.result = result_conf.SUCCESS
        self.response.players = [entity.get_struct(Struct.NetPlayerData) for entity in
                                 self.room_obj.player_mgr.get_all_entities()]
        self.response.robots = [entity.get_struct(Struct.NetRobotData) for entity in
                                self.room_obj.enemy_robot_mgr.get_all_entities()]
        self.response.computers = [entity.get_struct(Struct.NetComputerData) for entity in
                                   self.room_obj.computer_mgr.get_all_entities()]
        self.response.resource_items = [entity.get_struct(Struct.NetItemData) for entity in
                                        self.room_obj.item_mgr.get_all_entities()]
        self.response.backpack_info = [backpack_item for backpack_item in
                                       self.room_obj.get_entity(self.data.player_eid).backpack.get_backpack_info()]

        # 单播
        self.response.send_mode = net_conf.SEND_UNI
        self.response.send_eid = self.data.player_eid
