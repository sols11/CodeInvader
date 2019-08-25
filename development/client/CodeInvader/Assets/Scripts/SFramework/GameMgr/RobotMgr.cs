/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/08
Description:
    简介：机器人角色管理系统
    作用：负责机器人角色的创建，管理，删除
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
    /// 机器人角色管理系统
    /// </summary>
    public class RobotMgr : IGameMgr
    {
        public Dictionary<int, Robot> robots;      // 由aid对应
        private string path = @"Characters\RobotGun";
        private string swordPath = @"Equips\Sword";

        public RobotMgr(GameMgr gameMgr) : base(gameMgr)
        {
            robots = new Dictionary<int, Robot>();
        }

        public override void Initialize()
        {
            EventMgr.Instance.Listen(ArgEvent.RobotAttack, RobotAttack);
        }

        public override void Release()
        {
            EventMgr.Instance.Remove(ArgEvent.RobotAttack, RobotAttack);
            // Destroy
            foreach (var r in robots.Values)
            {
                r?.Release();
            }
            robots.Clear();
        }

        public override void FixedUpdate()
        {
            foreach (var r in robots.Values)
            {
                r?.FixedUpdate();
            }
        }

        public override void Update()
        {
            foreach (var r in robots.Values)
            {
                r?.Update();
            }
        }

        #region 对外接口

        /// <summary>
        /// 先创建一个默认的机器人，不管其组装模块
        /// </summary>
        public void CreateDefault()
        {
            // 先创建Robot实体
            GameObject gameObject = GameMgr.Get.resourcesMgr.LoadAsset(path);
            // 创建对应的Controller
            Robot robot = new Robot(gameObject);
            // 再创建Equip实体（模型暂不支持组建，因此先直接使用模型中已有的武器）
            EquipComponent[] equips = new EquipComponent[(int)EquipIndex.Count];
            //GameObject right = GameMgr.Get.resourcesMgr.LoadAsset(swordPath);
            Transform right = robot.data.rootBones[0].Find("Spas");
            equips[(int)EquipIndex.Right] = new EquipComponent(right.gameObject, robot);
            //right.transform.parent = gameObject.transform;
            robot.Init(equips);

            robots.Add(1, robot);
            //EventMgr.Instance.Invoke(ArgEvent.CreatePlayer, robot, EventArgs.Empty);
        }

        public bool Create(int eid, NetRobotData data, EquipComponent[] equips = null)
        {
            if (robots.ContainsKey(eid))
            {
                NetConverter.Convert(data, robots[eid].data);
                return false;
            }
            GameObject gameObject = GameMgr.Get.resourcesMgr.LoadAsset(path);
            Robot robot = new Robot(gameObject);
            NetConverter.Convert(data, robot.data);
            robot.Init(equips);
            robots.Add(eid, robot);
            return true;
        }

        public Robot Get(int eid)
        {
            if (robots.ContainsKey(eid))
                return robots[eid];

            return null;
        }

        public void Remove(int eid)
        {
            if (robots.ContainsKey(eid))
            {
                var robot = robots[eid];
                robots.Remove(eid);
                robot.Release();
            }
        }

        public void RobotAttack(int eid, bool startOrStop, bool leftOrRight)
        {
            Robot r = Get(eid);
            if (r is null)
                return;
            if (startOrStop)
            {
                if (leftOrRight)
                    r.LeftAttack();
                else
                    r.RightAttack();
            }
        }

        public void RobotMove(int eid, Vector3 pos, Quaternion rot)
        {
            Robot r = Get(eid);
            r?.Move(pos, rot);
        }

        public void RobotHurt(int eid, DamageInfo info, bool isDead = false)
        {
            Robot r = Get(eid);
            r?.Hurt(info, isDead);
        }

        #endregion

        #region Events

        private void RobotAttack(object sender, EventArgs e)
        {
            Robot r = Get(1);
            r?.RightAttack();
        }

        #endregion
    }
}