/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/15 15:33
Description:
    Requests of the Account Service Protocol Message
History:
----------------------------------------------------------------------------*/
/*using SFramework;
using AccountMessage;

namespace ProjectScript
{
    public class ServiceRequest : BaseRequest
    {
        public static int SID = (int)proto_ids.ServiceID;

        #region 网络请求接口

        public static void Login(string username, string password)
        {
            
            LoginRequest loginRequest = new LoginRequest
            {
                Username = username,
                Password = password,
                Hid = -1
            };

            // 第三个参数主要用于Debug显示，可以不传（不传则显示UnknownService）
            RequestSend(SID, (int)proto_ids.CidLogin, loginRequest, "AccountService:Login");
            
        }

        public static void Register(string username, string password)
        {
            RegisterRequest registerRequest = new RegisterRequest
            {
                Username = username,
                Password = password
            };

            RequestSend(SID, (int)proto_ids.CidLogin, registerRequest, "AccountService:Register");
        }

        #endregion
    }
}*/