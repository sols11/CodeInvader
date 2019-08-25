/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/13
Description:
    简介：装备数据
History:
----------------------------------------------------------------------------*/

using ItemStruct;
using CommonStruct;
using UnityEngine;
using UnityEditor;
using SFramework;

namespace ProjectScript
{
    public class EquipData : ItemData
    {
        // 属性
        [HideInInspector] public Robot owner;
        public EquipmentSlot equipSlot;
        public EquipmentType equipmentType;
        public string name;
        public float weight;

        [Header("装备信息")]
        public float setupTime = 0;
        public float attackDuration = 1;
        public int attack;
        // 多层攻击范围数组（分别存放距离和伤害转化率）
        public Vector3 atkRange = Vector3.zero;
        public Vector2[] diffRangeAtk = new Vector2[3];
        public float rotSpeedReduce = 0;
        [Header("攻击方式")]
        // TODO 添加攻击方式
        [Header("特殊伤害效果")]
        public int specialEffects = 0;
        // 每种伤害效果的数值
        public float beatBack = 0;
        public float speedUp = 0;
        public float slowDown = 0;
        public bool canFly = false;

        public EquipData(BaseItemData data)
        {
            SetItemData(data);
        }

        public void SetEquipData(EquipItemInfo equipInfo)
        {
            // TODO 读表获取武器信息
            equipSlot = equipInfo.Slot;
            equipmentType = equipInfo.EquipType;
            name = equipInfo.Name??"";
            weight = equipInfo.Weight;

            setupTime = equipInfo.SetupTime;
            attackDuration = equipInfo.AttackDuration;
            attack = equipInfo.Attack[0];
            // 多层攻击范围数组（分别存放距离和伤害转化率）
            atkRange = NetConverter.To(equipInfo.AtkRange);
            for(int i = 0; i < equipInfo.DiffRangeAtk.Count; i++)
            {
                diffRangeAtk[i] = NetConverter.To(equipInfo.DiffRangeAtk[i]);
            }
            rotSpeedReduce = equipInfo.RotSpeedReduce;
        
            // TODO 添加攻击方式
        
            specialEffects = equipInfo.SpecialEffects;
            // 每种伤害效果的数值
            beatBack = equipInfo.BeatBack;
            speedUp = equipInfo.SpeedUp;
            slowDown = equipInfo.SlowDown;
            canFly = equipInfo.CanFly;
        }

        /// <summary>
        /// 对于不需要碰撞检测的装备，不需要添加Trigger碰撞体，自然也不会执行该方法
        /// </summary>
        /// <param name="col"></param>
        /// 目前只有近战武器
        /*protected void OnTriggerEnter(Collider col)
        {
            if (type != EquipType.Weapon)
                return;
            // 若击中，触发事件
            if (col.gameObject.layer == (int)ObjectLayer.Player)
            {
                // 播放特效等
            }
            else if (col.gameObject.layer == (int)ObjectLayer.Robot)
            {

            }
        }*/
    }
}