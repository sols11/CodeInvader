/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/07
Description:
    简介：相机管理系统
    作用：控制游戏中的相机
    使用：Create接口创建相机
          其他的为生命周期接口无需使用
    补充：我们为Camera制定了一个Prefab，默认是3层结构。
            顶层root结点一般是和transform同步的跟随结点，这个transform会根据具体情况计算出来
            次层pivot结点负责一些偏移
            然后的MainCamera结点，是Camera实际所在的位置
History:
    TODO：如果需要一些特殊效果，可以添加DoTween之类的插件
----------------------------------------------------------------------------*/

using System;
using ProjectScript;
using UnityEngine;

namespace SFramework {

    /// <summary>
    /// Camera管理
    /// </summary>
    public class CameraMgr : IGameMgr {
        private FreeLookCam freeLookCam;
        private OverlookCam overlookCam;
        private string cameraPath = @"Cameras\";

        public CameraMgr(GameMgr gameMgr):base(gameMgr)
        {
            
        }

        #region 对外接口
        public void CreateFreeLookCam()
        {
            if (freeLookCam != null)
                return;
            GameObject gameObject = GameMgr.Get.resourcesMgr.LoadAsset(cameraPath + "FreeLookCamera");
            freeLookCam = new FreeLookCam(gameObject);
            EventMgr.Instance.Invoke(SEvent.CreateFreeLookCam, freeLookCam, EventArgs.Empty);
        }

        public void CreateOverlookCam()
        {
            if (overlookCam != null)
                return;
            GameObject gameObject = GameMgr.Get.resourcesMgr.LoadAsset(cameraPath + "OverlookCamera");
            overlookCam = new OverlookCam(gameObject);
            EventMgr.Instance.Invoke(ArgEvent.CreateFollowCam, overlookCam, EventArgs.Empty);
        }

        public void ChangeTarget(Transform target)
        {
            // TODO
            if (freeLookCam != null)
                freeLookCam.data.target = target;

            if (overlookCam != null)
                overlookCam.data.target = target;
        }
        #endregion

        public override void Release()
        {
            if (freeLookCam != null)
                freeLookCam.Release();
            freeLookCam = null;
            overlookCam = null;
        }

        public override void FixedUpdate()
        {
            if (freeLookCam != null)
                freeLookCam.FixedUpdate();
            if (overlookCam !=null)
                overlookCam.FixedUpdate();
        }

        public override void Update()
        {
            if (freeLookCam != null)
                freeLookCam.Update();
            if (overlookCam != null)
                overlookCam.Update();
        }
    }
}