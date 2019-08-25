/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/12
Description:
    简介：俯瞰视角相机的控制器
    构成：主要由FindTarget搜索目标，FollowTarget跟随目标组成。
        该相机的特点是相机移动有范围限定且没有旋转
History:
    TODO:暂未实现移动
----------------------------------------------------------------------------*/

using System.Numerics;
using SFramework;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace ProjectScript
{
    /// <summary>
    /// 自由视角相机
    /// </summary>
    public class OverlookCam
    {
        public OverlookCamData data;

        public OverlookCam(GameObject gameObject)
        {
            data = gameObject.GetComponent<OverlookCamData>();
            if (data == null)
            {
                Debug.LogError("OverlookCam缺少Data！");
                return;
            }

            data.Init();
        }

        public void FixedUpdate()
        {
            if (data == null)
                return;
            if (data.updateType != UpdateType.FixedUpdate)
                return;
            if (data.isAutoTarget && (data.target == null || !data.target.gameObject.activeSelf))
                FindTarget();

            FollowTarget(Time.deltaTime);
        }

        public void Update()
        {
            if (data == null)
                return;
            if (data.updateType != UpdateType.Update)
                return;
            if (data.isAutoTarget && (data.target == null || !data.target.gameObject.activeSelf))
                FindTarget();

            FollowTarget(Time.deltaTime);
        }

        private void FindTarget()
        {
            GameObject targetObj = GameObject.FindGameObjectWithTag(data.targetTag);
            if (targetObj)
            {
                data.target = targetObj.transform;
            }
        }

        private void FollowTarget(float deltaTime)
        {
            // 退出判断
            if (deltaTime <= 0 || data.target == null)
                return;
            // 该相机的特点是相机移动有范围限定且没有旋转

            data.transform.position =
                Vector3.Lerp(data.transform.position, data.target.position, deltaTime * data.moveSpeed);
        }
    }
}