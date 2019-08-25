/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/15 16:43
Description:
    
History:
----------------------------------------------------------------------------*/
using System;
using SFramework;
using ProtocolMessage;
using UserRoomMessage;

namespace ProjectScript
{
    public class RoomServiceResponse : BaseResponse
    {
        public RoomServiceResponse() : base((int)proto_ids.RoomService)
        { }

        public override void RegisterProcess()
        {
            RegisterCommand((int)proto_ids.CidBuildRoom, BuildRoom);
            RegisterCommand((int)proto_ids.CidEnterRoom, EnterRoom);
            RegisterCommand((int)proto_ids.CidExitRoom, ExitRoom);
            RegisterCommand((int)proto_ids.CidStartGame, StartGame);
            RegisterCommand((int)proto_ids.CidGetRooms, GetRooms);
            RegisterCommand((int)proto_ids.CidGetRoomByRid, GetRoomByRid);
        }

        public void BuildRoom(ProtoMessage message)
        {
            var buildRoomResponse = (UserBuildRoomResponse)GetResponse(message, typeof(UserBuildRoomResponse), "RoomService:BuildRoom");

            if (buildRoomResponse.Result == 0)
            {
                // 创建房间成功直接进入房间
                GameMgr.Get.uiManager.ShowUI("RoomPreparation");
                UserData.rid = buildRoomResponse.NewRoomObj.Rid;
                // 展示房间信息
                EventMgr.Instance.Invoke(SEvent.EnterRoom, this, buildRoomResponse.NewRoomObj);
            }
         
        }

        public void EnterRoom(ProtoMessage message)
        {
            var enterRoomResponse = (UserEnterRoomResponse)GetResponse(message, typeof(UserEnterRoomResponse), "RoomService:EnterRoom");

            if (enterRoomResponse.Result == 0)
            {
                // 进入房间成功
                GameMgr.Get.uiManager.ShowUI("RoomPreparation");
                UserData.rid = enterRoomResponse.EnterRoomObj.Rid;
                // 展示房间信息
                EventMgr.Instance.Invoke(SEvent.EnterRoom, this, enterRoomResponse.EnterRoomObj);
            }
        }

        public void ExitRoom(ProtoMessage message)
        {
            var exitRoomResponse = (UserExitRoomResponse) GetResponse(message, typeof(UserExitRoomResponse), "RoomService:ExitRoom");
            if (exitRoomResponse.Result == 0)
            {
                GameMgr.Get.uiManager.ShowUI("RoomSelection");
                RoomServiceRequest.GetRooms(UserData.uid);
            }
           
        }

        public void StartGame(ProtoMessage message)
        {
            var startGameResponse = (UserStartGameResponse) GetResponse(message, typeof(UserStartGameResponse), "RoomService:StartGame");

            if(startGameResponse.Result == 0)
            {   //切换服务器
                if(UserData.ChangeServer(startGameResponse.Address.Ip, startGameResponse.Address.Port))
                {
                    // switch to main scene
                    GameLoop.Instance.sceneController.SetScene(SceneState.BattleScene);
                }
               
            }
            
           
        }

        public void GetRooms(ProtoMessage message)
        {
            var getRoomsResponse = (GetRoomsResponse)GetResponse(message, typeof(GetRoomsResponse), "RoomService:GetRooms");
            if (getRoomsResponse.RoomObjLst.Count > 0)
                EventMgr.Instance.Invoke(SEvent.GetRooms, this, getRoomsResponse.RoomObjLst);
            else
                EventMgr.Instance.Invoke(SEvent.GetRooms, this, null);
        }

        public void GetRoomByRid(ProtoMessage message)
        {
            var getRoomByRidResponse = (GetRoomByRidResponse) GetResponse(message, typeof(GetRoomByRidResponse), "RoomService:GetRoomsByRid");

        }

    }
}