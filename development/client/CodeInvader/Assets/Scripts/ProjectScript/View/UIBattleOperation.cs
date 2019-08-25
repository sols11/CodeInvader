/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
    caodahan@corp.netease.com
Date:
    2019/08/18
Description:
    简介：战斗操作UI，包括交互和拾取两种操作
    使用：目前可交互对象的类型有ComputerData、AIModuleData、AIComponentData（这些数据按交互方式分为可破解的，可收集的）
History:
    TODO:写法太复杂了，两个list其实就够了
----------------------------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using SFramework;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectScript
{
    // 实体与用户的操作交互方式： 收集类（编程组件及武器），破解类（电脑）
    public enum UiOperativeType { Collect, Decode}
    public class InteractiveArgs: EventArgs
    {
        public UiOperativeType type { get; private set; }
        public bool interact { get; private set; }
        public InteractiveArgs(UiOperativeType uiInteractiveType, bool trigger)
        {
            type = uiInteractiveType;
            interact = trigger;
        }
    }

    public class UIBattleOperation : ViewBase
    {
        public Button btnInteract;
        public Button btnCollect;
        private Inventory backpack = Inventory.Instance;

        private Dictionary<UiOperativeType, ArrayList> operativeObjects; // 可交互物体的列表，包括可收集资源、可破解的电脑
        private CodeBuilder codeBuilder = new CodeBuilder();

        private void Awake()
        {
            base.UIFormType = UIFormType.Fixed;
            base.UIFormShowMode = UIFormShowMode.Normal;
            base.UIFormLucencyType = UIFormLucenyType.Lucency;
        }

        private void Start()
        {
            btnInteract.onClick.AddListener(OnInteractButton);
            btnCollect.onClick.AddListener(OnCollectButton);
        }

        private void Update()
        {
            if (backpack.CollectableCount() > 0)
                btnCollect.interactable = true;
            else
                btnCollect.interactable = false;
        }

        private void OnEnable()
        {
            operativeObjects = new Dictionary<UiOperativeType, ArrayList>
            {
                {UiOperativeType.Decode, new ArrayList() }
            };
            EventMgr.Instance.Listen(ArgEvent.UiInteractState, UiInteractState);
        }

        // 关闭这个UI了自然交互就不用了
        private void OnDisable()
        {
            EventMgr.Instance.Remove(ArgEvent.UiInteractState, UiInteractState);
            operativeObjects.Clear();
        }

        private void OnInteractButton()
        {
            if (true)
                Decoding();     //在室外场景按下交互键，功能为破解电脑
            // TODO 增加室内场景中拿起放下资源的逻辑
        }

        private void Decoding()
        {
            // 在Battle场景中交互键用于破解电脑
            int length = operativeObjects[UiOperativeType.Decode].Count;
            if (length <= 0)
            {
                btnInteract.interactable = false;
                return;
            }
            object obj = operativeObjects[UiOperativeType.Decode][length - 1];    // Get the back one
            if (obj is ComputerData data)
            {
                // 即使玩家已经在Decoding，再次按下我们也依然触发事件，但是Player本身会做处理
                if (Config.OFFLINE)
                {
                    GameMgr.Get.playerMgr.Crack(GameMgr.Get.playerMgr.mainEid, data.eid, true);
                }
                else
                {
                    PlayerServiceRequest.Crack(GameMgr.Get.playerMgr.mainEid, data.eid, true);
                }
            }
        }

        private void OnCollectButton()
        {
            // 用户采集物品
            ItemData selectedItem = Inventory.Instance.CollectableGet();
            if (selectedItem != null)
                EventMgr.Instance.Invoke(SEvent.PlayerPick, this, selectedItem.eid);
        }

        #region Events

        private void UiInteractState(object sender, EventArgs e)
        {
            InteractiveArgs interactive = (InteractiveArgs)e;
            if (!interactive.interact)
            {
                // Exit Trigger
                operativeObjects[interactive.type].Remove(sender);      // 该API是安全删除，不会抛异常
                
                if(operativeObjects[interactive.type].Count <= 0)       // 若周围无可交互物体，则禁用按键
                {
                    if (interactive.type == UiOperativeType.Decode)
                        btnInteract.interactable = false;
                }       
            }
            else
            {
                // Enter Trigger
                operativeObjects[interactive.type].Add(sender);
                if (interactive.type == UiOperativeType.Decode)
                    btnInteract.interactable = true;        // 启用交互按键
            }
        }

        #endregion

    }
}