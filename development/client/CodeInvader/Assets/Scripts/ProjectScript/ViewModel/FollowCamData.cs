/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/09
Description:
    简介：跟随视角相机
History:
----------------------------------------------------------------------------*/
using UnityEngine;
using UnityEditor;
using SFramework;

namespace ProjectScript
{
    public class FollowCamData : MonoBehaviour
    {
        // 组件
        public Transform Pivot { get; private set; }
        public Camera Camera { get; private set; }
        // 属性
        public float moveSpeed = 10;
        public float rotSpeed  = 3;
        public UpdateType updateType = UpdateType.FixedUpdate;
        public bool isAutoTarget = true;
        public string targetTag = "Player";
        public Transform target;
        public float rollSpeed = 0.2f;      // 滚动速度，围绕z轴滚动以匹配target
        public float spinTurnLimit = 90;    // 超过该阈值，摄像机将停止跟踪目标的旋转
        public float targetVelocityLowerLimit = 4f; // 相机转向目标速度的最小速度
        public float smoothTurnTime = 0.2f; // 相机旋转的平滑时间

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