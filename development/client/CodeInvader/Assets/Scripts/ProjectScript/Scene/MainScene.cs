/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/07
Description:
    简介：主场景
    作用：用户主界面及房间选择
History:
----------------------------------------------------------------------------*/

using UnityEngine;
using SFramework;
using UnityEngine.SceneManagement;

namespace ProjectScript
{
    public class MainScene : ISceneState
    {
        public MainScene(SceneController controller) : base(controller)
        {
            this.SceneName = "LoginScene";
        }

        public override void StateBegin()
        {
            base.StateBegin();
            GameMgr.Get.uiManager.ShowUI("Main");
        }
    }
}