/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/08
Description:
    简介：输入控制系统，主要是给PC用
    作用：接收玩家输入
History:
    TODO:InputMgr也可以用事件或bool实现（类似DX11作业里的那种），但是在Unity中Input类已经足够使用
----------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using UnityEngine;
using ProjectScript;

namespace SFramework
{
    /// <summary>
    /// 输入控制系统
    /// </summary>
    public class InputMgr : IGameMgr
    {
        public bool canInput = true;

        private Player player;
        private Robot  robot;       // 测试用
        private bool controlRobot;
        private Joystick joystick;
        private UITouchInput touchInput;

        public InputMgr(GameMgr gameMgr) : base(gameMgr)
        {
            controlRobot = false;
        }

        public override void Awake()
        {
            EventMgr.Instance.Listen(ArgEvent.CreatePlayer, EventCreatePlayer);
            EventMgr.Instance.Listen(ArgEvent.CreateRobot, EventCreateRobot);
        }

        public override void FixedUpdate()
        {
            if (player == null)
                return;
        }

        public override void Update()
        {
            // 预先定义=0
            float h = 0;
            float v = 0;
            if (!controlRobot)
            {
                if (player == null)
                    return;
                // 优先用键盘输入，移动平台则不使用
                #if !MOBILE_INPUT
                h = Input.GetAxisRaw(SystemDefine.Horizontal);
                v = Input.GetAxisRaw(SystemDefine.Vertical);
                #endif
                // 如果有摇杆输入，则以摇杆输入替换
                if (joystick)
                {
                    if (Math.Abs(joystick.Horizontal) > Mathf.Epsilon)
                        h = joystick.Horizontal;
                    if (Math.Abs(joystick.Vertical) > Mathf.Epsilon)
                        v = joystick.Vertical;
                }
                // Send Input to Server
                //if(Mathf.Abs(h) > Mathf.Epsilon || Mathf.Abs(v) > Mathf.Epsilon) （if contains input)
                if(canInput)        // 以后不需要debug机器人了再写到最外层判断去
                    player.Move(h, v);
            }
            else
            {
                if (robot == null)
                    return;
                h = Input.GetAxisRaw(SystemDefine.Horizontal);
                v = Input.GetAxisRaw(SystemDefine.Vertical);
            }
        }

        #region 对外接口

        /// <summary>
        /// 用这个接口来创建摇杆
        /// </summary>
        public void CreateJoystick()
        {
             var ui = GameMgr.Get.uiManager.ShowUI("Joystick");
             joystick = ui as Joystick;
        }

        public void RemoveJoystick()
        {
            joystick = null;
            GameMgr.Get.uiManager.CloseUI("Joystick");
        }

        /// <summary>
        /// 用这个接口来创建划屏
        /// </summary>
        public void CreateTouchInput()
        {
            var ui = GameMgr.Get.uiManager.ShowUI("TouchInput");
            if (ui is UITouchInput touch)
            {
                touchInput = touch;
                touchInput.Init();
            }
        }

        public void RemoveTouchInput()
        {
            touchInput = null;
            GameMgr.Get.uiManager.CloseUI("TouchInput");
        }

        #endregion

        private void EventCreatePlayer(object sender, EventArgs e)
        {
            // 创建主角后无需再监听
            EventMgr.Instance.Remove(ArgEvent.CreatePlayer, EventCreatePlayer);
            player = sender as Player;
        }

        private void EventCreateRobot(object sender, EventArgs e)
        {
            // 无需再监听
            EventMgr.Instance.Remove(ArgEvent.CreateRobot, EventCreatePlayer);
            robot = sender as Robot;
        }
    }
}