/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/18
Description:
    简介：编程操作控件，包括选择和放置两种控件
    使用：
History:
----------------------------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using SFramework;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectScript
{
    public enum PickOrPlace { Pick, Place};
    public class UICodingOperation : ViewBase
    {
        public Button btnPick;
        public Button btnPlace;
        private object resource;
        private Vector3 placePos = Vector3.zero;
        private bool isPutUp = false; // 是否正在搬动资源


        private Dictionary<UiOperativeType, ArrayList> operativeObjects; // 可交互物体的列表，包括可收集资源、可破解的电脑
        private CodeBuilder codeBuilder = new CodeBuilder();
        
        private void Awake()
        {
            //定义本窗体的性质(默认数值，可以不写)
            base.UIFormType = UIFormType.Fixed;
            base.UIFormShowMode = UIFormShowMode.Normal;
            base.UIFormLucencyType = UIFormLucenyType.Lucency;
        }

        private void Start()
        {
            btnPick.onClick.AddListener(OnPickButton);
            btnPlace.onClick.AddListener(OnPlaceButton);
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                // 按下鼠标时检测是否有可拾取的物体
                PickableDetection();
                PlaceDetection();
                // 检测编译事件
                CompileDetection();
            }
        }

        private void OnEnable()
        {
            // 选择物体后才可以进行pickup操作
            btnPick.interactable = false;
            // 拾起物体后才可以进行place操作
            btnPlace.interactable = false;
        }

        // 关闭这个UI了自然交互就不用了
        private void OnDisable()
        {
        }

        private void OnPickButton()
        {
            isPutUp = true;
            // EventMgr.Instance.Invoke(SEvent.PickUpOrPlace, PickOrPlace.Pick, resource);
            btnPick.interactable = false;
            btnPlace.interactable = true;
        }

        private void OnPlaceButton()
        {
            isPutUp = false;
            Debug.Log("Place");
            // EventMgr.Instance.Invoke(SEvent.PickUpOrPlace, PickOrPlace.Place, placePos);
            btnPlace.interactable = false;
        }

        private void PickableDetection()
        {
            // 点击AI模块，按钮将置为可拾起状态
            /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.name.Contains("AIModule") && !isPutUp)
                {
                    resource = new AIModuleItem(hit.collider.gameObject.GetComponent<AIModuleData>());
                    btnPick.interactable = true;
                }
            }*/
        }

        private void PlaceDetection()
        {
            // 点击AI模块，按钮将置为可拾起状态
           /* Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (isPutUp && hit.collider.name.Contains("Floor"))
                {
                    placePos = hit.point;
                    btnPick.interactable = true;
                }
            }*/
        }

        private void CompileDetection()
        {
            // 点击AI模块，按钮将置为可拾起状态
          /*  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name.Contains("Compile"))
                {
                    codeBuilder.Run(codeBuilder.HardCodeForTest());
                }
            }*/
        }

        #region Events

        #endregion

    }
}