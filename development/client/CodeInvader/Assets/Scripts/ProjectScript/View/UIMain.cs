/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/15 17:25
Description:
    
History:
----------------------------------------------------------------------------*/
using System;
using UnityEngine;
using UnityEngine.UI;
using SFramework;

namespace ProjectScript
{
    public class UIMain : ViewBase
    {
        public Button getRoomBtn;
        public Button quickJoinBtn;
        public Button characterBtn;

        private void Awake()
        {
            base.UIFormType = UIFormType.Normal;
            base.UIFormShowMode = UIFormShowMode.Normal;
            base.UIFormLucencyType = UIFormLucenyType.Lucency;
        }

        private void Start()
        {
            getRoomBtn.onClick.AddListener(OnGetRooms);
            quickJoinBtn.onClick.AddListener(OnQuickJoinRoom);
            characterBtn.onClick.AddListener(OnCharacterInfo);
        }

        private void OnGetRooms()
        {
            UiManager.ShowUI("RoomSelection");
            RoomServiceRequest.GetRooms(UserData.uid);

        }

        private void OnQuickJoinRoom()
        {
            // TODO 快速进入房间
        }

        private void OnCharacterInfo()
        {
            // TODO 展开用户信息页
        }

    }
}