/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/09
Description:
    简介：实现客户端到服务器的连接
    作用：用于客户端到服务器的socket网络连接，并提供了数据收发的接口
    使用：
        1. Connect(host, port) 连接游戏服务器
        2. Close() 主动断开与服务器的网络连接
        3. Receive() 异步调用接收从服务器发送过来的数据
        4. ProcessBuff() 将接收缓冲区中的数据处理成独立的消息并分发给消息分发器
        5. Send(pb) 向服务器发送消息
    补充：
History:
----------------------------------------------------------------------------*/

using System;
using System.Net.Sockets;
using System.Linq;
using Google.Protobuf;
using UnityEngine;
using ProtocolMessage;

namespace SFramework
{
//网络链接
    public class Connection
    {
        //Socket
        private Socket socket;

        //缓冲区大小
        const int BUFFER_SIZE = 1024;

        //网络数据缓冲区
        private byte[] readBuff = new byte[BUFFER_SIZE];
        private int recvCount = 0;

        //消息长度，用于分包，处理粘包问题
        private Int32 msgLen = 0;
        private byte[] msgBytes = new byte[sizeof(Int32)];

        // 游戏服务器心跳
        private ushort tickNo = 0xffff;

        //心跳时间
        public float lastTickTime = 0;

        public float heartBeatTime = 30;

        //消息分发
        public MsgDistribution msgDist = new MsgDistribution();

        ///状态
        public enum Status
        {
            None,
            Connected,
        };

        public Status status = Status.None;


        //连接服务端
        public bool Connect(string host, int port)
        {
            try
            {
                //socket
                socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                //Connect
                socket.Connect(host, port);
                //BeginReceive
                socket.BeginReceive(readBuff, recvCount,
                    BUFFER_SIZE - recvCount, SocketFlags.None,
                    Receive, readBuff);
                Debug.Log("服务器连接成功");
                //修改网络连接状态
                status = Status.Connected;
                
                return true;
            }
            catch (Exception e)
            {
                Debug.Log("服务器连接失败:" + e.Message);
                return false;
            }
        }

        //关闭连接
        public bool Close()
        {
            try
            {
                socket.Close();
                return true;
            }
            catch (Exception e)
            {
                Debug.Log("连接关闭失败:" + e.Message);
                return false;
            }
        }

        //接收回调
        private void Receive(IAsyncResult ar)
        {
            try
            {
                recvCount += socket.EndReceive(ar);
                // 从缓冲区中分包
                ProcessBuff();
                socket.BeginReceive(readBuff, recvCount,
                    BUFFER_SIZE - recvCount, SocketFlags.None,
                    Receive, readBuff);
            }
            catch (Exception e)
            {
                Debug.Log("Receive Error:" + e.Message);
                status = Status.None;
            }
        }

        //消息处理
        private void ProcessBuff()
        {
            //小于长度字节
            if (recvCount < sizeof(Int32))
                return;
            // 获取消息长度
            Array.Copy(readBuff, msgBytes, sizeof(Int32));
            msgLen = BitConverter.ToInt32(msgBytes, 0);
            if (recvCount < msgLen)
                // 缓冲区数据少于消息长度时继续接收数据
                return;
            byte [] msgBuff = new byte[msgLen-sizeof(Int32)];
            Array.Copy(readBuff, sizeof(Int32), msgBuff,0, msgLen-sizeof(Int32));
            if (msgBuff.Length == sizeof(Int16))
            {
                // 更新游戏服务器心跳号，用于数据包接收检测
                UpdateTickNo(msgBuff);
            }
            else
            {
                
                //处理消息
                ProtoMessage protocolMessage = (ProtoMessage) ProtoMessage.Descriptor.Parser.ParseFrom(msgBuff);
                

                lock (msgDist.msgList)
                {
                    msgDist.msgList.Add(protocolMessage);
                }
            }


            // 清除缓冲区中已处理数据
            Array.Copy(readBuff, msgLen, readBuff, 0, recvCount - msgLen);
            recvCount -= msgLen;
            if (recvCount > 0)
            {
                // 继续处理缓冲区中剩下的数据
                ProcessBuff();
            }
        }


        public bool Send(ProtoMessage protocol)
        {
            if (status != Status.Connected)
            {
                Debug.LogError("发送错误：请先连接服务器");
                return true;
            }

            byte[] b = protocol.ToByteArray();
            if (b.Length != 0)
            {
                // 打包消息长度，用于消息分包
                byte[] sendMsglen = BitConverter.GetBytes(b.Length + sizeof(Int32) + sizeof(Int16));

                byte[] sendbuff = sendMsglen.Concat(BitConverter.GetBytes(tickNo)).Concat(b).ToArray();
                socket.Send(sendbuff);
            }

            return true;
        }

        public void Update()
        {
            //消息
            msgDist.Update();
            //心跳
            if (status == Status.Connected)
            {
                if (Time.time - lastTickTime > heartBeatTime)
                {
                    //HeartBeat.Process();
                    lastTickTime = Time.time;
                }
            }
        }

        public void UpdateTickNo(byte[] tickMessage)
        {
            tickNo = BitConverter.ToUInt16(tickMessage, 0);
        }
    }
}