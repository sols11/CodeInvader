# -*- coding:utf-8 -*-
# @Time        : 2019/8/22 15:55
# @Author      : liyihang@corp.netease.com
# @File        : timer.py
# @Description : 
# @API         : TODO
import collections
import heapq
import time


class LaterAction(object):
    """
    Description:
        定时调用action的do方法
    Attributes:
        _delay: deque, uint, 延迟时间队列
        _action: Action Object, 调用行为
        canceled: bool, 取消标志
        timeout:  int, 下次调用时间
    """

    def __init__(self, action, delay):
        super(LaterAction, self).__init__()
        self._delay = delay
        self._action = action

        self.canceled = False
        self.timeout = time.time() + self._delay.popleft()

    def __le__(self, other):
        return self.timeout <= other.timeout

    def call(self):
        """
        调用任务, 计算下次时间
        :return: 标志位, 方便Timer管理
        """
        self._action.do()
        if len(self._delay) == 0:
            return False
        else:
            self.timeout += self._delay.popleft()
            return True

    def cancel(self):
        self.canceled = True

    def add_times(self, delay):
        """
        增加一次调用
        :param delay: 增加调用时间间隔
        """
        self._delay.append(delay)


class EveryAction(LaterAction):
    """
    Description:
        间隔某周期重复调用action的do方法
    """

    def __init__(self, action, delay):
        first_time = delay[0]
        super(EveryAction, self).__init__(action, delay)
        # 父类已经取出一次, 重新放回
        self._delay.append(first_time)

    def call(self):
        """
        反复调用任务, 计算下次调用时间
        :return 标志位, 方便Timer管理
        """
        self._action.do()
        next_time = self._delay.popleft()
        self.timeout += next_time
        self._delay.append(next_time)
        return True


class ActionTimer(object):

    def __init__(self):
        super(ActionTimer, self).__init__()
        self._tasks = []
        self._cancelled_num = 0

    def add_action(self, action, delay, repeat=False):
        """
        添加定时action
        :param action: 定时执行的action
        :param delay: uint or iter, 延时调用时间
        :param repeat: bool, 是否周期调用
        """
        delay_lst = collections.deque()
        if delay is list:
            delay_lst.extend(delay)
        else:
            delay_lst.append(delay)
        if repeat is False:
            timer_action = LaterAction(action, delay_lst)
            heapq.heappush(self._tasks, timer_action)
        else:
            timer_action = EveryAction(action, delay_lst)
            heapq.heappush(self._tasks, timer_action)

        return timer_action

    def scheduler(self):
        """
        启用定时调用
        """
        now = time.time()

        while self._tasks and now >= self._tasks[0].timeout:
            call = heapq.heappop(self._tasks)
            if call.canceled:
                self._cancelled_num -= 1
                continue

            try:
                repeated = call.call()
            except (KeyboardInterrupt, SystemExit):
                raise

            if repeated:
                heapq.heappush(self._tasks, call)

    def cancel_by_timer(self, timer):
        """
        取消定时器
        :param timer: 需要取消的定时器
        """
        if timer not in self._tasks:
            return

        timer.cancel()
        self._cancelled_num += 1

        # 动态大小调整
        if float(self._cancelled_num) / len(self._tasks) > 0.25:
            self.remove_cancelled_tasks()

    def remove_cancelled_tasks(self):
        tmp_tasks = []
        for t in self._tasks:
            if not t.cancelled:
                tmp_tasks.append(t)

        self._tasks = tmp_tasks
        heapq.heapify(self._tasks)
        self._cancelled_num = 0
        return

    def reset_timer(self):
        """
        清空定时器中所有任务
        """
        for task in self._tasks:
            task.cancel()
            self._cancelled_num += 1
        self.remove_cancelled_tasks()
