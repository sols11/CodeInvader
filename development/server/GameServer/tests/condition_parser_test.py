# -*- coding:utf-8 -*-
# @Time         : 2019/8/18 21:05
# @Author       : jiejianshe@corp.netease.com
# @File         : condition_parser_test.py.py
# @Description: : to do
# @API          :

import sys
sys.path.append('../')
import numpy as np
from game.room.entity.robot.behavior_tree.utils import enums_used
import pytest
import time
from game.room.entity.robot.behavior_tree import behavior_tree
from game.room import room as room_module

class TestParser(object):
    def test_run_if_low_health_from_parse(self):
        """
        机器人初始在（0，0，0），血量65.血量不断-10直到变成35，然后不断+10直到变成65.
        机器人血量<=50时会向敌人（0，0，10）移动2
        所以z坐标应该是0-2-4-6-6-6-6-8
        :return:
        """
        room = room_module.Room(rid=1)
        controlled_robot
        # controlled_robot = room.create_robot('0_robot_0')
        time.sleep(1)
        # enemy_robot = room.create_robot('1_robot_0')

        model_list = [
            [[0, 0, -1, 1, 0, 50], [1, 3, 1, 0], ],
        ]
        controlled_robot.get_behavior_tree(data={'program': model_list})
        room.tick()
        controlled_robot.transform.position.x = 0
        controlled_robot.transform.position.y = 0
        controlled_robot.transform.position.z = 0
        controlled_robot.hp = 65
        controlled_robot.move_speed = 2
        enemy_robot.transform.position.x = 0
        enemy_robot.transform.position.y = 0
        enemy_robot.transform.position.z = 10


        controlled_robot.hp -= 10
        # controlled_robot.tick()
        room.tick()
        assert pytest.approx(0)==controlled_robot.transform.position.z

        controlled_robot.hp -= 10
        # controlled_robot.tick()
        room.tick()
        assert pytest.approx(2) == controlled_robot.transform.position.z

        controlled_robot.hp -= 10
        # controlled_robot.tick()
        room.tick()
        assert pytest.approx(4) == controlled_robot.transform.position.z

        controlled_robot.hp += 10
        # controlled_robot.tick()
        room.tick()
        assert pytest.approx(6) == controlled_robot.transform.position.z

        controlled_robot.hp += 10
        controlled_robot.tick()
        room.tick()
        assert pytest.approx(6) == controlled_robot.transform.position.z

        controlled_robot.hp += 10
        # controlled_robot.tick()
        room.tick()
        assert pytest.approx(6) == controlled_robot.transform.position.z

        controlled_robot.hp -= 10
        # controlled_robot.tick()
        room.tick()
        assert pytest.approx(6) == controlled_robot.transform.position.z

        controlled_robot.hp -= 10
        # controlled_robot.tick()
        room.tick()
        assert pytest.approx(8) == controlled_robot.transform.position.z

# if __name__ == '__main__':
#     TestParser().test_run_if_low_health_from_parse()