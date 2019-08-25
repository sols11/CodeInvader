/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/07
Description:
    简介：游戏过程管理器
    作用：对游戏的流程进行分析，控制
    使用：调用接口
    补充：功能：SceneSpwaner，暂停游戏，角色死亡事件，敌人死亡事件
History:
----------------------------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using ItemStruct;
using CommonStruct;
using ProjectScript;
using UnityEngine;

namespace SFramework
{
    /// <summary>
    /// 过程管理
    /// </summary>
    public class CourseMgr : IGameMgr
    {
        // 场景物体预设路径 <物体名称, 预设路径>
        private Dictionary<string, string> nameToPathDict;
        private Dictionary<int, Computer> computers;
        private Dictionary<int, EquipComponent> equipments;
        private Dictionary<int, AIModule> aiModules;
        public Dictionary<int, Item> pickedItem {get; private set;}// 被拾取的对象缓冲区，用于恢复

        private bool enable = false;
        /// <summary>
        /// 是否启用该系统
        /// </summary>
        public bool Enable {
            get
            {
                return enable;
            }
            set
            {
                enable = value;
                if (Enable)
                {
                    // 当启用时，注册事件
                }
                else
                {
                    // 当禁用时，移除事件
                }
            }
        }

        public CourseMgr(GameMgr gameMgr):base(gameMgr)
		{
            nameToPathDict = new Dictionary<string, string>();
            computers = new Dictionary<int, Computer>();

            aiModules = new Dictionary<int, AIModule>();
            equipments = new Dictionary<int, EquipComponent>();
            pickedItem = new Dictionary<int, Item>();
        }

        public override void Awake()
        {
            if (nameToPathDict != null)
            {
                nameToPathDict.Add("Home", @"other\Home");
                nameToPathDict.Add("Computer", @"other\Computer");
                nameToPathDict.Add("AIModule", @"Modules\AIModule");
                nameToPathDict.Add("Equipment", @"Equips\");
            }
        }

        public override void Initialize()
        {
            Enable = false;
        }

        public override void Release()
        {
            foreach (var c in computers.Values)
            {
                c?.Release();
            }
            computers.Clear();
            aiModules.Clear();
            equipments.Clear();
        }

        public override void Update()
        {
            foreach (var c in computers.Values)
            {
                c?.Update();
            }
        }

        #region 对外接口

        public void CreateHome()
        {
            GameObject gameObject = GameMgr.Get.resourcesMgr.LoadAsset(nameToPathDict["Home"]);
            Home home = new Home(gameObject);
            // Home暂时没有什么行为，因此暂不缓存
        }

        /// <summary>
        /// 若不存在则创建，并返回true.
        /// 若存在则赋值，并返回false.
        /// </summary>
        /// <param name="eid"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool CreateComputer(int eid, NetComputerData data)
        {
            if (computers.ContainsKey(eid))
            {
                NetConverter.Convert(data, computers[eid].data);
                return false;
            }
            GameObject gameObject = GameMgr.Get.resourcesMgr.LoadAsset(nameToPathDict["Computer"]);
            Computer computer = new Computer(gameObject);
            computers.Add(eid, computer);
            NetConverter.Convert(data, computer.data);
            return true;
        }

        public Computer GetComputer(int eid)
        {
            if (computers.ContainsKey(eid))
                return computers[eid];

            return null;
        }

        public void RemoveComputer(int eid)
        {
            if (computers.ContainsKey(eid))
            {
                computers.Remove(eid);
            }
        }

        // 单播方法
        public void StartOrStopDecoded(int eid, bool startOrStop)
        {
            Computer c = GetComputer(eid);
            if (c is null)
                return;
            if(startOrStop)
                c.StartDecoded();
            else
                c.StopDecoded();
        }

        // 广播方法
        public void DecodeComplete(int eid)
        {
            GetComputer(eid)?.DecodeComplete();
        }

        public bool CreateResourceItem(int eid, BaseItemData data, Robot robot = null)
        {
            if (pickedItem.ContainsKey(eid))
                return RestoreItem(eid); // 之前拾取的资源重新出现在场景中则直接恢复
            if (data.ItemType == ItemType.Aimodule)
            {
                return CreateAiModuleItem(data);
            }
            if (data.ItemType == ItemType.Equipment)
            {
                return CreateEquipment(data, robot);
            }
            return false;
        }

        public bool CreateAiModuleItem(BaseItemData data)
        {
            if (aiModules.ContainsKey(data.Eid))
            {
                aiModules[data.Eid].data.SetItemData(data);
                return false;
            }
            GameObject gameObject = GameMgr.Get.resourcesMgr.LoadAsset(nameToPathDict["AIModule"]);
            AIModule aiModule = new AIModule(gameObject);
            aiModules.Add(data.Eid, aiModule);
            aiModules[data.Eid].data.SetItemData(data);
            return true;
        }

        public bool CreateEquipment(BaseItemData data, Robot robot = null)
        {
            // 创建AI模块实体的方法
            if (equipments.ContainsKey(data.Eid))
            {
                equipments[data.Eid].data.SetItemData(data);
                return false;
            }
            GameObject gameObject = GameMgr.Get.resourcesMgr.LoadAsset(nameToPathDict["Equipment"] + data.Name);
            EquipComponent equipment = (robot == null) ? new EquipComponent(gameObject) : new EquipComponent(gameObject, robot);
            equipments.Add(data.Eid, equipment);
            equipments[data.Eid].data.SetItemData(data);
            if (data.Transform != null)
                NetConverter.Convert(data.Transform, equipments[data.Eid].data.transform);
            return true;
        }

        public void RemoveResourceItem(int eid, ItemType itemType, bool pick = false)
        {
            if (itemType == ItemType.Aimodule)
            {
                // 移除AI模块资源
                if (pick)
                {
                    // 被拾取的物品被放进缓冲区中
                    aiModules[eid].moduleObject.SetActive(false);
                    pickedItem.Add(eid, aiModules[eid]);
                }
                else
                    GameObject.Destroy(aiModules[eid].moduleObject);
                // 从场景资源队列中清除物品
                aiModules.Remove(eid);
            }
            if (itemType == ItemType.Equipment)
            {
                // 移除装备资源
                if (pick)
                {
                    // 被拾取的物品被放进缓冲区中
                    equipments[eid].equipObject.SetActive(false);
                    pickedItem.Add(eid, equipments[eid]);
                }
                else
                    GameObject.Destroy(equipments[eid].equipObject);
                // 从场景资源队列中清除物品
                equipments.Remove(eid);
            }
        }

       public bool RestoreItem(int eid)
        {
            try
            {
                Item item = pickedItem[eid];
                if(item.itemType == ItemType.Aimodule)
                {
                    AIModule itemController = pickedItem[eid] as AIModule;
                    itemController.moduleObject.SetActive(true);
                    aiModules.Add(eid, itemController);
                }
                if (item.itemType == ItemType.Equipment)
                {
                    EquipComponent itemController = pickedItem[eid] as EquipComponent;
                    itemController.equipObject.SetActive(true);
                    equipments.Add(eid, itemController);
                }
                pickedItem.Remove(eid);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        private void PlayerDecodeState(object sender, EventArgs e)
        {

        }
    }
}