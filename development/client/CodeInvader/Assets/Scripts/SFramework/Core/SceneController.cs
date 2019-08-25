/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/07
Description:
    简介：场景状态机类
    作用：控制场景的切换，包括异步加载和同步加载两种方式，还包括退出游戏功能。
    使用：对当前场景状态执行场景初始化、更新、释放。调用SetState即可切换场景。
    通过GameLoop单例访问到此类
    补充：每添加一个SceneState，都需要修改SceneState枚举和SetState方法的switch-case，一个场景可以对应多个SceneState
History:
    TODO:异步加载因资源未齐全暂时关闭使用
    TODO:异步加载可以用Unity新API优化
    TODO:需要引用ProjectScript命名空间，考虑用反射与逻辑解耦
----------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ProjectScript;

namespace SFramework
{
    /// <summary>
    /// 场景状态类枚举。
    /// 每添加一个SceneState，都需要修改enum和SetState方法的switch-case，一个场景可以对应多个SceneState
    /// </summary>
    public enum SceneState
    {
        LoginScene,
        TutorialScene,
        MainScene,
        BattleScene,
        RoomScene,
    }

    /// <summary>
    /// 场景状态机
    /// </summary>
    public class SceneController
    {
        public ISceneState CurrentState { get; private set; }   // 当前场景
        private bool isSceneBegin = false;                      // 场景是否已经加载

        public SceneController()
        {
        }

        /// <summary>
        /// 设置当前场景（加载场景）
        /// </summary>
        public void SetScene(SceneState sceneState, bool isNow = true, bool isAsync = false)
        {
            ISceneState state;
            switch (sceneState)
            {
                case SceneState.LoginScene:
                    state = new LoginScene(this);
                    break;
                case SceneState.MainScene:
                    state = new MainScene(this);
                    break;
                case SceneState.BattleScene:
                    state = new BattleScene(this);
                    break;
                case SceneState.RoomScene:
                    state = new RoomScene(this);
                    break;
                default:
                    return;
            }
            Debug.Log("SetScene:" + state.ToString());
            isSceneBegin = false;

            // 通知前一个State结束
            if (CurrentState != null)
                CurrentState.StateEnd();
            // 载入场景
            if (isNow)
            {
                if (isAsync)
                {
                    //UILoading.nextScene = state.SceneName;
                    //LoadScene("Loading");
                }
                else
                {
                    LoadScene(state.SceneName);
                }
            }
            // 设置当前场景
            CurrentState = state;
        }

        // 场景的载入
        private void LoadScene(string loadSceneName)
        {
            if (string.IsNullOrEmpty(loadSceneName))
                return;
            SceneManager.LoadScene(loadSceneName);
        }

        // 更新
        public void FixedUpdate()
        {
            if (Application.isLoadingLevel)
                return;
            if (CurrentState != null && isSceneBegin)
                CurrentState.FixedUpdate();
        }

        public void StateUpdate()
        {
            // 是否还在载入
            if (Application.isLoadingLevel)
                return;

            // 通知新的State开始，因为不能保证StateBegin会在什么时候调用，所以放在Update中
            if (CurrentState != null && isSceneBegin == false)
            {
                CurrentState.StateBegin();
                isSceneBegin = true;
            }

            //状态的更新，需要StateBegin()执行完后才能执行
            if (CurrentState != null && isSceneBegin)
                CurrentState.StateUpdate();
        }


        public void ExitApplication()
        {
            isSceneBegin = false;

            // 通知前一個State结束
            if (CurrentState != null)
                CurrentState.StateEnd();

            Application.Quit();
        }

    }
}