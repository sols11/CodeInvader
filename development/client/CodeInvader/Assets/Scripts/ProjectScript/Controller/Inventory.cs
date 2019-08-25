/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/18
Description:
    简介：背包控制类，保存背包物体的地方,该类是一个单例
History:
----------------------------------------------------------------------------*/
using System;
using SFramework;
using System.Collections.Generic;
using Google.Protobuf;
using Google.Protobuf.Collections;
using ItemStruct;
using InventoryMessage;
using UnityEngine;


namespace ProjectScript
{
    public class Inventory
    {
        private static volatile Inventory _instance;
        private static object _lock = new object();

        public static Inventory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new Inventory();
                    }
                }
                return _instance;
            }
        }

        private Inventory()
        {
            InitInventory();
        }

        // 物品存储空间，即背包，背包只存储每种物品的数量，具体物品的背包操作由服务器控制
        private Dictionary<ItemType, Dictionary<int, int>> backpack = new Dictionary<ItemType, Dictionary<int, int>>();
        private LinkedList<ItemData> collectableItem = new LinkedList<ItemData>();

        // 初始化背包可装物品的类型和容量
        private void InitInventory()
        {
            backpack[ItemType.Aimodule] = new Dictionary<int, int>();
            backpack[ItemType.Equipment] = new Dictionary<int, int>();
        }

        // 同步服务器上的背包信息
        public void SyncBackpack(RepeatedField<BackpackInfo> backpackInfos)
        {
            backpack = new Dictionary<ItemType, Dictionary<int, int>>();
            foreach(var info in backpackInfos)
            {
                backpack.Add(info.ItemType, new Dictionary<int, int>());
                foreach(ItemInfo item in info.Items)
                {
                    if(!backpack[info.ItemType].ContainsKey(item.ItemId))
                        backpack[info.ItemType].Add(item.ItemId, item.Count);
                    else
                        backpack[info.ItemType][item.ItemId] = item.Count;
                }
            }
        }

        #region 对外接口
        //将资源存储在背包中, 更新背包值
        public void Save(ItemType itemType, int itemId, int count)
        {
            if (!backpack[itemType].ContainsKey(itemId))
                backpack[itemType].Add(itemId, 1);
            else
                backpack[itemType][itemId]++;
        }

        // 取出背包中某类资源
        public void TakeOut(ItemType itemType, int itemId, int count)
        {
            if (backpack[itemType].ContainsKey(itemId))
            {
                if(count == 0)
                {
                    backpack[itemType].Remove(itemId);
                    return;
                }
                backpack[itemType][itemId] = count;
            }
            else
                throw new Exception("背包内无此物品");
        }

        // 可收集队列方法
        public void CollectableAdd(ItemData data)
        {
            // 可交互物体入栈
            collectableItem.AddLast(data);
        }
        public void CollectableRemove(ItemData data)
        {
            // 可交互物体入栈
            collectableItem.Remove(data);
        }
        public ItemData CollectableGet()
        {
            while(collectableItem.Count > 0)
            {
                if (GameMgr.Get.courseMgr.pickedItem.ContainsKey(collectableItem.Last.Value.eid))
                    // 物品已被采集(处理同步问题)
                    collectableItem.RemoveLast();
                // 获取可拾取物品
                ItemData data = collectableItem.Last.Value;
                collectableItem.RemoveLast();
                return data;
            }
            return null;
        }

        public int CollectableCount()
        {
            return collectableItem.Count;
        }

        // 读取背包某类物品<itemId(equipId), count>
        public Dictionary<int, int> ReadResources(ItemType itemType, int subType=0)
        {
            // 按某类型的子类型进行读取, 为 0 时读取该类型的所有内容
            Dictionary<int, int> items = new Dictionary<int, int>();
            foreach(var key in backpack[itemType].Keys)
            {
                if (subType != 0 && (key >> 12) != subType)
                    continue;
                items.Add(key, backpack[itemType][key]);
            }
            return items;
        }

        public IMessage ReadItemInfo(ItemType itemType, int itemId)
        {
            return null;
        }
        #endregion
    }
}