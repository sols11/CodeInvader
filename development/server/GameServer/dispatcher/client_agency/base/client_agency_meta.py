# -*- coding:utf-8 -*-
# @Time        : 2019/8/14 20:07
# @Author      : liyihang@corp.netease.com
# @File        : client_agency_meta.py
# @Description : 客户端代理元类, 实现自动注册
# @API         :


from dispatcher.client_agency.base.client_agency import ClientAgency
from dispatcher.dispatcher import Dispatcher


class ClientAgencyMeta(type):
    """
    Description:
        客户端代理元类，实现该类中的ClientAgency变量自动注册在Dispatcher中
    """

    def __new__(mcs, name, bases, attrs):
        dispatcher = Dispatcher()
        for k, v in attrs.iteritems():
            if isinstance(v, ClientAgency):
                # 正向注册
                dispatcher.register(v.proto_id, v)
                # 反向注册
                dispatcher.reverse_register(v.action_name, v)

        return type.__new__(mcs, name, bases, attrs)
