# -*- coding:UTF-8 -*-
import socket
import struct
import time

from config import net_conf
from gate.client_sock import ClientSock
from lib.timer import TimerManager

try:
    import selectors34 as selectors
except ImportError:
    import selectors2 as selectors
from log.game_logging import GameLogging

logger = GameLogging().get_logger(__name__)


class GateHost(object):
    """
    Description：
        Gate服务主模块
    Attributes:
        _sel: 管理客户端连接套接字的selectors
        _sock: 服务器监听套接字, 用于接受客户端的连接
        _clients: 客户端连接列表
        _index:
        _count: 当前客户端连接数
        _msg_queue: 接收来自客户端的信息的列表
        _host_timer: gate模块的任务定时器
    """

    def __init__(self):
        super(GateHost, self).__init__()
        self._sel = selectors.DefaultSelector()
        self._sock = None
        self._clients = []
        self._index = 1
        self._count = 0
        self._msg_queue = []
        self._host_timer = TimerManager()
        self._host_timer.add_repeat_timer(30, self._remove_timeout_client)

    def start(self, host, port):
        """
        开启gate服务，用于管理客户端的连接
        :param host: 服务器IP地址
        :param port: 服务器端口号
        :return: 无
        """
        try:
            if not self._sock:
                self._sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
                self._sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
                self._sock.bind((host, port))
                self._sock.listen(net_conf.MAX_CLIENT_CONNECTIONS)
                self._sock.setblocking(False)
                self._sel.register(self._sock, events=selectors.EVENT_READ, data=None)
                logger.info("(startup server)listening on (%s, %s)" % (host, port))
        except Exception as e:
            logger.error("(startup server): %s" % e.args[0])

    def shutdown(self):
        """
        关闭gate服务器
        :return: 无
        """
        if self._sock:
            try:
                self._sock.close()
            except Exception as e:
                logger.error("(shutdown server): %s" % e.args[0])
        self._sock = None
        self._index = 1

        for client in self._clients:
            if not client:
                continue
            try:
                self._sel.unregister(client.sock)
                client.close()
            except Exception as e:
                logger.error("(disconnect all clients): %s" % e.args[0])

        self._clients = []
        self._count = 0

    def update_active(self, hid):
        """
        更新客户端连接的最近活跃时间，外部可用
        :param hid:
        :return:
        """
        pos = hid & net_conf.MAX_CLIENT_CONNECTIONS
        if (pos < 0) or (pos >= len(self._clients)):
            return -1

        client = self._clients[pos]
        if client is None:
            return -2
        if client.hid != hid:
            return -3

        # update active time when get the heartbeat
        self._clients[pos].active = time.time()
        return 0

    def update_tick(self, hid):
        """
        tick - 在socket发送数据时自动添加在该tick所有包的最前端，如果只更新tick则只需要把selectors中该客户端socket的可写状态打开
        :param hid: 指定需要更新tick的hid
        :return:
            当查询用户失败时返回失败码，返回值见_get_client(hid)函数
        """
        code, client = self._get_client(hid)
        if code < 0:
            return code
        self._sel.modify(client.sock, selectors.EVENT_WRITE | selectors.EVENT_READ, client.hid)

    def read_msg(self):
        """
        获取该tick中所有客户端连接的所有请求信息，交给游戏逻辑处理
        :return:
            msg：客户端发来的消息组成的list，list中每项格式为（hid, data）
        """
        msg = self._msg_queue
        self._msg_queue = []
        return msg

    def write_client(self, hid, data):
        """
        向客户端连接的写缓冲区中添加数据，并给信息打包头部长度
        :param hid: 根据hid指定要分发的客户端连接
        :param data: 写入客户端连接的写缓冲区中的数据
        :return:
            小于 0: 查找客户端连接失败， 返回值见_get_client(hid)函数
            0：写入缓冲区成功
        """
        code, client = self._get_client(hid)
        if code < 0:
            return code
        data = struct.pack(net_conf.NET_HEAD_LENGTH_FORMAT, len(data) + net_conf.NET_HEAD_LENGTH_SIZE) + data
        client.write(data)
        self._sel.modify(client.sock, selectors.EVENT_WRITE | selectors.EVENT_READ, client.hid)
        return 0

    def process(self, tick):
        """
        按tick处理gate服务器模块的数据收发，根据selectors中监听的套接字执行收发操作。send操作完成的套接字监听状态置为只读。
        process开始前先调用gate的定时任务，目前主要的任务为清除不活跃的客户端
        :param tick: 设置该次处理过程的服务器端tick号，用于与客户端之间的消息同步
        :return: 无
        """
        self._host_timer.scheduler()
        events = self._sel.select(timeout=net_conf.SELECT_TIMEOUT)
        for key, mask in events:
            if key.data is None:
                self._accept_connect()
            else:
                code, client = self._get_client(key.data)
                if code < 0:
                    return code
                try:
                    self._msg_queue += client.process_events(mask, tick)
                    if mask & selectors.EVENT_WRITE:
                        self._sel.modify(client.sock, selectors.EVENT_READ, client.hid)
                except Exception as e:
                    logger.warn("(client socket exception): %s" % key.data)
                    if hasattr(e, "errno"):
                        self._remove_client(key.data)

    def _accept_connect(self):
        """
        接收客户端的连接，超过最大连接数则抛出异常
        :return: 无
        """
        conn_sock, addr = self._sock.accept()
        if self._count > net_conf.MAX_CLIENT_CONNECTIONS:
            try:
                conn_sock.close()
                logger.warn("(accept connection): Socket close, Exceed the max connection.")
            except Exception as e:
                logger.error("(socket close): %s" % e.args[0])
                return

        logger.debug("accepted connection...")
        logger.info("(accepted connection) connect from (%s, %s)" % (addr[0], addr[1]))
        hid, pos = self._generate_id()
        client_conn = ClientSock(hid)
        client_conn.set_sock(conn_sock)
        self._clients[pos] = client_conn
        self._sel.register(conn_sock, selectors.EVENT_READ | selectors.EVENT_WRITE, data=hid)
        self._count += 1

    def _remove_client(self, hid):
        """
        移除客户端连接，其文件描述符fd从selectors中移除，客户端连接信息从客户端列表中移除
        :param hid: 指定移除的客户端 hid
        :return:
            -1 hid到clients列表的索引的转换异常
            -2 索引查询得到空的客户端连接
            -3 索引得到的客户端连接hid与查询使用的hid不一致
             0 移除客户端连接正常
        """
        pos = hid & net_conf.MAX_CLIENT_CONNECTIONS
        if (pos < 0) or (pos >= len(self._clients)):
            return -1

        client = self._clients[pos]
        if client is None:
            return -2
        if client.hid != hid:
            return -3
        self._sel.unregister(client.sock)
        self._clients[pos] = None
        client.close()
        logger.info("(disconnect client) disconnect from (%s, %s)" % (client.addr[0], client.addr[1]))
        return 0

    def _remove_timeout_client(self):
        """
        移除超时的不活跃连接，以客户端的active为最近活跃时间
        :return: 无
        """
        for i in xrange(len(self._clients)):
            if self._clients[i] and (time.time() - self._clients[i].active) > net_conf.NET_CLIENT_CONNECTION_TIMEOUT:
                try:
                    hid = self._clients[i].hid
                    addr = self._clients[i].addr
                    self._remove_client(hid)
                    logger.info("(remove timeout client) timeout client: %s(%s: %s)" % (hid, addr[0], addr[1]))
                except Exception as e:
                    logger.error("(remove timeout client) %s" % e.args[0])

    def _generate_id(self):
        """
        为新连接生成可用的hid和pos
        hid；客户连接索引，给外层服务使用
        pos： gate内部用户列表的索引
        :return: hid, pos
        """
        pos = -1
        for i in xrange(len(self._clients)):
            if self._clients[i] is None:
                pos = i
                break
        if pos < 0:
            pos = len(self._clients)
            self._clients.append(None)

        hid = (pos & net_conf.MAX_CLIENT_CONNECTIONS) | (self._index << net_conf.MAX_CLIENT_CONNECTION_BYTES)

        self._index += 1
        if self._index >= net_conf.MAX_CLIENT_CONNECTIONS:
            self._index = 1

        return hid, pos

    def _get_client(self, hid):
        """
        查找客户连接列表，返回客户端连接信息，通过hid到pos的映射完成用客户端连接的查询
        :param hid: 指定查询的客户端 hid
        :return:
            -1,None hid到clients列表的索引的转换异常，客户端连接信息返回None
            -2,None 索引查询得到空的客户端连接，客户端连接信息返回None
            -3,None 索引得到的客户端连接hid与查询使用的hid不一致，客户端连接信息返回None
             0,None 客户端连接查询成功，返回客户端连接的信息
        """
        pos = hid & net_conf.MAX_CLIENT_CONNECTIONS
        if (pos < 0) or (pos >= len(self._clients)):
            return -1, None

        client = self._clients[pos]
        if client is None:
            return -2, None
        if client.hid != hid:
            return -3, None

        return 0, client
