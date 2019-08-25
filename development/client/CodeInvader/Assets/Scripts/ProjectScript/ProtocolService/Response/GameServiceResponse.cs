/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/15 16:28
Description:
    Response for Account Service Protocol Message
History:
----------------------------------------------------------------------------*/
using ProtocolMessage;
using GameMessage;
using SFramework;

namespace ProjectScript
{
    public class GameServiceResponse : BaseResponse
    {
        public GameServiceResponse() : base((int)proto_ids.GameService)
        { }

        public override void RegisterProcess()
        {
            RegisterCommand((int)proto_ids.Playeronline, PlayerOnline);
            RegisterCommand((int)proto_ids.Pull, Pull);
        }

        public void PlayerOnline(ProtoMessage message)
        {
            PlayerOnlineResponse response = (PlayerOnlineResponse)GetResponse(message, typeof(PlayerOnlineResponse), "GameService:PlayerOnline");

            if (response.Result == 1)
            {
                GameMgr.Get.playerMgr.AddMain(response.Eid);
            }
            else
            {
                // TODO hints when failure occurred
            }
        }

        public void Pull(ProtoMessage message)
        {
            PullResponse response = (PullResponse)GetResponse(message, typeof(PullResponse), "GameService:Pull");

            if (response.Result == 1)
            {
                foreach (var f in response.Players)
                    GameMgr.Get.playerMgr.Create(f.Eid, f);
                foreach (var f in response.Robots)
                    GameMgr.Get.robotMgr.Create(f.Eid, f);
                foreach (var f in response.Computers)
                    GameMgr.Get.courseMgr.CreateComputer(f.Eid, f);

                /*foreach (var f in response.ResourceItems)
                    GameMgr.Get.courseMgr.CreateResourceItem(f.Eid, f);*/
                // 初始化或同步背包内容
                Inventory.Instance.SyncBackpack(response.BackpackInfo);
            }
            else
            {
                // TODO hints when login failure occurred
            }
        }
    }
}