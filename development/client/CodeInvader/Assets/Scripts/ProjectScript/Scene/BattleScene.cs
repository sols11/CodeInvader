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

using UnityEngine;
using SFramework;

namespace ProjectScript
{
    public class BattleScene : ISceneState
    {
        public BattleScene(SceneController controller) : base(controller)
        {
            this.SceneName = "BattleScene";
        }

        public override void StateBegin()
        {
            base.StateBegin();
            GameMgr.Get.inputMgr.CreateTouchInput();        // 一定要在相机创建之前
            GameMgr.Get.playerMgr.CreateMain();
            GameMgr.Get.cameraMgr.CreateFreeLookCam();
            GameMgr.Get.uiManager.ShowUI("BattleInfo");
            GameMgr.Get.uiManager.ShowUI("ResourceControl");
            GameMgr.Get.uiManager.ShowUI("BattleOperation");
            // GameMgr.Get.uiManager.ShowUI("Assembly");
            GameMgr.Get.inputMgr.CreateJoystick();
            // Environment
            if (Config.OFFLINE)
            {
                GameMgr.Get.robotMgr.CreateDefault();
                GameMgr.Get.courseMgr.CreateHome();
                GameMgr.Get.courseMgr.CreateComputer(0, null);
                //GameMgr.Get.courseMgr.CreateProgramSentence(10.0f);
            }

            // 获取编程Unit的数据类型与typeId间的映射，用于类型反射
            ProgramUnitMap.SetUnitType();
        }
    }
}