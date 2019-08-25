# -*- coding: GBK -*-
from __future__ import division
import errno

# ��������״̬
NET_STATE_STOP = 0  # state: init value
NET_STATE_CONNECTING = 1  # state: connecting
NET_STATE_ESTABLISHED = 2  # state: connected

NET_CONNECTION_NEW = 0  # new connection
NET_CONNECTION_LEAVE = 1  # lost connection
NET_CONNECTION_DATA = 2  # data coming

# �ͻ������ӳ�ʱ����
NET_CLIENT_CONNECTION_TIMEOUT = 180

# ���Ӵ�������
ERROR_CONN_ALREADY = (errno.EWOULDBLOCK, errno.EINPROGRESS, errno.EALREADY)
ERROR_CONN = (errno.EISCONN, errno.ECONNABORTED, errno.ENOTCONN, errno.WSAECONNRESET, errno.ENOTSOCK)

# �������ݰ�ͷ����ʽ������
NET_HEAD_LENGTH_SIZE = 4  # 4 bytes little endian (x86)
NET_HEAD_LENGTH_FORMAT = '<I'


# �������������
MAX_CLIENT_CONNECTIONS = 0xffff
MAX_CLIENT_CONNECTION_BYTES = 16

# select ������ʱ����
SELECT_TIMEOUT = 3000 / 1000  # 50 milliseconds
