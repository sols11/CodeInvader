# -*- coding:UTF-8 -*-
import time
from config import server_conf
from dispatcher.dispatcher import Dispatcher
from game.room_mgr import RoomMgr
from gate.gate_host import GateHost
from log.game_logging import GameLogging
# 自动注册
from dispatcher import client_agency

logger = GameLogging().get_logger(__name__)


class GameServer(object):
    """
    Description：
        游戏服务器主模块
    Attributes:
        gateHost：gate服务器模块。 网络层
        dispatcher: 协议层， 负责消息分发， 激活逻辑层tick
        tick_no: 游戏服务器心跳号
        sleep_time: 单位时间sleep时间
    """

    def __init__(self, gid):
        super(GameServer, self).__init__()
        # 本机数据
        self.tick_no = 0
        self.sleep_time = 0
        self.gid = gid

        # 网络层
        self.gate = GateHost()
        # 协议层
        self.dispatcher = Dispatcher()
        # 逻辑层
        self.room_mgr = RoomMgr()

    def run(self, port):
        """
        服务器运行主循环
        """
        # 配置host
        self.gate.start('0.0.0.0', port)

        while True:
            try:
                tick_moment = time.time()
                self._tick()
                self._sleep(tick_moment)
            except Exception as e:
                logger.error("(game server) %s" % e.args[0])

    def _tick(self):
        """
        服务器心跳逻辑，每次服务器心跳都会处理来自客户端的连接及数据收发任务，以及游戏世界的逻辑事件
        """
        # 网络层： send & recv
        self.gate.process(self.tick_no)
        self.tick_no = (self.tick_no + 1) % server_conf.TICK_LIMITATION

        # 协议层: host --> dispatcher
        self.dispatcher.msg_enqueue(self.gate.read_msg())
        # 协议层：dispatcher --> game
        self.dispatcher.dispatch(self.room_mgr)

        # 逻辑层：tick
        self.room_mgr.tick()

        # 协议层：game --> dispatcher
        self.dispatcher.add_responses(self.room_mgr)
        # 协议层: dispatcher --> host
        for msg in self.dispatcher.msg_dequeue():
            self.gate.write_client(msg[0], msg[1])

    def _sleep(self, tick_moment):
        """
        服务器休眠时间
        """
        current = time.time()
        if (current - tick_moment) < server_conf.TICK_TIMEOUT:
            # 未超时
            self.sleep_time += server_conf.TICK_TIMEOUT - (current - tick_moment)
            time.sleep(server_conf.TICK_TIMEOUT - (current - tick_moment))
        else:
            # 超时
            server_conf.TICK_REAL_TIME = current - tick_moment

    @property
    def sleep_time_interval(self, ):
        """
        定时调用，主动向LobbyServer报备最近定长时间内该GameSever休眠时间
        :return: sleep_time: float, 最近定长时间服务器休眠时间
        """
        sleep_time = self.sleep_time
        self.sleep_time = 0
        return sleep_time
