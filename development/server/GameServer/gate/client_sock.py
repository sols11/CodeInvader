# -*- coding:UTF-8 -*-
import time
import errno
import socket
import struct
from config import net_conf

try:
    import selectors34 as selectors
except ImportError:
    import selectors2 as selectors
from log.game_logging import GameLogging


logger = GameLogging().get_logger(__name__)


class ClientSock(object):
    """
    Description：
        管理客户端连接信息的模块
    Attributes:
        sock：客户端连接的套接字
        addr: 客户端连接的地址
        hid：客户端连接的索引，外部可读
        active：客户端最近活跃时间，由心跳协议更新
        _state: 客户端连接状态
        _recv_buffer: 客户端读缓冲区
        _send_buffer: 客户端连接写缓冲区
        _error_code: 客户端状态错误码
    """
    def __init__(self, hid):
        super(ClientSock, self).__init__()
        self.sock = None
        self.addr = None
        self.hid = hid
        self.active = time.time()
        self._state = net_conf.NET_STATE_STOP
        self._send_buffer = b''
        self._recv_buffer = b''

        self._error_code = 0

    def status(self):
        """
        获取客户端连接状态
        :return:
        """
        return self._state

    def set_sock(self, sock):
        """
        设置客户端的套接字
        :param sock: 客户端的socket套接字
        :return: 无
        """
        self.sock = sock
        self.sock.setblocking(False)
        self.sock.setsockopt(socket.SOL_SOCKET, socket.SO_KEEPALIVE, 1)
        self._state = net_conf.NET_STATE_ESTABLISHED
        self.addr = sock.getpeername()

    def to_connect(self):
        """
        尝试连接客户端
        :return:
             0：连接成功
             1：已连接
            -1：连接失败
        """
        if self._state == net_conf.NET_STATE_ESTABLISHED:
            return 1
        if self._state != net_conf.NET_STATE_CONNECTING:
            return -1
        try:
            self.sock.recv(0)  # try recv to connect with empty buffer
        except socket.error, (code, strerror):
            if code in net_conf.ERROR_CONN_ALREADY:
                self._state = net_conf.NET_STATE_ESTABLISHED
                self._recv_buffer = ''
                return 1

            self.close()
            return -1

        self._state = net_conf.NET_STATE_ESTABLISHED
        return 0

    def close(self):
        """
        断开客户端连接
        :return:
            0：断开连接成功
        """
        self._state = net_conf.NET_STATE_STOP
        if not self.sock:
            return 0
        try:
            self.sock.close()
        except Exception as e:
            logger.error("(close socket) %s" % e.args[0])
        self.sock = None
        return 0

    def send(self, tick):
        """
        按tick发送消息
        :param tick: 更新客户端的tick号，并发送_send_buffer中的消息
        :return: 无
        """
        tick_byte = struct.pack('H', tick)
        data = struct.pack(net_conf.NET_HEAD_LENGTH_FORMAT, len(tick_byte)
                           + net_conf.NET_HEAD_LENGTH_SIZE) + tick_byte
        try:
            if self._send_buffer:
                data += self._send_buffer
            self.sock.sendall(data)
            self._send_buffer = b''
        except Exception as e:
            logger.error("(msg send) %s" % e.args[0])

    def recv(self):
        """
        接收客户端发来的消息，存储在_recv_buffer中
        :return: 接收消息的长度
        """
        rdata = ''
        while 1:
            text = ''
            try:
                text = self.sock.recv(1024)
                if not text:
                    self._error_code = errno.ENOTCONN
                    return -1
            except socket.error, (code, strerror):
                if code not in net_conf.ERROR_CONN_ALREADY:
                    self._error_code = code
                    return -1
            if text == '':
                break

            rdata = rdata + text
        if len(rdata) > 0:
            self._recv_buffer = self._recv_buffer + rdata
        return len(rdata)

    def write(self, data):
        """
        向_send_buffer中写消息
        :param data: 写入的消息
        :return:
        """
        try:
            self._send_buffer += data
        except Exception as e:
            logger.error("(write socket buffer) %s" % e.args[0])

    def read(self):
        """
        读出_recv_buffer中的消息，将_recv_buffer中的所有数据分成各条独立的消息
        :return: 从_recv_buffer中解析出来的所有消息
        """
        msg = []
        head_size = net_conf.NET_HEAD_LENGTH_SIZE
        while len(self._recv_buffer) > head_size:
            msg_len = struct.unpack(net_conf.NET_HEAD_LENGTH_FORMAT, self._recv_buffer[0: head_size])[0]
            if msg_len > len(self._recv_buffer):
                return msg
            else:
                self._recv_buffer = self._recv_buffer[head_size:]
                msg_data = self._recv_buffer[0: msg_len - head_size]
                self._recv_buffer = self._recv_buffer[msg_len - head_size:]
                msg.append((self.hid, msg_data))
        return msg

    def process_events(self, mask, tick):
        """
        按tick处理收发逻辑
        :param mask: 该客户端连接的套接字的读写就绪状态
        :param tick: 该次处理的tick号，用于更新客户端的tick信息
        :return:
        """
        msg = []
        if self._state == net_conf.NET_STATE_CONNECTING:
            self.to_connect()
        if self._state == net_conf.NET_STATE_ESTABLISHED:
            if mask & selectors.EVENT_READ:
                # 套接字可读
                if self.recv() < 0:
                    raise OSError(self._error_code, '')
                msg += self.read()
            if mask & selectors.EVENT_WRITE:
                # 套接字可写
                self.send(tick)
        return msg
