/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/19
Description:
    Base Request of Protocol Service
History:
----------------------------------------------------------------------------*/
using Google.Protobuf;
using ProtocolMessage;

namespace SFramework
{
    public class BaseRequest
    {
        private static Dispatcher _dispatcher = Dispatcher.Instance;

        public BaseRequest()
        {
        }

        #region 网络请求基础接口

        public static void RequestSend(int SID, int CID, IMessage requestMessage, string requestName="UnknownService")
        {
            ProtoMessage message = _dispatcher.Pack(SID, CID, requestMessage);
            NetMgr.Send(message);

            // Debug用, 显示请求协议的类型
            ProtoDebug.Instance.Log(ProtoMsgType.Request, requestName, message.ProtoId);
        }

        #endregion
    }
}