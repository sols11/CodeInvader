# -*- coding:UTF-8 -*-
from __future__ import division

import errno

# 网络连接状态
NET_STATE_STOP = 0  # state: init value
NET_STATE_CONNECTING = 1  # state: connecting
NET_STATE_ESTABLISHED = 2  # state: connected

NET_CONNECTION_NEW = 0  # new connection
NET_CONNECTION_LEAVE = 1  # lost connection
NET_CONNECTION_DATA = 2  # data coming

# 客户端连接超时设置
NET_CLIENT_CONNECTION_TIMEOUT = 180

# 连接错误类型
ERROR_CONN_ALREADY = (errno.EWOULDBLOCK, errno.EINPROGRESS, errno.EALREADY)
ERROR_CONN = (errno.EISCONN, errno.ECONNABORTED, errno.ENOTCONN, errno.WSAECONNRESET, errno.ENOTSOCK)

# 网络数据包头部格式及长度
NET_HEAD_LENGTH_SIZE = 4  # 4 bytes little endian (x86)
NET_HEAD_LENGTH_FORMAT = '<I'

# 最大网络连接数
MAX_CLIENT_CONNECTIONS = 0xffff
MAX_CLIENT_CONNECTION_BYTES = 16

# select 阻塞超时设置
SELECT_TIMEOUT = 50 / 1000  # 50 milliseconds

# 广播方式 send_mode
SEND_AREA = 1
SEND_UNI = 2
SEND_BROAD = 3
SEND_OTHERS = 4
