# -*- coding:UTF-8 -*-
import time
from config import *
from gate.gate_host import GateHost
from protocol_services import services, dispatcher
from log.game_logging import GameLogging


logger = GameLogging().get_logger(__name__)


class LobbyGate(object):
    """
    Description：
        游戏服务器主模块
    Attributes:
        gateHost：gate服务器模块
        tick_no: 游戏服务器心跳号
    """
    def __init__(self):
        super(LobbyGate, self).__init__()
        self.gateHost = GateHost()
        self.dispatcher = dispatcher.Dispatcher()
        self.tick_no = 0

    def run(self):
        """
        服务器运行主循环
        :return: 无
        """
        self.init()

        while True:
            try:
                current = time.time()
                self.tick()
                if int(round((time.time() - current) * 1000)) < TICK_TIMEOUT:
                    time.sleep(time.time() - current)
            except Exception as e:
                logger.error("(game server) %s" % e.args[0])

    def tick(self):
        """
        服务器心跳逻辑，每次服务器心跳都会处理来自客户端的连接及数据收发任务，以及游戏世界的逻辑事件
        :return: 无
        """
        self.gateHost.process(self.tick_no)
        self.tick_no = (self.tick_no + 1) % TICK_LIMITATION

        self.dispatcher.msg_enqueue(self.gateHost.read_msg())
        self.dispatcher.dispatch()
        for msg in self.dispatcher.msg_dequeue():
            self.gateHost.write_client(msg[0], msg[1])

    def init(self):
        self.gateHost.start(GATE_HOST, GATE_PORT)
        services.Services().init()


if __name__ == "__main__":
    server = LobbyGate()
    server.run()
