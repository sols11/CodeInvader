# -*- coding:utf-8 -*-
# @Time        : 2019/8/17 17:07
# @Author      : liyihang@corp.netease.com
# @File        : __init__.py
# @Description : 
# @API         :
from __future__ import division

import numpy as np

from protocol.pb2.Struct.CommonStruct_pb2 import *


def to_vec(self):
    """
    vec3转换为np数组
    :param self: vec3
    :return: np数组
    """
    return np.array([self.x, self.y, self.z])


def euc_distance(self, other):
    """
    计算两点的距离
    :param self: vec3
    :param other: vec3
    :return: float, 两点间距离
    """
    pos1 = self.to_vec()
    pos2 = other.to_vec()
    return np.linalg.norm(pos1 - pos2)


def vec3_add(self, other):
    """
    vec3相加
    :param self: vec3
    :param other: vec3
    :return: vec3
    """
    x = self.x + other.x
    y = self.y + other.y
    z = self.z + other.z
    return NetVector3(x=x, y=y, z=z)


def vec3_min(self, other):
    """
    vec3相减
    :param self: vec3
    :param other: vec3
    :return: vec3
    """
    x = self.x - other.x
    y = self.y - other.y
    z = self.z - other.z
    return NetVector3(x=x, y=y, z=z)


def vec3_mul(self, other):
    """
    vec3和某数相乘
    :param self: vec3
    :param other: num
    :return: vec3
    """
    x = self.x * other
    y = self.y * other
    z = self.z * other
    return NetVector3(x=x, y=y, z=z)


def vec3_dir(self, other):
    """
    该点到另一点的方向
    :param self:vec3
    :param other:vec3
    :return: np数组
    """
    direction = self.vec3_min(other).to_vec()
    return direction / np.linalg.norm(direction)


NetVector3.to_vec = to_vec

NetVector3.euc_distance = euc_distance

NetVector3.vec3_add = vec3_add

NetVector3.vec3_min = vec3_min

NetVector3.vec3_dir = vec3_dir

NetVector3.vec3_mul = vec3_mul


def opposite(self):
    return NetQuaternion(x=0, y=-self.y, z=0, w=self.w)


NetQuaternion.opposite = opposite
