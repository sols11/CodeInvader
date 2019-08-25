/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/12
Description:
    简介：俯瞰视角相机的数据设置
History:
----------------------------------------------------------------------------*/
using UnityEngine;
using UnityEditor;
using SFramework;

namespace ProjectScript
{
    public class OverlookCamData : MonoBehaviour
    {
        // 组件
        public Transform Pivot { get; private set; }
        public Camera Camera { get; private set; }
        // 属性
        public float moveSpeed = 10;
        public UpdateType updateType = UpdateType.FixedUpdate;
        public bool isAutoTarget = true;
        public string targetTag = SystemDefine.MAIN_PLAYER;
        public Transform target;
        public float turnSmoothing = 0.0f;                // 会有多少平滑应用于转向输入，以减少鼠标转弯的颠簸
        [Header("相机显示区域限定")]
        public Vector3 leftUpLimit;                       // 左上角
        public Vector3 rightDownLimit;                    // 右下角

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