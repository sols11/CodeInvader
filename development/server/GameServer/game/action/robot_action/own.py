# -*- coding:utf-8 -*-
# @Time        : 2019/8/14 22:02
# @Author      : liyihang@corp.netease.com
# @File        : other.py
# @Description : 机器人行为，只和自身相关，无交互, 如移动
# @API         :


from __future__ import absolute_import

from config import result_conf
from game.action.action_base import ActionBase
from game.room.entity.robot.behavior_tree.behavior_tree import BehaviorTree
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class RobotMove(ActionBase):
    # 机器人移动, 服务器主动发送
    """
    message RobotMoveResponse
    {
        int32 eid = 1; // 机器人eid
        repeated CommonStruct.NetVector3 way_points = 2; // 路点列表
    }
    """

    def _action(self):
        self.entity_obj.do_move()
        self.response.result = result_conf.SUCCESS
        self.response.eid = self.entity_obj.eid
        self.response.way_points = self.entity_obj.way_points

        logger.debug('Robot Move end')


class RobotGetBehaviorTree(ActionBase):
    # 机器人生成行为树

    def _action(self):
        if not isinstance(self.data.program, list):
            model_list = []
            sentences = self.data.program._values
            for sentence in sentences:
                sentence_list = []
                clauses = sentence.sentence._values
                for clause in clauses:
                    if clause.clauseType == 0:
                        condition = clause.condition
                        clause_list = [0, condition.subjectType, condition.subjectInd, condition.statusType]
                        clause_list.extend(condition.parameters._values)
                    else:
                        action = clause.action
                        clause_list = [1, action.actionType, action.targetType, action.targetInd]
                    sentence_list.append(clause_list)
                model_list.append(sentence_list)
            logger.debug(model_list)
            self.entity_obj.behavior_tree = BehaviorTree.from_model_list(model_list)
        else:
            self.entity_obj.behavior_tree = BehaviorTree.from_model_list(self.data.program)
        self.entity_obj.behavior_tree.robot = self.entity_obj

