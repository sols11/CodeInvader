/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/16
Description:
    enter room and preparation, waiting for the game start or start game
History:
----------------------------------------------------------------------------*/
using UnityEngine.UI;
using SFramework;

namespace ProjectScript
{

    public class UIRoomPreparation : ViewBase
    {
        public Button backBtn;
        public Button prepareBtn;

        private void Awake()
        {
            //定义本窗体的性质(默认数值，可以不写)
            base.UIFormType = UIFormType.Normal;
            base.UIFormShowMode = UIFormShowMode.Normal;
            base.UIFormLucencyType = UIFormLucenyType.Lucency;
        }

        public void Start()
        {
            backBtn.onClick.AddListener(OnExitRoom);
            prepareBtn.onClick.AddListener(OnPrepareForGame);
        }

        public void OnExitRoom()
        {
            UiManager.CloseUI("RoomPreparation");
            RoomServiceRequest.ExitRoom(UserData.rid, UserData.uid);
        }

        public void OnPrepareForGame()
        {
            RoomServiceRequest.StartGame(UserData.rid, UserData.uid);
        }
    }

}