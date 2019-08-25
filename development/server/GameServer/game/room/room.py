# -*- coding:utf-8 -*-
# @Time        : 2019/8/14 15:27
# @Author      : liyihang@corp.netease.com
# @File        : game_agencies.py
# @Description : 房间模块， 房间级别管理， 管理实例对象, 游戏关卡
# @API         : TODO
# 1. 获取实体: get_entity
# 2. 判断aoi: aoi_response
# 3.
from collections import namedtuple, deque

from config import robot_conf, computer_conf, net_conf, resource_conf, entity_conf
from game.room.entity.master import Master
from game.room.virtual.aoi import Aoi
from game.room.virtual.map import Map
from game.room.virtual.mgr.item_mgr import ComputerMgr, ItemMgr
from game.room.virtual.mgr.player_mgr import PlayerMgr
from game.room.virtual.mgr.robot_mgr import FriendRobotMgr, EnemyRobotMgr
from game.room.virtual.timer import ActionTimer
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class Room(object):
    """
    Description:
        房间类，一局游戏对应一个房间实体
    Attributes:
        rid: uint， rid， 房间id
        tick_num: uint，房间帧号
        room_actions: list, namedtuple(do(function object), data(dict)), 本地待调用的action队列
        _room_msgs: list, tuple(BaseAction Object, hid(uint), tick_num(uint))，网络上待调用的action队列
        _room_responses: list, namedtuple(list(hid), response(dict))), 处理完action所生成的回复队列
                eg: [([1,2], {'result':1}]), ([1], {'result':0, Transform Object})]
        msg_hid: 当前处理网络消息所对应的hid

        entities: dict， eid(uint) -> Entity Object， eid到实体的映射
        player_mgr: PlayerMgr Object, 玩家实体管理对象
        friend_robot_mgr: RobotMgr Object, 机器人实体管理对象
        computer_mgr: ItemMgr Object, 道具实体管理对象
        master: Master Object, 游戏总管
        map: Map Object, 地图对象
        aoi, Aoi Object, AOI对象
    """

    def __init__(self, rid):
        super(Room, self).__init__()
        '''
        房间状态
        '''
        self.rid = rid
        self.tick_num = 0
        self.room_actions = deque()
        self._room_msgs = deque()
        self._room_responses = []
        self.msg_hid = None

        '''
        房间实体
        '''
        # 全体实体
        self.entities = {}
        # 玩家实体管理
        self.player_mgr = PlayerMgr(self)
        # 友方机器人实体管理
        self.friend_robot_mgr = FriendRobotMgr(self)
        # 敌方机器人实体管理
        self.enemy_robot_mgr = EnemyRobotMgr(self)
        # 电脑实体管理
        self.computer_mgr = ComputerMgr(self)
        # 游戏物品资源实体管理
        self.item_mgr = ItemMgr(self)

        '''
        房间数据
        '''
        # 游戏总管
        self.master = Master(self)
        # 地图信息
        self.map = Map()
        # Aoi信息
        self.aoi = Aoi()
        # 定时action行动
        self.action_timer = ActionTimer()

        # TODO DEBUG 后续应在外层RoomMgr中调用
        self.init()

    def init(self):
        """
        初始化场景资源
        """
        # master加入实体管理
        self.entities[self.master.eid] = self.master
        # TODO DEBUG
        self.create_computer(computer_conf.BORN_COMPUTER)
        self.create_resource_item(resource_conf.BORN_RESOURCE_ITEM)
        self.create_friend_robot(robot_conf.LIGHT_ROBOT)
        self.create_enemy_robot(robot_conf.LIGHT_ROBOT)

    def tick(self):
        """
        房间级tick, 逻辑更新房间内所有实体状态
        """
        # 维护tick
        self.tick_num += 1
        # 清空上轮回复
        self._room_responses = []

        # 服务器本地行为, 调用接口会产生action, 放入room_actions
        for entity in self.entities.values():
            entity.tick()

        # 执行本地所产生的actions
        while len(self.room_actions) > 0:
            room_action = self.room_actions.popleft()
            # 会自动将产生的回复放入_room_responses中
            room_action.do()

        # 远端客户端行为， 执行actions
        while len(self._room_msgs) > 0:
            net_action, self.msg_hid, tick_num = self._room_msgs.popleft()
            # 调用网络层action, 会自动将产生的回复放入_room_responses中
            net_action.do(obj=self)
            # action中由实体对象调用其他action，会将action加入到room_actions
            while len(self.room_actions) > 0:
                room_action = self.room_actions.popleft()
                room_action.do()

        # 执行时间action
        self.action_timer.scheduler()

        self.msg_hid = None

    '''
    对外接口
    '''

    def create_player(self, entity_data):
        """
        创建玩家实体， 并赋值数据
        :param entity_data:  dict or object
        :return: Player Object
        """
        player = self.player_mgr.create_entity()
        player.assign_data(entity_data)
        self.entities[player.eid] = player
        return player

    def create_friend_robot(self, entity_data):
        """
        创建友方机器人实体， 并赋值数据
        :param entity_data:  dict
        :return: Robot Object
        """
        robot = self.friend_robot_mgr.create_entity()
        robot.assign_data(entity_data)
        self.entities[robot.eid] = robot
        return robot

    def create_enemy_robot(self, entity_data):
        """
        创建敌方机器人实体， 并赋值数据
        :param entity_data:  dict
        :return: Robot Object
        """
        robot = self.enemy_robot_mgr.create_entity()
        robot.assign_data(entity_data)
        self.entities[robot.eid] = robot
        return robot

    def create_computer(self, entity_data):
        """
        创建玩家实体， 并赋值数据
        :param entity_data:  dict
        :return: Computer Object
        """
        computer = self.computer_mgr.create_entity()
        computer.assign_data(entity_data)
        self.entities[computer.eid] = computer
        return computer

    def create_resource_item(self, entity_data):
        """
        创建装备资源实体，并赋值数据
        :param entity_data: dict
        :return: Equipment Object
        """
        item = self.item_mgr.create_entity()
        item.assign_data(entity_data)
        self.entities[item.eid] = item
        return item

    def get_entity(self, eid):
        """
        根据eid获取实体对象
        :param eid: uint, 实体id
        :return: Entity Object or None
        """
        return self.entities.get(eid, None)

    def remove_entity(self, eid):
        """
        根据eid删除对象
        :param eid: uint
        """
        if eid not in self.entities:
            logger.error("(remove entity fail)")
            return
        type_id = (eid >> 16)
        # 从管理器中删除， 不支持删除玩家
        if type_id == entity_conf.PLAYER_TYPE_ID:
            logger.error("(remove entity) can't remove player")
            return
        elif type_id == entity_conf.COMPUTER_TYPE_ID:
            self.computer_mgr.remove_entity(eid)
        elif type_id == entity_conf.FRIEND_ROBOT_TYPE_ID:
            self.friend_robot_mgr.remove_entity(eid)
        # 从全局实例中删除
        self.entities.pop(eid)

    '''
    对外访问
    '''

    @property
    def room_msgs(self):
        return self._room_msgs

    @room_msgs.setter
    def room_msgs(self, value):
        """
        获取待调用action队列
        :param value: list, tuple(action(Action Object), hid(uint), tick(uint))
        """
        # 直接赋值，清空上一轮行动队列
        self._room_msgs = deque(value)

    @property
    def room_responses(self):
        """
        向RoomMgr提供回复
        :return: list, response
        """
        # 清空回复队列
        return self._room_responses

    def add_room_response(self, response):
        """
        更新回复队列
        :param response: dict
        """
        RoomResponse = namedtuple("RoomResponse", ["hids", "response"])
        # TODO AOI
        send_mode = response.send_mode
        if send_mode == net_conf.SEND_AREA:
            hids = self.aoi.area_cast(response.send_eid)
        elif send_mode == net_conf.SEND_UNI:
            hids = self.aoi.uni_cast(response.send_eid)
        elif send_mode == net_conf.SEND_OTHERS:
            hids = self.aoi.others_cast(response.send_eid)
        else:
            hids = self.aoi.broadcast()
        self._room_responses.append(RoomResponse(hids, response))
