/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/16
Description:
    enter room and preparation, waiting for the game start or start game
History:
----------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFramework;

namespace ProjectScript
{

    public class UIMap : ViewBase
    {
        public Button backBtn;
        private void Awake()
        {
            //定义本窗体的性质(默认数值，可以不写)
            base.UIFormType = UIFormType.PopUp;
            base.UIFormShowMode = UIFormShowMode.ReverseChange;
            base.UIFormLucencyType = UIFormLucenyType.Lucency;
        }

        public void Start()
        {
            backBtn.onClick.AddListener(OnCloseMap);
        }

        private void OnCloseMap()
        {
            UiManager.CloseUI("FullMap");
        }
    }
}