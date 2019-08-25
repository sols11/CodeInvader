/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/23
Description:
    简介：机器人组装UI
History:
----------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using ItemStruct;
using SFramework;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectScript
{
    public class UIAssembly : ViewBase
    {
        public Button btnBack;
        public Text textLevel;
        public Text textName;
        public Image speedValue;
        public Image atkValue;
        public Image atkRangeValue;
        public Image freeweightValue;
        public RectTransform content;
        private string gridPath = @"UI\AssemblyGrid";
        private string equipPath = @"Equips\";
        private List<UIAssemblyGrid> grids;
        private EquipComponent[] equips;
        private Dictionary<int, EquipComponent> equipPool;  // <equipId, equip>的对象池

        private void Awake()
        {
            base.UIFormType = UIFormType.Fixed;
            base.UIFormShowMode = UIFormShowMode.Normal;
            base.UIFormLucencyType = UIFormLucenyType.Lucency;
        }

        private void Start()
        {
            btnBack.onClick.AddListener(OnBackButton);
            equips = new EquipComponent[(int)EquipIndex.Count];
        }

        private void OnEnable()
        {
            GeneradeGrids();
        }

        private void OnBackButton()
        {
            UiManager.CloseUI("Assembly");
        }

        private void GeneradeGrids()
        {
            // load from backpack
            Dictionary<int, int> equipIds = Inventory.Instance.ReadResources(ItemType.Equipment);
            // grid prefab
            GameObject gameObjectLoaded = Resources.Load<GameObject>(gridPath);
            if (gameObjectLoaded != null)
            {
                foreach (var id in equipIds)
                {
                    // Get Data
                    EquipItemInfo equipInfo = Inventory.Instance.ReadItemInfo(ItemType.Equipment, id.Key) as EquipItemInfo;
                    // Duplicate with Count
                    for (int i = 0; i < id.Value; ++i)
                    {
                        GameObject go = Instantiate(gameObjectLoaded, content, true);
                        UIAssemblyGrid grid = go.GetComponent<UIAssemblyGrid>();
                        grid.Init(this, equipInfo);
                        grids.Add(grid);
                    }
                }
            }
        }

        public bool Equip(UIAssemblyGrid grid)
        {
            // 根据Equip数据判定能否装备
            if (equipPool.ContainsKey(grid.equipInfo.EquipId))
            {
                equipPool[grid.equipInfo.EquipId].data.gameObject.SetActive(true);
            }
            else
            {
                GameObject go = GameMgr.Get.resourcesMgr.LoadAsset(equipPath + grid.equipInfo.Name, true);
                EquipComponent equip = new EquipComponent(go);
                equip.data.SetEquipData(grid.equipInfo);
                //equips[equip.data.equipSlot]
                equipPool.Add(grid.equipInfo.EquipId, equip);
            }
            return true;
        }

        public bool UnEquip(UIAssemblyGrid grid)
        {
            return true;
        }
    }
}