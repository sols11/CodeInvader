/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/18
Description:
    简介：资源操作界面, 包括背包按键
History:
----------------------------------------------------------------------------*/
using CommonStruct;
using SFramework;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectScript
{
    public class UIResourceControl : ViewBase
    {
        public Button btnBackpack;

        private void Awake()
        {
            //定义本窗体的性质(默认数值，可以不写)
            base.UIFormType = UIFormType.Fixed;
            base.UIFormShowMode = UIFormShowMode.Normal;
            base.UIFormLucencyType = UIFormLucenyType.Lucency;
        }

        private void Start()
        {
            btnBackpack.onClick.AddListener(OnShowBackpack);
        }

        private void OnShowBackpack()
        {
            UiManager.ShowUI("Backpack");
        }
    }
}