import grpc
from config import GRPC_HOST, GRPC_PORT
from protocol_services.base_service import BaseService
from protocol_services.protobuf_msg.pb2 import AccountMessage_pb2
from protocol_services.protobuf_msg.pb2_grpc import AccountMessage_pb2_grpc
from protocol_services.dispatcher import Dispatcher


class AccountService(BaseService):
    """

    """
    def __init__(self):
        super(AccountService, self).__init__(AccountMessage_pb2.ACCOUNT_SERVICE)
        channel = grpc.insecure_channel("%s:%s" % (GRPC_HOST, GRPC_PORT))
        self.stub = AccountMessage_pb2_grpc.AccountStub(channel)

    def init(self):
        self.register(AccountMessage_pb2.CID_LOGIN, self.login_account)
        self.register(AccountMessage_pb2.CID_REGISTER, self.register_account)

    def login_account(self, msg):
        login_request = self.unpack(AccountMessage_pb2.LoginRequest, msg.data)
        login_request.hid = msg.hid

        login_response = self.stub.login(login_request)

        msg.hid = [msg.hid]
        msg.data = self.pack(login_response)
        Dispatcher().add_response(msg)

    def register_account(self, msg):
        register_request = self.unpack(AccountMessage_pb2.RegisterRequest, msg.data)
        register_response = self.stub.register(register_request)

        msg.hid = [msg.hid]
        msg.data = self.pack(register_response)
        Dispatcher().add_response(msg)
