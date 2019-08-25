# -*- coding:utf-8 -*-
# @Time        : 2019/8/11 21:43
# @Author      : liyihang@corp.netease.com
# @File        : base_service.py
# @Description : 服务抽象基类， 实现自动注册

from abc import ABCMeta, abstractmethod


class BaseService(object):
    """
    Description:
        服务的抽象基类， 实现register_self功能
    """
    __metaclass__ = ABCMeta

    @abstractmethod
    def register_self(self, server):
        pass
