# -*- coding:utf-8 -*-
# @Time        : 2019/8/14 22:01
# @Author      : liyihang@corp.netease.com
# @File        : other.py
# @Description : 玩家行为，只和自身相关，无交互, 如移动
# @API         :

from config import result_conf
from game.action.action_base import ActionBase
from log.game_logging import GameLogging
from protocol.pb2 import Struct

logger = GameLogging().get_logger(__name__)


class PlayerMove(ActionBase):
    # 玩家移动
    """
    message PlayerMoveRequest {
      int32 rid = 1;
      int32 eid = 2;
      CommonStruct.NetVector3 velocity = 3;
      CommonStruct.NetQuaternion rot = 4;
    }

    message PlayerMoveResponse {
      int32 result = 1;
      int32 eid = 2;
      CommonStruct.NetVector3 pos = 3;
      CommonStruct.NetQuaternion rot = 4;
    }
    """

    def _action(self):
        # 默认接受旋转
        self.entity_obj.do_rota(self.data.rot)
        self.response.rot = self.entity_obj.transform.rotation
        # 速度验证
        # if not self.entity_obj.verify_speed(self.data.velocity):
        #     logger.debug("Speed is not normal")
        #     self.response.result = result_conf.FAIL
        #     return
        # 计算下一刻位置
        v = Struct.NetVector3(x=self.data.velocity.x * self.entity_obj.move_speed,
                              y=self.data.velocity.y * self.entity_obj.move_speed,
                              z=self.data.velocity.z * self.entity_obj.move_speed)
        old_pos = self.entity_obj.transform.position
        next_pos = Struct.NetVector3(x=v.x * 0.1 + old_pos.x, y=old_pos.y, z=v.z * 0.1 + old_pos.z)
        # 位置验证
        if not self.entity_obj.verify_pos(next_pos):
            logger.debug("Next pos can't reach")
            self.response.result = result_conf.FAIL
            return
        # 校验通过, 更新服务端状态
        self.entity_obj.do_pos(next_pos)
        self.response.result = result_conf.SUCCESS
        # 预测客户端位置
        self.response.pos = Struct.NetVector3(x=v.x * 0.1 + old_pos.x, y=old_pos.y, z=v.z * 0.1 + old_pos.z)
