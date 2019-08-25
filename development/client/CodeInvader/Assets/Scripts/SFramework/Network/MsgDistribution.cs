/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/09
Description:
    简介：接收的消息控制器
    作用：管理服务器回传的消息列表，按帧分发处理消息
    使用：
    补充：
History:
----------------------------------------------------------------------------*/
using ProtocolMessage;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework
{
    //消息分发
    public class MsgDistribution
    {
        //每帧处理消息的数量
        public int num = 15;

        //消息列表
        public List<ProtoMessage> msgList = new List<ProtoMessage>();

        //委托类型
        public delegate void Delegate(ProtoMessage proto);
        //事件监听表
        Dispatcher dispatcher = Dispatcher.Instance;

        //Update
        public void Update()
        {
            for (int i = 0; i < num; i++)
            {
                if (msgList.Count > 0)
                {
                    dispatcher.Dispatch(msgList[0]);
                    lock (msgList)
                        msgList.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }
        }
    }
}