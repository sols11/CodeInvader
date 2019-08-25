# -*- coding:utf-8 -*-
# @Time        : 2019/8/18 16:24
# @Author      : liyihang@corp.netease.com
# @File        : other.py
# @Description : 
# @API         : TODO

from config import result_conf
from config.robot_conf import *
from game.action.action_base import ActionBase
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class RobotMoveTo(ActionBase):
    # 机器人移至目标, 计算一系列路点, 加入机器人路点队列
    """
    data:
        .target_id : uint, 所需要移动至目标的eid
    """

    def _action(self):
        logger.debug("Robot Move to %d" % self.data.target_eid)
        # 获取目标
        target_obj = self.room_obj.get_entity(self.data.target_eid)
        if target_obj is None:
            return
        # 覆盖前一条寻路
        self.entity_obj.do_clear_points()
        # TODO 后续需要根据地图信息获取无障碍路点, 现在暂时由此方法代替
        v = target_obj.transform.position.vec3_dir(self.entity_obj.transform.position) * self.entity_obj.move_speed
        tmp_points = []
        old_pos = self.entity_obj.transform.position
        tmp_points.append(old_pos)
        while tmp_points[-1].euc_distance(target_obj.transform.position) > 2:
            next_pos = Struct.NetVector3(x=v[0] * 0.1 + tmp_points[-1].x, y=old_pos.y, z=v[2] * 0.1 + tmp_points[-1].z)
            tmp_points.append(next_pos)
        # pop掉当前位置
        tmp_points.pop(0)
        self.entity_obj.do_add_points(tmp_points)
        self.entity_obj.move()


class RobotAttack(ActionBase):
    # 机器人攻击
    """
    message RobotAttackResponse {
        int32 eid = 1; // 攻击的机器人eid
        int32 hand = 2; // 所使用的手
        repeated int32 targets_eid = 3; // 攻击目标eid列表
    }
    """

    def _action(self):
        logger.debug("Robot attack %d" % self.data.target_eid)
        # 获取目标
        targets_obj = []
        try:
            # list
            for eid in self.data.target_eid:
                target_obj = self.room_obj.get_entity(eid)
                if target_obj:
                    targets_obj.append(target_obj)
            self.response.targets_eid = self.data.target_eid
        except TypeError:
            # 单个eid
            targets_obj.append(self.room_obj.get_entity(self.data.target_eid))
            self.response.targets_eid = [self.data.target_eid]
        # 校验对象
        if not targets_obj:
            logger.debug("(No target object to attack)")
            return
        # 得到武器数据
        hand = self.entity_obj.left_hand if self.data.hand == LEFT_HAND else self.entity_obj.right_hand
        # TODO 接口
        weapon = hand.get_struct()
        # 目标受伤
        for target_obj in targets_obj:
            target_obj.take_damage(data={'attack_id': self.entity_obj.eid, 'weapon': weapon})
        # 消息发送
        self.response.result = result_conf.SUCCESS
        self.response.hand = self.data.hand


class RobotTakeDamage(ActionBase):
    # 机器人受伤害
    """
    data:
        .

    message RobotTakeDamageResponse {
        int32 eid = 1; // 受伤机器人eid
        CommonStruct.DamageInfo damage_info = 2; // 伤害信息
        bool is_dead = 3; // 受伤完是否死亡
    }

    message DamageInfo {
      int32 attack_id = 1;
      repeated int32 hurt_id = 2;
      int32 attack = 3;
      bool break_defense = 4;
      bool slow_down = 5;
      int32 slow_down_speed = 6;
      bool beat_back = 7;
      int32 beat_back_force = 8;
    }
    """

    def _action(self):
        self.response.result = result_conf.SUCCESS
        self.entity_obj.hp -= self.data.damage
