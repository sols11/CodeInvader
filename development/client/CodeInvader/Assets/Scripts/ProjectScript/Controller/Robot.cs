/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/08
Description:
    简介：AI机器人角色类
    作用：MVVM中的Controller
    使用：行为有：移动，静止，左右手攻击，停止攻击，闪避，受伤，死亡（可能的修复）
History:
----------------------------------------------------------------------------*/

using System.Collections.Generic;
using CommonStruct;
using SFramework;
using UnityEngine;
using UnityEditor;

namespace ProjectScript
{
    public class Robot
    {
        public RobotData data;
        public int team;        // 标明是哪个阵营的
        public EquipComponent leftHand;
        public EquipComponent rightHand;
        public EquipComponent leg;

        /// <summary>
        /// 由RobotMgr建造
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="equips">必须是长度>=4的列表</param>
        public Robot(GameObject gameObject)
        {
            data = gameObject.GetComponent<RobotData>();
            if (data == null)
            {
                Debug.LogError("Robot GameObject缺少Data！");
                return;
            }

            data.Init();
        }

        /// <summary>
        /// 由于角色行为由装备驱动，因此装备必须引用自己所属的角色
        /// </summary>
        /// <param name="equips"></param>
        public void Init(EquipComponent[] equips)
        {
            // 初始化装备
            if (equips is null || equips.Length < (int)EquipIndex.Count)
            {
                Debug.Log("Robot equips数据有误！");
                return;
            }
            leftHand = equips[(int)EquipIndex.Left];
            rightHand = equips[(int)EquipIndex.Right];
            leg = equips[(int)EquipIndex.Leg];
            // 属性更新
            foreach (var e in equips)
            {
                if (e == null)
                    continue;
                data.moveSpeed += e.data.speedUp;
                //data.rotSpeed += e.data.rotSpeed;
            }
        }

        public void Release() { }
        public void Update() { }
        public void FixedUpdate() { }

        #region 对外接口

        /// <summary>
        /// 位置同步
        /// </summary>
        /// <param name="transform"></param>
        public void Move(Vector3 pos, Quaternion rot)
        {
            leg.Move(data, pos, rot);
        }

        public void MoveToPos(Vector3 pos)
        {

        }

        public void MoveToTarget(Transform transform)
        {

        }

        public void Stop(Vector3 pos, Quaternion rot)
        {
            // 其实可能不需要这个接口，因为静止了就不会发位移消息了
        }

        public void Avoid()
        {

        }

        public void LeftAttack()
        {
            leftHand?.Attack(data);
        }

        public void StopLeftAttack()
        {
            leftHand?.StopAttack();
        }

        public void RightAttack()
        {
            rightHand?.Attack(data);
        }

        public void StopRightAttack()
        {
            rightHand?.StopAttack();
        }

        public void Hurt(DamageInfo info, bool isDead)
        {
            // TODO
            data.CurrentHp -= (int)info.Attack;
            if (data.CurrentHp <= 0 || isDead)
                Dead();
        }

        public void Dead()
        {
            // TODO
            data.state = NetState.Death;
            data.CurrentHp = 0;

        }

        #endregion

    }
}

