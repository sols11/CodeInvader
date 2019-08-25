/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/07
Description:
    简介：登录场景
    作用：登录验证
History:
----------------------------------------------------------------------------*/

using System;
using UnityEngine;
using SFramework;
using UnityEngine.SceneManagement;

namespace ProjectScript
{
    public class LoginScene : ISceneState
    {
        public LoginScene(SceneController controller) : base(controller)
        {
            this.SceneName = "LoginScene";
        }

        public override void StateBegin()
        {
            base.StateBegin();
            GameMgr.Get.uiManager.ShowUI("Welcome");
        }
    }

}