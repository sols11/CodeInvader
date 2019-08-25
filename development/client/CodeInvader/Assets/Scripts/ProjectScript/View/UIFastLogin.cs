/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/16
Description:
    enter room and preparation, waiting for the game start or start game
History:
----------------------------------------------------------------------------*/
using UnityEngine;
using UnityEngine.UI;
using SFramework;

namespace ProjectScript
{

    public class UIFastLogin : ViewBase
    {
        public Button[] accountBtns;
        private void Awake()
        {
            //定义本窗体的性质(默认数值，可以不写)
            base.UIFormType = UIFormType.Fixed;
            base.UIFormShowMode = UIFormShowMode.Normal;
        }

        public void Start()
        {
            for(int i = 0; i < accountBtns.Length; i++)
            {
                accountBtns[i].onClick.AddListener(delegate { OnFastLogin(i); });
            }
        }

        private void OnFastLogin(int i)
        {
            AccountServiceRequest.Login($"test{i}", "163");
        }
    }

}