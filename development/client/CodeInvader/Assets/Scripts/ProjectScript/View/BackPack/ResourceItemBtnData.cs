/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/19
Description:
    简介：资源在UI界面中展示时，UI控件需要保存相应的信息以便后续交互
History:
----------------------------------------------------------------------------*/
using CommonStruct;
using UnityEngine.UI;
using UnityEngine;
using SFramework;

namespace ProjectScript
{
    public class ResourceItemBtnData: MonoBehaviour
    {
        public int itemId { get; private set; }
        public Text item_name;
        public Button clickItemBtn;

        private void Start()
        {
            clickItemBtn.onClick.AddListener(OnClickItem); // 点击组件表示该组件被选中
        }

        private void OnClickItem()
        {
            // TODO 触发选中逻辑，将Item数据交互给其他控制器
            // PlayerServiceRequest.TakeOut(GameMgr.Get.playerMgr.mainEid, ItemType.Aimodule, itemId);
        }

        public void SetItem(int id, int num)
        {
            itemId = id;
            item_name.text = $"{id}:{num}";
        }
    }
}