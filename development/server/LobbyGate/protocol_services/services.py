from lib.singleton_meta import SingletonMeta
from protocol_services.account.account_service import *
from protocol_services.room.room_service import *


class Services(object):
    __metaclass__ = SingletonMeta

    def __init__(self):
        super(Services, self).__init__()
        self._initialized = False

    def init(self):
        if not self._initialized:
            AccountService().init()
            RoomService().init()
            self._initialized = True
