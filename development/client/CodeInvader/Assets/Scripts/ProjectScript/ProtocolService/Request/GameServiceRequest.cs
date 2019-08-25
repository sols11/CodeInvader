/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/15 15:33
Description:
    Requests of the Account Service Protocol Message
History:
----------------------------------------------------------------------------*/
using ProtocolMessage;
using GameMessage;
using SFramework;

namespace ProjectScript
{
    public class GameServiceRequest : BaseRequest
    {
        public static int SID = (int)proto_ids.GameService;

        #region 网络请求接口

        public static void PlayerOnline(int eid)
        {
            PlayerOnlineRequest msg = new PlayerOnlineRequest
            {
                Rid = UserData.rid,
                Eid = eid,
                Uid = UserData.uid
            };

            RequestSend(SID, (int)proto_ids.Playeronline, msg, "PlayerOnline");
        }

        #endregion
    }
}