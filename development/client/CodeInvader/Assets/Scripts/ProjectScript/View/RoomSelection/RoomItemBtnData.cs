/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/19
Description:
    简介：资源在UI界面中展示时，UI控件需要保存相应的信息以便后续交互
History:
----------------------------------------------------------------------------*/
using UserRoomMessage;
using UnityEngine.UI;
using UnityEngine;
using SFramework;

namespace ProjectScript
{
    public class RoomItemBtnData: MonoBehaviour
    {
        public RoomObject room;
        public Text item_name;
        public Button clickItemBtn;

        private void Start()
        {
            clickItemBtn.onClick.AddListener(OnClickItem); // 点击组件表示该组件被选中
        }

        private void OnClickItem()
        {
            // TODO 触发选中逻辑，将Item数据交互给其他控制器
            Debug.Log($"选中房间： {room.Rid}");
            EventMgr.Instance.Invoke(SEvent.SelectRoom, this, room.Rid);
            //TODO 之后改成高亮显示

        }

        public void SetItem(RoomObject roomItem)
        {
            room = roomItem;
            item_name.text = $"房间名：{roomItem.Name}\n房间id：{roomItem.Rid}";
        }
    }
}