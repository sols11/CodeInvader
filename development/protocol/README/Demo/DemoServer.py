# -*- encoding: utf-8 -*-
import Demo_pb2
import socket


class SimpleServer(object):
    def __init__(self, ip='0.0.0.0', port=6999):
        self.ip = ip
        self.port = port
        self.host = None

    def start(self):
        self.host = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.host.bind((self.ip, self.port))
        self.host.listen(5)
        while True:
            conn, address = self.host.accept()
            print "Get a connection"

            while True:
                recv = conn.recv(1024)
                request = Demo_pb2.DemoRequest()
                request.ParseFromString(recv)
                if request.uid == 1:
                    print "hi"
                else:
                    print "bye"
                response = Demo_pb2.DemoResponse()
                response.uid = 100
                response.is_ok = True
                conn.send(response.SerializeToString())


if __name__ == "__main__":
    Server = SimpleServer()
    Server.start()
