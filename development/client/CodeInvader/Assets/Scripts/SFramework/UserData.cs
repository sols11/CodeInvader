/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/16 11:19
Description:
    简介：保存必要的游戏用户信息，登录后的uid和
History:
----------------------------------------------------------------------------*/
using System;
using UnityEngine;

namespace SFramework
{
    public static class UserData
    {
        // 鐢ㄦ埛淇℃伅鐩稿叧鐨勫唴瀹?
        public static int uid = 1;
        public static bool isLogin = false; // user login status

        // room info
        public static int rid = 1;
        public static bool isInRoom = false;

        // play game status
        public static bool isGaming = false;
        private static string gameServerHost = "";
        private static int gameServerPort = 0;

        public static void SetUid(int userId)
        {
            uid = userId;
        }

        public static void SetRid(int roomId)
        {
            rid = roomId;
        }

        public static bool ChangeServer(string serverHost, int serverPort)
        {
            if(NetMgr.Disconnect())
            {
                if (NetMgr.ReConnect(serverHost, serverPort))
                {
                    gameServerHost = serverHost;
                    gameServerPort = serverPort;
                    Debug.Log("切换服务器成功");
                    return true;
                }  
            }
            return false;
        }

        public static void Reconnect()
        {
            // 断线尝试重连
            if(NetMgr.Connect())
            {
                // 重连成功，发送重进游戏之类的协议
            }
        }

    }
}