# -*- coding:utf-8 -*-
# @Time        : 2019/8/18 18:55
# @Author      : liyihang@corp.netease.com
# @File        : computer.py
# @Description : 
# @API         : TODO
from config import result_conf
from game.action.action_base import ActionBase
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class ComputerCrack(ActionBase):
    # 电脑被破解
    """
    message ComputerCrackResponse {
      int32 result = 1;
      int32 eid = 2;
      bool startOrStop = 3;
    }
    """

    def _action(self):
        is_decode = self.data.decode
        if is_decode:
            # 破解请求
            logger.debug("Computer start cracked")
            self.entity_obj.do_begin_crack(self.data.cracker_eid)
            self.response.startOrStop = True
            # TODO DEBUG 定时调用
            # self.entity_obj.crack_complete(data={'rid': self.room_obj.rid, 'eid': self.entity_obj.eid},
            #                                delay=10)
            # logger.debug("(ComputerCrack) 10s later invoke CrackComplete action")
        else:
            # 停止破解
            logger.debug("Computer stop cracked")
            # 更新自身数据
            self.entity_obj.do_stop_crack()
            self.response.startOrStop = False
        self.response.result = result_conf.SUCCESS


class ComputerCrackComplete(ActionBase):
    """
    message CrackCompleteRequest {
      int32 rid = 1;
      int32 eid = 2; // computer_id
    }
    message CrackCompleteResponse {
      int32 result = 1;
      int32 eid = 2; // player_id
      int32 computer_id = 3;
    }
    """

    def _action(self):
        self.response.computer_id = self.entity_obj.eid
        # 校验
        if not self.entity_obj.verify_complete():
            logger.debug("(verify fail)This computer can't complete")
            self.response.result = result_conf.FAIL
            return
        logger.debug("Computer crack complete")
        self.entity_obj.do_crack_complete()
        self.response.result = result_conf.SUCCESS
        self.response.eid = self.entity_obj.cracker_eid
        # TODO 后续添加资源生成
