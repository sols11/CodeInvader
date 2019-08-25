/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/08
Description:
    简介：玩家角色类
    作用：MVVM中的Controller，存放行为
    使用：数据存放于PlayerData中
    补充：主角的行为：移动、破解、方块交互、血量
History:
----------------------------------------------------------------------------*/

using System;
using CommonStruct;
using DG.Tweening;
using PlayerMessage;
using SFramework;
using UnityEngine;
using UnityEditor;

namespace ProjectScript
{
    public class Player
    {
        public PlayerData data;
        public int team;        // 标明是哪个阵营的
        // Parameters & States
        private AnimatorStateInfo stateInfo;
        private string animMove = "Move";
        private string animDecode = "Decode";
        private string animHurt = "Hurt";
        private string animDead = "Dead";
        private string animPick = "Pick";
        // Directions
        private float speed;
        private Vector3 targetDirection;  // 输入的方向
        private Vector3 forwardDirection; // 存储输入后的朝向
        private Transform mainCamera;
        // Sync & Time
        private float syncRate = 0.1f;    // 只要有输入就会同步
        private float lastSyncTime = 0;
        private Vector3 targetPos;
        private Quaternion targetRot;

        public Player(GameObject gameObject)
        {
            data = gameObject.GetComponent<PlayerData>();
            if (data == null)
            {
                Debug.LogError("Player GameObject缺少PlayerData！");
                return;
            }

            data.Init();
            targetPos = data.transform.position;
            targetRot = data.transform.rotation;
            // 事件
            EventMgr.Instance.Listen(SEvent.CreateFreeLookCam, this.EventCreateCamera);
            //EventMgr.Instance.Listen(SEvent.PlayerDecodeState, this.PlayerDecodeState);
            if (gameObject.tag == SystemDefine.MAIN_PLAYER)
                EventMgr.Instance.Listen(SEvent.PlayerPick, this.PlayerPick);
        }

        public void Initialize()
        {
        }

        public void Release()
        {
            data.Release();
            data = null;
            EventMgr.Instance.Remove(SEvent.CreateFreeLookCam, this.EventCreateCamera);
            //EventMgr.Instance.Remove(SEvent.PlayerDecodeState, this.PlayerDecodeState);
        }

        public void FixedUpdate()
        {
            if (data == null)
                return;
            Move();
            Rotate();
        }

        public void Update()
        {
            stateInfo = data.Animator.GetCurrentAnimatorStateInfo(0);
        }

        #region 对外接口

        /// <summary>
        /// 本机移动（优先表现）
        /// </summary>
        /// <param name="h"></param>
        /// <param name="v"></param>
        public void Move(float h, float v)
        {
            Vector3 inputDir = new Vector3(h, 0, v);
            if (mainCamera != null)
            {
                // 获得剔除y轴影响后的相机朝向（即mainCamera.forward在XZ平面上的投影）
                forwardDirection = Vector3.Scale(mainCamera.forward, new Vector3(1, 0, 1)).normalized;
                targetDirection = v * forwardDirection + h * mainCamera.right;
            }
            else
            {
                // 不受相机影响的情况下，计算目标方向
                targetDirection = Quaternion.AngleAxis(0, Vector3.up) * inputDir.normalized;
            }
            // 不在Joystick中设置Dead Zone，而是自己检测，如果总输入小于0.1，我们认为不移动，但是可以旋转
            if (inputDir.magnitude > 0.1f)   // 保证其斜线移动速度和直线一样
            {
                speed = data.moveSpeed;
                // 离开破解（TODO:应该只发一次，以后优化。目前是根据动画帧可能会发2次）
                if (stateInfo.IsName(animDecode))
                {
                    data.Animator.SetBool(animDecode, false);
                    // computerId发0，因为client不记录player对应的computerId
                    if (Config.OFFLINE)
                        GameMgr.Get.playerMgr.Crack(data.eid, 0, false);
                    else
                        PlayerServiceRequest.Crack(data.eid, 0, false);
                    //EventMgr.Instance.Invoke(SEvent.PlayerDecodeState, this, null);
                }
            }
            else
            {
                speed = 0;
            }
            data.Animator.SetFloat(animMove, speed);

            // 角色朝向随输入方向变化而变化
            if (targetDirection != Vector3.zero)
            {
                // 目标方向的旋转角度
                targetRot = Quaternion.LookRotation(targetDirection, Vector3.up);
            }
            // Sync
            if (Config.OFFLINE)
            {
                targetPos = data.transform.position + Time.deltaTime * speed * targetDirection;
            }
            else if (Time.time - lastSyncTime >= syncRate)
            {
                lastSyncTime = Time.time;
                // Send Direction
                PlayerServiceRequest.Move(data.eid, targetDirection.normalized, targetRot);
            }
        }

        /// <summary>
        /// 位置同步校正
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="rot"></param>
        public void Move(Vector3 pos, Quaternion rot)
        {
            targetPos = pos;
            // 因服务端不计算旋转，故主玩家不接受同步的旋转信息
            if (!data.transform.CompareTag(SystemDefine.MAIN_PLAYER))
                targetRot = rot;
        }

        public void Hurt(DamageInfo info)
        {
            if (data.state == NetState.Death)
                return;
            data.CurrentHp -= (int)info.Attack;
            if (data.CurrentHp <= 0)
                Dead();
            else
                data.Animator.SetTrigger(animHurt);
        }

        public void Dead()
        {
            // TODO
            data.state = NetState.Death;
            data.CurrentHp = 0;
            data.Animator.SetTrigger(animDead);
        }

        public void Decode(bool decode, Transform t)
        {
            data.Animator.SetBool(animDecode, decode);
            // 若直接赋值MovePosition而不设置targetPos就没有意义，因为位置会被服务端同步位置覆盖
            if (decode && t != null)
            {
                var position = t.position;
                var rotation = t.rotation;
                targetPos = position;
                targetRot = rotation;
                data.Rgbd.MovePosition(position);
                data.Rgbd.MoveRotation(rotation);
                //GameMgr.Get.inputMgr.canInput = false;
            }
        }

        #endregion

        #region 私有方法
        private void Move()
        {
            float step = data.moveSpeed * Time.deltaTime;
            Vector3 pos = Vector3.MoveTowards(data.transform.position, targetPos, step);
            data.Rgbd.MovePosition(pos);
        }

        private void Rotate()
        {
            float step = data.rotSpeed * Time.deltaTime;
            Quaternion newRotation = Quaternion.Slerp(data.Rgbd.rotation, targetRot, step);
            data.Rgbd.MoveRotation(newRotation);

            //if (targetDirection != Vector3.zero)
            //{
            //    // 目标方向的旋转角度
            //    Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            //}
        }
        #endregion

        #region Events

        private void EventCreateCamera(object sender, object args)
        {
            if (sender is FreeLookCam cam)
            {
                if (cam.data != null)
                    mainCamera = cam.data.Camera.transform;
            }
        }

        /// <summary>
        /// 举起或放下方块
        /// </summary>
        /// <param name="isPutUp">若为true则举起方块</param>
        private void PlayerPick(object op, object e)
        {
            // 玩家拾取物品
            PlayerServiceRequest.PickItem(data.eid, (int)e);
        }

        #endregion

    }
}
