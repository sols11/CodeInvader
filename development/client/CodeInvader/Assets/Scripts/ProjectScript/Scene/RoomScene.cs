/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/09
Description:
    简介：登录场景
    作用：登录验证
History:
----------------------------------------------------------------------------*/

using UnityEngine;
using SFramework;

namespace ProjectScript
{
    public class RoomScene : ISceneState
    {
        public RoomScene(SceneController controller) : base(controller)
        {
            this.SceneName = "RoomScene";
        }

        public override void StateBegin()
        {
            base.StateBegin();
            GameMgr.Get.playerMgr.CreateMain();
            GameMgr.Get.uiManager.ShowUI("BattleInfo");
            GameMgr.Get.uiManager.ShowUI("ResourceControl");
            GameMgr.Get.uiManager.ShowUI("BattleOperation");
            GameMgr.Get.inputMgr.CreateJoystick();
            // 场景中硬编码的内容，之后要删除
           /* GameMgr.Get.courseMgr.CreateProgramSentence(3.0f);
            GameMgr.Get.courseMgr.CreateAIModuleInsideRoom();*/
        }
    }
}