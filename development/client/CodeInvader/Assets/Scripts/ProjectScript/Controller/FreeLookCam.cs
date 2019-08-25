/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/10
Description:
    简介：自由视角相机的控制器
    构成：主要由FindTarget搜索目标，FollowTarget跟随目标，和HandleRotationMovement处理旋转三个方法组成。
History:
----------------------------------------------------------------------------*/

using System.Numerics;
using SFramework;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using static UnityEngine.Screen;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace ProjectScript
{
    /// <summary>
    /// 自由视角相机
    /// </summary>
    public class FreeLookCam
    {
        public FreeLookCamData data;

        private float lookAngle;                    // 调节root结点的y轴旋转
        private float tiltAngle;                    // 调节pivot结点的x轴旋转
        private Vector3 pivotEulers;
        private Quaternion pivotTargetRot;
        private Quaternion transformTargetRot;

        public FreeLookCam(GameObject gameObject)
        {
            data = gameObject.GetComponent<FreeLookCamData>();
            if (data == null)
            {
                Debug.LogError("FreeLookCam缺少Data！");
                return;
            }

            data.Init();
            // Init
            Cursor.lockState = data.lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !data.lockCursor;
            pivotEulers = data.Pivot.rotation.eulerAngles;

            pivotTargetRot = data.Pivot.transform.localRotation;
            transformTargetRot = data.transform.localRotation;
        }

        public void Release()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
            if (data.followCursor)
                MouseInput();
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
            if (data.lockCursor && Input.GetMouseButtonUp(0))
            {
                Cursor.lockState = data.lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
                Cursor.visible = !data.lockCursor;
            }
            if (data.followCursor)
                MouseInput();
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

            data.transform.position =
                Vector3.Lerp(data.transform.position, data.target.position, deltaTime * data.moveSpeed);
        }

        public void MouseInput()
        {
            // 用户输入
            float x = CrossPlatformInputManager.GetAxis("Mouse X");
            float y = CrossPlatformInputManager.GetAxis("Mouse Y");
            HandleRotationMovement(x, y);
            return;
            // 限制仅单指输入时才可旋转
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.x < width / 2)
                    return;
                // 如果检测到此触控点的状态时正在滑动
                if (touch.phase == TouchPhase.Moved)
                {
                    // 得到触控点相对上一帧的位移
                    x = touch.deltaPosition.x;
                    y = touch.deltaPosition.y;
                }
            }
        }

        public void HandleRotationMovement(float x, float y)
        {
            if (Time.timeScale < float.Epsilon)
                return;

            // 调整水平视角
            lookAngle += x * data.rotSpeed;
            transformTargetRot = Quaternion.Euler(0f, lookAngle, 0f);

            // 调整垂直视角
            if (data.verticalAutoReturn)
            {
                // 对于tilt输入，我们需要根据是使用鼠标还是触摸输入来做出不同的动作:
                // 在移动端，垂直输入直接映射到tilt值，因此当释放输入时，它会自动弹回来。我们必须测试是否高于或低于零，因为我们想自动返回零，即使最小值和最大值不对称。
                tiltAngle = y > 0 ? Mathf.Lerp(0, -data.tiltMin, y) : Mathf.Lerp(0, data.tiltMax, -y);
            }
            else
            {
                // 在有鼠标的平台上，我们根据鼠标Y轴输入和转弯速度来调整当前角度
                tiltAngle -= y * data.rotSpeed;
                // 并确保新值在范围内
                tiltAngle = Mathf.Clamp(tiltAngle, -data.tiltMin, data.tiltMax);
            }

            // 执行x轴旋转
            pivotTargetRot = Quaternion.Euler(tiltAngle, pivotEulers.y, pivotEulers.z);

            if (data.turnSmoothing > 0)
            {
                data.Pivot.localRotation = Quaternion.Slerp(data.Pivot.localRotation, pivotTargetRot, data.turnSmoothing * Time.deltaTime);
                data.transform.localRotation = Quaternion.Slerp(data.transform.localRotation, transformTargetRot, data.turnSmoothing * Time.deltaTime);
            }
            else
            {
                data.Pivot.localRotation = pivotTargetRot;
                data.transform.localRotation = transformTargetRot;
            }
        }

    }
}