/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/16 12:06
Description:
    Selection room interface, after user request get rooms from lobby server
History:
----------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Google.Protobuf.Collections;
using UnityEngine;
using UnityEngine.UI;
using SFramework;
using UserRoomMessage;

namespace ProjectScript
{
    
    public class UIRoomSelection:ViewBase
    {
        public Button quickJoinRoomBtn;
        public Button createRoomBtn;
        public Button selectRoomBtn;
        public Button backBtn;

        private List<Button> roomsBtn = new List<Button>();
        // 房间项（网格布局）
        public Transform roomItemGrid;
        private string roomItemBtnPath = @"UI\RoomSelection\RoomItemBtn";
        private int selectedRoomID = -1;

        private void Awake()
        {
            // UI窗体性质
            base.UIFormType = UIFormType.Normal;
            base.UIFormShowMode = UIFormShowMode.Normal ;
            base.UIFormLucencyType = UIFormLucenyType.Lucency;
        }

        private void OnEnable()
        {
            selectedRoomID = -1;
        }

        public void Start()
        {
            quickJoinRoomBtn.onClick.AddListener(OnQuickJoinRoom);
            createRoomBtn.onClick.AddListener(OnCreateRoom);
            selectRoomBtn.onClick.AddListener(OnConfirmSelectRoom);
            backBtn.onClick.AddListener(OnBack);

            EventMgr.Instance.Listen(SEvent.GetRooms, ShowRooms);
            EventMgr.Instance.Listen(SEvent.SelectRoom, UserSelectRoom);
        }


        public void OnQuickJoinRoom()
        {
            // TODO 
        }

        public void OnCreateRoom()
        {
            if (UserData.isLogin)
                RoomServiceRequest.BuildRoom(UserData.uid, "room-2");
        }

        public void OnConfirmSelectRoom()
        {
            // TODO Get the select room info
            if (selectedRoomID > 0)
                RoomServiceRequest.EnterRoom(selectedRoomID, UserData.uid);
            else
                Debug.Log("您未选择房间");
        }

        public void OnBack()
        {
            UiManager.CloseUI("RoomSelection");
        }

        private void RefreshRoom()
        {
            // 清除房间列表UI按键

        }

        #region Events
        private void ShowRooms(object sender, object rooms)
        {
            if (rooms == null)
                return;
            RefreshRoom();
            foreach (RoomObject room in (RepeatedField<RoomObject>) rooms)
            {
                GameObject itemObj = GameMgr.Get.resourcesMgr.LoadAsset(roomItemBtnPath);
                itemObj.GetComponent<RoomItemBtnData>().SetItem(room);
                itemObj.transform.SetParent(roomItemGrid, false);
            }  
        }

        private void UserSelectRoom(object sender, object rid)
        {
            selectedRoomID = (int)rid;
        }

        #endregion
    }

}