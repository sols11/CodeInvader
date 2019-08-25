/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/08
Description:
    简介：角色管理系统
    作用：负责角色的创建，管理，删除
    使用：调用接口
History:
----------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using CommonStruct;
using UnityEngine;
using ProjectScript;

namespace SFramework
{
    /// <summary>
    /// 角色管理系统
    /// </summary>
    public class PlayerMgr : IGameMgr
    {
        public Dictionary<int, Player> players;      // 由eid对应
        public int mainEid = 0;                      // 主角的eid
        private string playerPath = @"Characters\Player";
        private Player mainPlayer;

        public PlayerMgr(GameMgr gameMgr) : base(gameMgr)
        {
            players = new Dictionary<int, Player>();
        }

        public override void Initialize()
        {
            EventMgr.Instance.Listen(ArgEvent.PlayerHurt, PlayerHurt);
        }

        public override void Release()
        {
            EventMgr.Instance.Remove(ArgEvent.PlayerHurt, PlayerHurt);

            // Destroy
            foreach (var p in players.Values)
            {
                p?.Release();
            }
            players.Clear();
        }

        public override void FixedUpdate()
        {
            foreach (var p in players.Values)
            {
                if (p != null)
                    p.FixedUpdate();
            }
        }

        public override void Update()
        {
            foreach (var p in players.Values)
            {
                if (p != null)
                    p.Update();
            }
        }

        #region 对外接口

        /// <summary>
        /// 1.创建主玩家
        /// </summary>
        /// <returns></returns>
        public bool CreateMain()
        {
            // 先创建玩家角色
            GameObject gameObject = GameMgr.Get.resourcesMgr.LoadAsset(playerPath);
            gameObject.tag = SystemDefine.MAIN_PLAYER;
            mainPlayer = new Player(gameObject);
            // offline?
            if (Config.OFFLINE)
                return AddMain(0);
            else
                RequestEid();
            return true;
        }

        /// <summary>
        /// 2.Server请求eid
        /// </summary>
        /// <returns></returns>
        private void RequestEid()
        {
            GameServiceRequest.PlayerOnline(0);

        }

        /// <summary>
        /// 3.获得Eid后添加主玩家到实际控制
        /// </summary>
        /// <param name="eid"></param>
        /// <returns></returns>
        public bool AddMain(int eid)
        {
            mainEid = eid;
            if (!players.ContainsKey(eid))
                players.Add(eid, mainPlayer);
            else
            {
                Debug.LogError($"MainPlayer:{eid} 已经创建！");
                return false;
            }
            EventMgr.Instance.Invoke(ArgEvent.CreatePlayer, mainPlayer, EventArgs.Empty);
            return true;
        }

        /// <summary>
        /// 4.创建其他玩家，并赋值主玩家数据
        /// </summary>
        /// <returns></returns>
        public bool Create(int eid, NetPlayerData data)
        {
            if (players.ContainsKey(eid))
            {
                NetConverter.Convert(data, players[eid].data);
                return false;
            }
            GameObject gameObject = GameMgr.Get.resourcesMgr.LoadAsset(playerPath);
            Player player = new Player(gameObject);
            NetConverter.Convert(data, player.data);
            players.Add(eid, player);
            return true;
        }

        public Player Get(int eid)
        {
            if (players.ContainsKey(eid))
                return players[eid];

            return null;
        }

        public void Remove(int eid)
        {
            if (players.ContainsKey(eid))
            {
                var player = players[eid];
                players.Remove(eid);
                player.Release();
            }
        }

        public void PlayerMove(int eid, Vector3 pos, Quaternion rot)
        {
            Player p = Get(eid);
            p?.Move(pos, rot);
        }

        public void PlayerHurt(int eid, DamageInfo info)
        {
            Player p = Get(eid);
            p?.Hurt(info);
        }

        public void Crack(int eid, int computerId, bool decode)
        {
            // 设计里是服务器发computerId，客户端根据computerId找到computer的DecodePos，虽会产生耦合，但在unity和服务端交互时是没办法的事情
            Get(eid)?.Decode(decode, gameMgr.courseMgr.GetComputer(computerId)?.data.DecodePos);
            if(eid == mainEid)
                GameMgr.Get.courseMgr.StartOrStopDecoded(computerId, decode);
        }

        #endregion

        #region Events

        private void PlayerHurt(object sender, EventArgs e)
        {
            Player p = Get(0);
            p?.Hurt(new DamageInfo() { Attack = 10 });
        }

        #endregion
    }
}
