/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/16
Description:
    简介：展示战斗时的信息
History:
----------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFramework;

namespace ProjectScript
{

    public class UIBattleInfo : ViewBase
    {
        public Button btnMiniMap;
        private void Awake()
        {
            //定义本窗体的性质(默认数值，可以不写)
            base.UIFormType = UIFormType.Fixed;
            base.UIFormShowMode = UIFormShowMode.Normal;
            base.UIFormLucencyType = UIFormLucenyType.Lucency;
        }

        public void Start()
        {
            btnMiniMap.onClick.AddListener(OnShowFullMap);
        }

        private void OnShowFullMap()
        {
            UiManager.ShowUI("FullMap");
        }
    }
}