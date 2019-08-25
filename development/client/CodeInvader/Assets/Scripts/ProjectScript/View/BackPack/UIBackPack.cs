/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/16
Description:
    简介：显示背包信息
History:
----------------------------------------------------------------------------*/
using ItemStruct;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFramework;

namespace ProjectScript
{

    public class UIBackPack : ViewBase
    {
        public Button backBtn;
        public Transform backpackContent;
        private readonly string resourceItemBtnPath = @"UI\BackPackResource\ResourceItemBtn";
        private void Awake()
        {
            //定义本窗体的性质(默认数值，可以不写)
            base.UIFormType = UIFormType.PopUp;
            base.UIFormShowMode = UIFormShowMode.ReverseChange;
            base.UIFormLucencyType = UIFormLucenyType.Lucency;
        }

        public void Start()
        {
            backBtn.onClick.AddListener(OnCloseBackPack);
            EventMgr.Instance.Listen(SEvent.ReadItems, ShowItems);
        }

        private void OnEnable()
        {
            EventMgr.Instance.Invoke(SEvent.ReadItems, this, ItemType.Aimodule);
        }

        private void OnDisable()
        {
            
        }

        public void ShowItems(object sender, object args)
        {
            Dictionary<int, int>items = Inventory.Instance.ReadResources(ItemType.Aimodule);
            foreach(int key in items.Keys)
            {
                GameObject itemObj = GameMgr.Get.resourcesMgr.LoadAsset(resourceItemBtnPath);
                itemObj.GetComponent<ResourceItemBtnData>().SetItem(key, items[key]);
                itemObj.transform.SetParent(backpackContent, false);
            }
        }

        private void OnCloseBackPack()
        {
            // 清除背包UI中的子物体
            int childCount = backpackContent.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Destroy(backpackContent.GetChild(0).gameObject);
            }
            UiManager.CloseUI("Backpack");
        }

    }

}