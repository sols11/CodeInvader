# -*- coding:utf-8 -*-
# @Time        : 2019/8/11 14:25
# @Author      : liyihang@corp.netease.com
# @File        : grpc_server.py
# @Description : grpc服务，一类服务使用一个端口
# @API:
# 1.添加服务: add_service
# 2.启动服务器: start
# 3.关闭服务器: stop
import grpc
from concurrent import futures
from config import server_conf

from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class GRPCServer(object):
    """
    Description
        一个使用GRPC通信的Server， 某一大类服务统一注册在该模块
    Attributes:
        _server: server object, 服务器实体
        _services: lst, 服务列表
        _is_start: bool, 服务器状态
        _has_started: bool, 服务是否开启过
    """

    def __init__(self, port, max_workers=server_conf.MAX_WORKERS):
        """
        生成服务器实例，绑定ip和端口
        :param port: int, 该服务器绑定端口
        :param max_workers: int, 并发最大线程数量
        """
        super(GRPCServer, self).__init__()
        self._server = grpc.server(futures.ThreadPoolExecutor(max_workers=max_workers))
        self._server.add_insecure_port('0.0.0.0:%s' % str(port))
        self._services = []
        self._is_start = False
        self._has_started = False

    def add_service(self, service_obj):
        """
        将service注册在该server下
        :param service_obj: obj, 实现了具体方法的service类的对象
        """
        self._services.append(service_obj)

    def start(self):
        """
        启动server
        """
        self._register_all_service()
        try:
            self.stop()
            self._server.start()
            self._has_started = True
        except Exception as e:
            logger.error("(start rpc server) %s" % e.args[0])

    def stop(self, grace=0):
        """
        定时关闭server
        :param grace: uint or None, 关闭时间(s)
        """
        if not self._is_start:
            return
        if grace is int and grace < 0:
            raise ValueError("grace can't be negative")
        try:
            self._server.stop(grace)
        except Exception as e:
            logger.error("(close rpc server) %s" % e.args[0])

    def _register_all_service(self):
        # 仅注册一次
        if self._has_started:
            return
        for service in self._services:
            service.register_self(self._server)
