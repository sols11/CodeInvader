/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date: 
    2019/8/17
Description:
    Response for Player Service Protocol Message
History:
----------------------------------------------------------------------------*/

using System.Diagnostics;
using ProtocolMessage;
using PlayerMessage;
using SFramework;
using ItemStruct;

namespace ProjectScript
{
    public class PlayerServiceResponse : BaseResponse
    {
        public PlayerServiceResponse() : base((int)proto_ids.PlayerService)
        { }

        public override void RegisterProcess()
        {
            RegisterCommand((int)proto_ids.Move, Move);
            RegisterCommand((int)proto_ids.Crack, Crack);
            RegisterCommand((int)proto_ids.CrackComplete, CrackComplete);
            RegisterCommand((int)proto_ids.ComputerCrack, ComputerCrack);
            RegisterCommand((int)proto_ids.PickItem, PickItem);
            RegisterCommand((int)proto_ids.TakeoutItem, TakeOut);
        }

        public void Move(ProtoMessage message)
        {
            PlayerMoveResponse response = (PlayerMoveResponse)GetResponse(message, typeof(PlayerMoveResponse), "PlayerService:Move");

            if (response.Result == 1)
            {
                GameMgr.Get.playerMgr.PlayerMove(response.Eid, NetConverter.To(response.Pos), NetConverter.To(response.Rot));
                //UnityEngine.Debug.Log(response.Pos);
            }
            else
            {
                // TODO hints when failure occurred
                UnityEngine.Debug.Log("Response0");
            }
        }

        public void Crack(ProtoMessage message)
        {
            CrackResponse response = (CrackResponse)GetResponse(message, typeof(CrackResponse), "PlayerService:Crack");

            if (response.Result == 1)
            {
                GameMgr.Get.playerMgr.Crack(response.Eid, response.ComputerId, response.Decode);
            }
            else
            {
                // TODO hints when failure occurred
                UnityEngine.Debug.Log("Response0");
            }
        }

        public void ComputerCrack(ProtoMessage message)
        {
            ComputerCrackResponse response = (ComputerCrackResponse)GetResponse(message, typeof(ComputerCrackResponse), "PlayerService:ComputerCrack");

            if (response.Result == 1)
            {
                // 无需接受
                //GameMgr.Get.courseMgr.StartOrStopDecoded(response.Eid, response.StartOrStop);
            }
            else
            {
                // TODO hints when failure occurred
                UnityEngine.Debug.Log("Response0");
            }
        }

        public void CrackComplete(ProtoMessage message)
        {
            CrackCompleteResponse response = (CrackCompleteResponse)GetResponse(message, typeof(CrackCompleteResponse), "PlayerService:CrackComplete");

            if (response.Result == 1)
            {
                GameMgr.Get.courseMgr.DecodeComplete(response.ComputerId);
                GameMgr.Get.playerMgr.Crack(response.Eid, response.ComputerId, false);
            }
            else
            {
                // TODO hints when failure occurred
                Computer c = GameMgr.Get.courseMgr.GetComputer(response.ComputerId);
                if (c != null)
                    c.sendedCompleteMsg = false;
                UnityEngine.Debug.Log("Response0");
            }
        }

        public void PickItem(ProtoMessage message)
        {
            PlayerPickResponse response = (PlayerPickResponse)GetResponse(message, typeof(PlayerPickResponse), "PlayerService:Pick");
            if(response.Result == 1)
            {
                BaseItemData data = response.ItemData;
                GameMgr.Get.courseMgr.RemoveResourceItem(data.Eid, data.ItemType, true);
                Inventory.Instance.Save(data.ItemType, data.ItemId, response.Count);
                PlayerServiceRequest.TakeOut(GameMgr.Get.playerMgr.mainEid, data.ItemType, data.ItemId);
            }
        }

        public void TakeOut(ProtoMessage message)
        {
            PlayerTakeOutResponse response = (PlayerTakeOutResponse)GetResponse(message, typeof(PlayerTakeOutResponse), "PlayerService:TakeOut");
            if (response.Result == 1)
            {
                BaseItemData data = response.ItemData;
                GameMgr.Get.courseMgr.RestoreItem(data.Eid);
                Inventory.Instance.TakeOut(data.ItemType, data.ItemId, response.Count);
            }
        }
    }
}