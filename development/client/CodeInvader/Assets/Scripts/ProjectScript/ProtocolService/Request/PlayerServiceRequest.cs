/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date: 
    2019/8/17
Description:
    Requests of the Player Service Protocol Message
History:
----------------------------------------------------------------------------*/

using ItemStruct;
using PlayerMessage;
using SFramework;
using UnityEngine;

namespace ProjectScript
{
    public class PlayerServiceRequest : BaseRequest
    {
        public static int SID = (int)proto_ids.PlayerService;

        #region 网络请求接口

        public static void Move(int eid, Vector3 v, Quaternion rot)
        {
            PlayerMoveRequest msg = new PlayerMoveRequest
            {
                Rid = UserData.rid,
                Eid = eid,
                Velocity = NetConverter.To(v),
                Rot = NetConverter.To(rot)
            };
            //UnityEngine.Debug.Log(v + ";" +msg.Velocity);

            RequestSend(SID, (int)proto_ids.Move, msg, "Move");
        }

        public static void Crack(int eid, int computerId, bool decode)
        {
            CrackRequest msg = new CrackRequest
            {
                Rid = UserData.rid,
                Eid = eid,
                ComputerId = computerId,
                Decode = decode
            };

            RequestSend(SID, (int)proto_ids.Crack, msg, "Crack");
        }

        public static void CrackComplete(int eid)
        {
            CrackCompleteRequest msg = new CrackCompleteRequest
            {
                Rid = UserData.rid,
                Eid = eid,
            };

            RequestSend(SID, (int)proto_ids.CrackComplete, msg, "CrackComplete");
        }

        public static void PickItem(int eid, int picked_eid)
        {
            Debug.Log("ssddfsfs");
            PlayerPickRequest request = new PlayerPickRequest
            {
                Rid = UserData.rid,
                Eid = eid,
                PickedEid = picked_eid
            };
            RequestSend(SID, (int)proto_ids.PickItem, request, "PlayerService:Pick");
        }

        public static void TakeOut(int eid, ItemType itemType, int itemId)
        {
            PlayerTakeOutRequest request = new PlayerTakeOutRequest
            {
                Rid = UserData.rid,
                Eid = eid,
                ItemType = itemType,
                ItemId = itemId
            };
            RequestSend(SID, (int)proto_ids.TakeoutItem, request, "PlayService:TakeOutItem");
        }

        #endregion
    }
}