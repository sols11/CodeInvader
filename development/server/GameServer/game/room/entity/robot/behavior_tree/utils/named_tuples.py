# -*- coding:utf-8 -*-
# @Time         : 2019/8/14 11:53
# @Author       : jiejianshe@corp.netease.com
# @File         : named_tuples.py
# @Description: : to do
# @API          :


import collections

Entity = collections.namedtuple('Entity', ['type', 'parameter'])
Status = collections.namedtuple('Status', ['type', 'parameters'])