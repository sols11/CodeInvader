/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/15 16:28
Description:
    Response for Account Service Protocol Message
History:
----------------------------------------------------------------------------*/
/*using System;
using UnityEngine;
using SFramework;
using ProtocolMessage;
using AccountMessage;

namespace ProjectScript
{
    public class ServiceNotification : BaseNotification
    {
        public ServiceNotification() : base((int)proto_ids.ServiceID)
        { }

        public override void RegisterProcess()
        {
            RegisterCommand((int)proto_ids.CidMethod, Method);
        }

        public void Login(ProtoMessage message)
        {
            // 这句感觉没有简单多少， 只是把解析和show log 封装了一遍，可以按原来的写法写
            Notification Notification = (Notification)GetNotification(message, typeof(Notification), "Notification");

        }

    }
}*/