/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/09
Description:
    简介：跟随相机的控制器，目前已经不使用了
    作用：
History:
----------------------------------------------------------------------------*/

using System.Numerics;
using SFramework;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace ProjectScript
{
    /// <summary>
    /// 角色跟随相机
    /// </summary>
    public class FollowCam
    {
        public FollowCamData data;
        private float lastFlatAngle;            // 与前一帧相比，目标与相机的相对角度
        private float currentTurnAmount;        
        private float turnSpeedVelocityChange;  // 转向速度的变化

        public FollowCam(GameObject gameObject)
        {
            data = gameObject.GetComponent<FollowCamData>();
            if (data == null)
            {
                Debug.LogError("CharacterCam缺少CharacterCamData！");
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
            {
                FindTarget();
            }
            FollowTarget(Time.deltaTime);
        }

        public void Update()
        {
            if (data == null)
                return;
            if (data.updateType != UpdateType.Update)
                return;
            if (data.isAutoTarget && (data.target == null || !data.target.gameObject.activeSelf))
            {
                FindTarget();
            }
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
            // 先计算一些方向
            var targetForward = data.target.forward;
            // 计算角度
            var currentFlatAngle = Mathf.Atan2(targetForward.x, targetForward.z) * Mathf.Rad2Deg;
            if (data.spinTurnLimit > 0)
            {
                var targetSpinSpeed = Mathf.Abs(Mathf.DeltaAngle(lastFlatAngle, currentFlatAngle)) / deltaTime;
                var desiredTurnAmount =
                    Mathf.InverseLerp(data.spinTurnLimit, data.spinTurnLimit * 0.75f, targetSpinSpeed);
                var turnReactSpeed = (currentTurnAmount > desiredTurnAmount ? .1f : 1f);
                if (Application.isPlaying)
                {
                    currentTurnAmount = Mathf.SmoothDamp(currentTurnAmount, desiredTurnAmount,
                        ref turnSpeedVelocityChange, turnReactSpeed);
                }
                else
                {
                    // 对于编辑器模式，smooth不起作用
                    currentTurnAmount = desiredTurnAmount;
                }
            }
            else
            {
                currentTurnAmount = 1;
            }

            lastFlatAngle = currentFlatAngle;

            data.transform.position =
                Vector3.Lerp(data.transform.position, data.target.position, deltaTime * data.moveSpeed);

            targetForward.y = 0;
            if (targetForward.sqrMagnitude < float.Epsilon)
            {
                targetForward = data.transform.forward;
            }

            var rollRotation = Quaternion.LookRotation(targetForward, Vector3.up);

            data.transform.rotation = Quaternion.Lerp(data.transform.rotation, rollRotation,
                data.rotSpeed * currentTurnAmount * deltaTime);

            //data.transform.rotation =
            //    Quaternion.Slerp(data.transform.rotation, data.target.rotation, deltaTime * data.rotSpeed);
        }
    }
}