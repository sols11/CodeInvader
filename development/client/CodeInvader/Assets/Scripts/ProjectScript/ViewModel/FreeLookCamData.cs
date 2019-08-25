/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/10
Description:
    简介：自由视角相机的数据设置
History:
----------------------------------------------------------------------------*/
using UnityEngine;
using UnityEditor;
using SFramework;

namespace ProjectScript
{
    public class FreeLookCamData : MonoBehaviour
    {
        // 组件
        public Transform Pivot { get; private set; }
        public Camera Camera { get; private set; }
        // 属性
        public float moveSpeed = 10;
        public float rotSpeed = 3;
        public UpdateType updateType = UpdateType.FixedUpdate;
        public bool isAutoTarget = true;
        public string targetTag = SystemDefine.MAIN_PLAYER;
        public Transform target;
        public float turnSmoothing = 0.0f;                // 会有多少平滑应用于转向输入，以减少鼠标转弯的颠簸
        public float tiltMax = 75f;                       // 轴的x轴旋转的最大值
        public float tiltMin = 45f;                       // 轴的x轴旋转的最小值
        public bool followCursor = false;                 // 若设置为true，则视角会持续跟随鼠标输入（适合PC）。设置为false则不会（适合手机）
        public bool lockCursor = true;                    // 光标是否应该隐藏和锁定。
        public bool verticalAutoReturn = false;           // 设置垂直轴是否自动返回

        public void Init()
        {
            Camera = gameObject.GetComponentInChildren<Camera>();
            if (Camera == null)
            {
                Debug.LogError("CamData找不到Camera组件");
                return;
            }

            Pivot = Camera.transform.parent;
        }
    }
}