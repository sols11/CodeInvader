# -*- coding:utf-8 -*-
# @Time        : 2019/8/15 16:34
# @Author      : liyihang@corp.netease.com
# @File        : other.py
# @Description : 玩家行为，与其他实体产生交互， 如拾取
# @API         :
from collections import deque
from config import result_conf
from game.action.action_base import ActionBase
from protocol.pb2.Struct import NetItemData
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class PlayerPick(ActionBase):
    # 玩家拾取道具

    def _action(self):
        logger.debug("Player Pick...")
        try:
            item = self.room_obj.get_entity(self.data.picked_eid)
            if not item.verify_collectable(self.entity_obj):
                self.response.result = result_conf.FAIL
                return
            backpack = self.entity_obj.backpack.backpack

            if item.item_id not in backpack[item.item_type]:
                backpack[item.item_type][item.item_id] = deque()
            backpack[item.item_type][item.item_id].append(item.eid)
            item.collectable = False
            self.response.result = result_conf.SUCCESS
            self.response.item_data = item.to_net_item_data()
            self.response.count = len(backpack[item.item_type][item.item_id])
        except Exception as e:
            print("Error(Inventory): Pick %s" % e.args[0])
            self.response.result = result_conf.FAIL


class PlayerTakeOut(ActionBase):
    # 玩家取出道具

    def _action(self):
        logger.debug("Player TakeOut...")
        backpack = self.entity_obj.backpack.backpack
        if self.data.item_id in backpack[self.data.item_type]:
            eid = backpack[self.data.item_type][self.data.item_id].pop()
            count = len(backpack[self.data.item_type][self.data.item_id])
            if count == 0:
                backpack[self.data.item_type].pop(self.data.item_id)
            item = self.room_obj.get_entity(eid)
            self.response.result = result_conf.SUCCESS
            self.response.item_data = item.to_net_item_data()
            self.response.count = count
        else:
            logger.error("此物体不存在玩家背包中")
            self.response.result = result_conf.FAIL


class PlayerCrack(ActionBase):
    """
    message CrackRequest {
      int32 rid = 1;
      int32 eid = 2;
      int32 computer_id = 3;
      bool decode = 4;
    }
    message CrackResponse {
      int32 result = 1;
      int32 eid = 2;
      int32 computer_id = 3;
      bool decode = 4;
      CommonStruct.NetTransform transform = 5;
    }
    """

    # 玩家破译电脑
    def _action(self):
        if self.data.decode:
            # 请求破解
            # 电脑状态校验
            computer = self.room_obj.get_entity(self.data.computer_id)
            self.response.computer_id = computer.eid
            if not computer.verify_crack():
                logger.debug("(verify fail)Computer is completed or decoding")
                self.response.result = result_conf.FAIL
                return
            # 验证校验者
            if not self.entity_obj.verify_crack_state():
                self.response.result = result_conf.FAIL
                logger.debug("(verify fail)Player is cracking")
                return
            if not computer.verify_cracker_pos(self.entity_obj.transform.position):
                self.response.result = result_conf.FAIL
                logger.debug("(verify fail)Cracker pos verify fail")
                return
            logger.debug("Player request to start crack")
            computer.crack(data={'decode': True, 'cracker_eid': self.entity_obj.eid})
            self.entity_obj.do_move(computer.get_crack_transform())
            self.entity_obj.do_crack(computer.eid)
            self.response.result = result_conf.SUCCESS
            self.response.computer_id = computer.eid
            self.response.decode = True
            self.response.transform = self.entity_obj.transform
        else:
            # 请求终止破解, 此时computer_id无效
            logger.debug("Player request to stop crack")
            computer = self.room_obj.get_entity(self.entity_obj.crack_computer_eid)
            if computer:
                self.entity_obj.do_cancel_crack()
                computer.crack(data={'decode': False})
                self.response.computer_id = computer.eid
            self.response.result = result_conf.SUCCESS
            self.response.decode = False
