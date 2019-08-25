# -*- coding:UTF-8 -*-
import os
import logging
import logging.config

import coloredlogs


class GameLogging(object):
    """
    Description:
        用于输出游戏日志
    Attributes:
        _logger： 日志调度者
    """
    def __init__(self):
        super(GameLogging, self).__init__()

    def get_logger(self, name, level=logging.INFO, log_file="game.log"):
        # format for colored logs
        fmt = "%(asctime)s - %(name)s > %(funcName)s - %(levelname)s - %(message)s"
        datefmt = '%Y-%m-%d %H:%M:%S'
        log_file = 'log/log_files/' + log_file

        logger = logging.getLogger(name)
        logger.setLevel(level=level)

        formatter = logging.Formatter(fmt=fmt, datefmt=datefmt)

        # file handler
        if not os.path.exists(os.path.dirname(log_file)):
            os.makedirs(os.path.dirname(log_file))

        file_handler = logging.FileHandler(log_file)
        file_handler.setFormatter(formatter)
        logger.addHandler(file_handler)

        # colored console log
        coloredlogs.install(level=logging.DEBUG, logger=logger, fmt=fmt, datefmt=datefmt)
        return logger
