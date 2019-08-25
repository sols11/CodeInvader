# -*- coding:UTF-8 -*-
import logging
import coloredlogs
import logging.config


class GameLogging(object):
    """
    Description:
        用于输出游戏日志
    Attributes:
        _logger： 日志调度者
    """
    def __init__(self):
        super(GameLogging, self).__init__()

    @staticmethod
    def get_logger(name, level=logging.INFO, log_file="game.log"):
        # format for colored logs
        fmt = "%(asctime)s - %(name)s > %(funcName)s - %(levelname)s - %(message)s"
        date_fmt = '%Y-%m-%d %H:%M:%S'
        log_file = 'log/log_file/' + log_file

        logger = logging.getLogger(name)
        logger.setLevel(level=level)

        formatter = logging.Formatter(fmt=fmt, datefmt=date_fmt)

        # file handler
        file_handler = logging.FileHandler(log_file)
        file_handler.setFormatter(formatter)
        logger.addHandler(file_handler)

        # colored console log
        coloredlogs.install(level=logging.WARN, logger=logger, fmt=fmt, datefmt=date_fmt)
        return logger
