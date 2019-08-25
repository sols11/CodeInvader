/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/19
Description:
    Base CallBack of Protocol Service
History:
----------------------------------------------------------------------------*/
using System;
using System.Reflection;
using ProtocolMessage;
using Google.Protobuf;

namespace SFramework
{
    public abstract class BaseResponse: BaseCallBack
    {
        protected string serviceName = "Unknown";
        public BaseResponse(int sid):base(sid)
        {
        }
        
        public IMessage GetResponse(ProtoMessage message, Type type, string responseName="UnknownService")
        {
            /* // 方法一： C# 类型反射
            MethodInfo method = type.GetMethod("Parser.ParserFrom");
            object [] parameters = new object[]{ message.ProtoData };
            IMessage response = (IMessage)method.Invoke(Activator.CreateInstance(type), parameters);
            */
            // 方法二： Protobuf 自动反射
            var descriptor = ((IMessage)Activator.CreateInstance(type)).Descriptor;
            IMessage response = descriptor.Parser.ParseFrom(message.ProtoData);

            ProtoDebug.Instance.Log(ProtoMsgType.Response, responseName, message.ProtoId);
            return response;
        }

        // 消息分发处理函数注册
        public sealed override void RegisterCommand(int cid, Dispatcher.ServiceFunction function)
        {
            base.RegisterCommand(cid, function);
        }

        public sealed override void UnregisterCommand(int cid)
        {
            base.UnregisterCommand(cid);
        }

        // 注册过程的抽象函数
        public abstract override void RegisterProcess();

        //TODO 提供批量取消注册的接口
       /* public virtual void UnregisterAllCommand()
        {
        }
        */

    }
}

