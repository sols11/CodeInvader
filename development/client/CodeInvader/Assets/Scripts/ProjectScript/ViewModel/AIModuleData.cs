/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/21
Description:
    简介：AI模块数据
    作用：挂载于GameObject
    使用：模块不会旋转，来源只有破解PC或敌人掉落
History:
----------------------------------------------------------------------------*/
using System;
using ItemStruct;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

namespace ProjectScript
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class AIModuleData : ItemData
    {
        // 颜色分类，正式版去掉或换成图标显示
        private List<Color> ModuleTextColor = new List<Color>
        {
            new Color(255f/255f, 0f/255f, 0f/255f), // KeyWord 
            new Color(0f/255f, 60f/255f, 255f/255f), // Entity
            new Color(60f/255f, 60f/255f,60f/255f), // Status
            new Color(30f/255f, 170f/255f,60f/255f), // Act
        };

        // 组件
        public Rigidbody Rgbd { get; private set; }
        public Collider Collider { get; private set; }
        // TextMesh
        public TextMesh Text { get; private set; }
        
        // 读表可得
        [HideInInspector] public string name;
        [HideInInspector] public string info;
       
        public AIModuleData(BaseItemData data)
        {
            SetItemData(data);
        }
        
        public void SetAiData(AiItemInfo aiInfo)
        {
            name = aiInfo.Name ?? "";
            info = aiInfo.Info ?? "";
        }

        private void Awake()
        {
            Rgbd = gameObject.GetComponent<Rigidbody>();
            Rgbd.freezeRotation = true;
            Collider = gameObject.GetComponent<Collider>();
            Text = transform.Find("Text").GetComponent<TextMesh>();
        }

        private void Update()
        {
            
        }

        // 可拾取资源触发，资源在主玩家一定范围内可以被拾取
        /*private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(SystemDefine.MAIN_PLAYER))
            {
                // 可以交互，交互的对象是本对象（需要发送要交互的对象）若EventArgs参数是empty则可交互，若为null则不可交互
                EventMgr.Instance.Invoke(ArgEvent.UiInteractState, this, new InteractiveArgs(UiOperativeType.Collect, true));
            }
        }*/

        /*private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(SystemDefine.MAIN_PLAYER))
            {
                // 禁止交互
                EventMgr.Instance.Invoke(ArgEvent.UiInteractState, this, new InteractiveArgs(UiOperativeType.Collect, false));
            }
        }*/

    }
}