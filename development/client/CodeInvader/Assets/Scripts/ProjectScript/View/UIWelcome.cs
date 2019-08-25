/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/15 11:16
Description:
    
History:
----------------------------------------------------------------------------*/

using SFramework;
using UnityEngine.UI;

namespace ProjectScript
{
    public class UIWelcome : ViewBase
    {
        public Button btnStart;
        public Button btnTutorial;
        public Button btnExit;
        public Button btnSetting;
        
        private void Awake()
        {
            //瀹氫箟鏈獥浣撶殑鎬ц川(榛樿鏁板€硷紝鍙互涓嶅啓)
            base.UIFormType = UIFormType.Normal;
            base.UIFormShowMode = UIFormShowMode.Normal;
            base.UIFormLucencyType = UIFormLucenyType.Lucency;
        }

        private void Start()
        {
            btnStart.onClick.AddListener(OnStartButton);
            btnTutorial.onClick.AddListener(OnTutorialButton);
            btnExit.onClick.AddListener(OnExitButton);
            btnSetting.onClick.AddListener(OnSettingButton);
        }

        private void OnStartButton()
        {
            UiManager.ShowUI("Login");
            UiManager.ShowUI("FastLogin");
        }

        private void OnTutorialButton()
        {
            // TODO 目前用于单机测试进入场景
            GameLoop.Instance.sceneController.SetScene(SceneState.BattleScene);
        }

        private void OnExitButton()
        {
            GameLoop.Instance.sceneController.ExitApplication();
        }

        private void OnSettingButton()
        {
            // TODO 璺宠浆鑷宠缃晫闈?
        }
        
    }
}