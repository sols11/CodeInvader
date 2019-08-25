/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/13
Description:
    简介：装备类
    作用：控制装备的行为
History:
----------------------------------------------------------------------------*/

using CommonStruct;
using ItemStruct;
using SFramework;
using UnityEngine;
using UnityEditor;

namespace ProjectScript
{
    public class EquipComponent: Item
    {
        public EquipData data;
        public GameObject equipObject;
        // Parameters & States
        private string animSword = "Sword";
        private string animSpas = "SpasShoot";

        public EquipComponent(GameObject gameObject)
        {
            itemType = ItemType.Equipment;
            // 武器未挂接在机器人身上
            data = gameObject.GetComponent<EquipData>();
            equipObject = gameObject;
            if (data == null)
            {
                Debug.LogError("Equip GameObject缺少Data！");
                return;
            }
        }

        public EquipComponent(GameObject gameObject, Robot robot)
        {
            itemType = ItemType.Equipment;
            // 武器挂接在机器人身上
            data = gameObject.GetComponent<EquipData>();
            if (data == null)
            {
                Debug.LogError("Equip GameObject缺少Data！");
                return;
            }

            if (robot == null)
            {
                Debug.LogError("robot is null!");
                return;
            }
            data.owner = robot;
        }

        #region 对外接口
        public void Attack(RobotData robotData)
        {
            if (data.equipmentType == EquipmentType.ShotGun)
                data.owner.data.Animator.SetTrigger(animSword);    // Animator.SetTrigger本身是行为，并非修改data数据，因此可以使用
            else if (data.equipmentType == EquipmentType.Assaultrifles)
                data.owner.data.Animator.SetTrigger(animSpas);
            DamageInfo info = new DamageInfo()
            {
                Attack = data.attack,
                AttackId = robotData.eid,
            };
        }

        public void StopAttack()
        {

        }

        public void Move(RobotData robotData, Vector3 position, Quaternion rotation)
        {
            // 移向目标点
            float step = robotData.moveSpeed * Time.deltaTime;
            Vector3 pos = Vector3.MoveTowards(data.transform.position, robotData.transform.position, step);
            robotData.Rgbd.MovePosition(pos);
        }
        #endregion
    }
}