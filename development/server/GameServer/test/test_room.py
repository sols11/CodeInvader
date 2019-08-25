# -*- coding:utf-8 -*-
# @Time        : 2019/8/20 21:25
# @Author      : liyihang@corp.netease.com
# @File        : test_room.py
# @Description : 
# @API         : TODO
from unittest import TestCase

from game.room.room import Room


class TestRoom(TestCase):
    def setUp(self):
        self.room = Room(rid=1)
        self.robot = self.room.create_friend_robot(None)
        self.player = self.room.create_player(None)
        self.computer = self.room.create_computer(None)

    def tearDown(self):
        pass

    def test_remove_entity(self):
        self.room.remove_entity(self.robot.eid)
        self.room.remove_entity(self.player.eid)
        self.room.remove_entity(self.computer.eid)
        self.assert_(self.robot not in self.room.entities.values())
        self.assert_(self.computer not in self.room.entities.values())
        self.assert_(self.player in self.room.entities.values())
