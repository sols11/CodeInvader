/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/15 16:28
Description:
    Response for Account Service Protocol Message
History:
----------------------------------------------------------------------------*/

/*using SFramework;
using ProtocolMessage;

namespace ProjectScript
{
    public class ServiceResponse : BaseResponse
    {
        public ServiceResponse() : base((int)proto_ids.ServiceID)
        { }

        public override void RegisterProcess()
        {
            RegisterCommand((int)proto_ids.CID, Method);
        }

        public void Method(ProtoMessage message)
        {
            // 这句感觉没有简单多少， 只是把解析和show log 封装了一遍，可以按原来的写法写
            Response response = (Response)GetResponse(message, typeof(Response), "Service:Command");

            // 原有写法
            Response response = Response.Parse.ParseFrom(message.ProtoData);
            ProtoDebug.Log(ProtoMsgType.Response, );

        }

    }
}*/