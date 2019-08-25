/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/14
Description:
    简介：电脑
    作用：
    使用：接收到Decoding事件时，角色播放Decoding动画，电脑更新Decoding进度，同时UI也显示Decoding进度
History:
----------------------------------------------------------------------------*/

using System;
using SFramework;
using UnityEngine;
using UnityEditor;

namespace ProjectScript
{
    public class Computer
    {
        public ComputerData data;
        public bool sendedCompleteMsg = false;

        public Computer(GameObject gameObject)
        {
            data = gameObject.GetComponent<ComputerData>();
            if (data == null)
            {
                Debug.LogError("Computer缺少Data！");
                return;
            }

            data.Init();
            //EventMgr.Instance.Listen(SEvent.PlayerDecodeState, this.PlayerDecodeState);
        }

        public void Release()
        {
            //EventMgr.Instance.Remove(SEvent.PlayerDecodeState, this.PlayerDecodeState);
        }

        /// <summary>
        /// 若正在破解，则更新数据
        /// </summary>
        public void Update()
        {
            if (data.beingDecoded)
            {
                data.CrackTimer += Time.deltaTime;
                if (data.CrackTimer >= data.needTime && !sendedCompleteMsg)
                {
                    sendedCompleteMsg = true;  // 保证只发1次消息，TCP保证能收到回应
                    if (Config.OFFLINE)
                    {
                        DecodeComplete();
                        GameMgr.Get.playerMgr.Crack(GameMgr.Get.playerMgr.mainEid, data.eid, false);
                    }
                    else
                        PlayerServiceRequest.CrackComplete(data.eid);
                }
                EventMgr.Instance.Invoke(ArgEvent.Decoding, this, EventArgs.Empty);
            }
        }
        
        #region 对Mgr接口

        public void StartDecoded()
        {
            data.beingDecoded = true;
            GameMgr.Get.uiManager.ShowUI("Decoding");
        }

        public void StopDecoded()
        {
            data.beingDecoded = false;
            GameMgr.Get.uiManager.CloseUI("Decoding");
        }
        
        /// <summary>
        /// 破解完毕
        /// </summary>
        public void  DecodeComplete()
        {
            // Close Trigger
            foreach (var col in data.Colliders)
            {
                if (col.isTrigger)
                    col.enabled = false;
            }
            // Set State
            data.beingDecoded = false;
            data.completed = true;
            // UI Events
            EventMgr.Instance.Invoke(ArgEvent.UiInteractState, data, new InteractiveArgs(UiOperativeType.Decode, false));
            // 结束 停止交互
            //EventMgr.Instance.Invoke(SEvent.PlayerDecodeState, this, null);
            //StopDecoded();
            //EventMgr.Instance.Remove(SEvent.PlayerDecodeState, this.PlayerDecodeState);
        }

        #endregion

    }
}