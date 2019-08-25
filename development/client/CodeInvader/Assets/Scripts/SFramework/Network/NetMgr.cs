/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/09
Description:
    简介：网络管理器
    作用：
    使用：
    补充：
History:
----------------------------------------------------------------------------*/
using System;
using ProtocolMessage;

namespace SFramework
{
    public static class NetMgr
    {
        private static string _host = Config.LobbyHost;
        private static int _port = Config.LobbyPort;

        public static Connection conn = new Connection();

        public static bool Connect()
        {
            // offline debug
            if (Config.OFFLINE) return false;
            return conn.Connect(_host, _port);
        }

        public static bool ReConnect(string serverHost, int serverPort)
        {
            // offline debug
            if (Config.OFFLINE) return false;
            if (serverHost == _host && serverPort == _port && conn.status == Connection.Status.Connected)
                return true; // IP地址与当前一致，且处于连接状态，不需要重连
            if (conn.status == Connection.Status.Connected)
                conn.Close(); // 先断开当前连接
            bool connectResult = conn.Connect(serverHost, serverPort);
            if (connectResult)
                SetServerAddr(serverHost, serverPort); // 重连成功，切换新的IP地址
            else
                conn.Connect(_host, _port); // 重连回原来的服务器
            return connectResult;
        }

        public static bool Disconnect()
        {
            return conn.Close();
        }

        private static void SetServerAddr(string host, int port)
        {
            // TODO 添加IP格式校验
            _host = host;
            _port = port;
        }

        public static void Send(ProtoMessage message)
        {
            // offline debug
            if (Config.OFFLINE) return;

            /*if (conn.status != Connection.Status.Connected)
                Connect();*/
            conn.Send(message);
        }

        public static void Update()
        {
            conn.Update();
        }
    }
}