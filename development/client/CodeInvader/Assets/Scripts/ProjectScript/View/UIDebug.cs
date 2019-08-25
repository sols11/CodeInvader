/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/14
Description:
    简介：调试用UI
History:
----------------------------------------------------------------------------*/

using System;
using SFramework;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectScript
{
    public class UIDebug : ViewBase
    {
        public Button btnAttack;
        public Button btnHurt;

        private void Awake()
        {
            base.UIFormType = UIFormType.Fixed;
            base.UIFormShowMode = UIFormShowMode.Normal;
            base.UIFormLucencyType = UIFormLucenyType.Lucency;
        }

        private void Start()
        {
            btnAttack.onClick.AddListener(OnAttackButton);
            btnHurt.onClick.AddListener(OnHurtButton);
        }

        private void OnAttackButton()
        {
            // 测试，目前其实没什么数据要传
            EventMgr.Instance.Invoke(ArgEvent.RobotAttack, this, EventArgs.Empty);
        }

        private void OnHurtButton()
        {
            EventMgr.Instance.Invoke(ArgEvent.PlayerHurt, this, EventArgs.Empty);
        }
    }
}