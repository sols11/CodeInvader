/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/15 16:41
Description:
    
History:
----------------------------------------------------------------------------*/
using SFramework;
using UserRoomMessage;

namespace ProjectScript
{
    public class RoomServiceRequest : BaseRequest
    {
        public static int SID = (int)proto_ids.RoomService;

        public static void BuildRoom(int uid, string roomName)
        {
            UserBuildRoomRequest buildRoomRequest = new UserBuildRoomRequest
            {
                Uid = uid,
                RoomName = roomName
            };

            RequestSend(SID, (int)proto_ids.CidBuildRoom, buildRoomRequest, "BuildRoom");
        }

        public static void EnterRoom(int rid, int uid)
        {
            UserEnterRoomRequest enterRoomRequest = new UserEnterRoomRequest
            {
                Rid = rid,
                Uid = uid
            };

            RequestSend(SID, (int)proto_ids.CidEnterRoom, enterRoomRequest, "EnterRoom");
        }

        public static void ExitRoom(int rid, int uid)
        {
            UserExitRoomRequest exitRoomRequest = new UserExitRoomRequest
            {
                Rid = rid,
                Uid = uid
            };

            RequestSend(SID, (int)proto_ids.CidExitRoom, exitRoomRequest, "ExitRoom");
        }

        public static void StartGame(int rid, int uid)
        {
            UserStartGameRequest startGameRequest = new UserStartGameRequest
            {
                Rid = rid,
                Uid = uid
            };

            RequestSend(SID, (int)proto_ids.CidStartGame, startGameRequest, "StartGame");
        }
        public static void GetRooms(int uid)
        {
            GetRoomsRequest getRoomsRequest = new GetRoomsRequest { Uid = uid };

            RequestSend(SID, (int)proto_ids.CidGetRooms, getRoomsRequest, "GetRooms");
        }

        public static void GetRoomByRid(int rid, int uid)
        {
            GetRoomByRidRequest getRoomByRidRequest = new GetRoomByRidRequest
            {
                Rid = rid,
                Uid = uid
            };

            RequestSend(SID, (int)proto_ids.CidGetRoomByRid, getRoomByRidRequest, "GetRoomByRid");
        }

    }
}