/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/07
Description:
    简介：游戏主程序，单例模式，控制子系统
    作用：整合所有子系统的接口及功能，并控制所有子系统的生命周期。
    使用：可以直接调用 GameMgr.Get.你需要使用的子系统
          要添加新的子系统时，需要修改该类的源码
    补充：只要主程序是Singleton单例，这样访问子系统就不需要使用单例。该类执行顺序：
            1. 构造函数		构造所有子系统成员
            2. Awake        初次构造后的初始化(Awake方法通常需要用到其他Mgr，因此需要在构造函数之后执行)
            3. Initialize   加载新场景后的初始化，场景重新加载后也会调用
            4. FixedUpdate  固定时间的更新
            5. Update       每帧循环更新
            6. Release      场景结束时的释放
            子系统在切换场景时不会被销毁，只会释放需要释放的空间
History:
    GameMgr只存放需要控制生命周期的Mgr，其他功能Mgr直接单例调用
    TODO:将常用的需要多个子系统的调用功能封装为接口，不需经过子系统来调用
    TODO:在此只调用有实现接口的Mgr的接口，未实现的不调用，若之后修改补充了实现则补充进去
----------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework
{
    /// <summary>
    /// 游戏主程序。单例，控制子系统
    /// </summary>
    public class GameMgr
    {
        // Singleton单例，只要主程序是单例，那么子系统都不需要单例
        private static GameMgr instance;
        // 将单例调用简化为Get，意义更符合实际，我们是通过GameMgr Get到单例子系统的
        public static GameMgr Get
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameMgr();
                    instance.Awake();
                }
                return instance;
            }
        }

        // 创建各Mgr实例
        public FileMgr fileMgr;
        public EventMgr eventMgr;

        public ResourcesMgr resourcesMgr;
        public UIManager uiManager;
        public UIMaskMgr uiMaskMgr;
        public CourseMgr courseMgr;
        public AudioMgr audioMgr;
        public PlayerMgr playerMgr;
        public RobotMgr robotMgr;
        public InputMgr inputMgr;
        public CameraMgr cameraMgr;

        /// <summary>
        /// private单例构造
        /// </summary>
        private GameMgr()
        {
            // 单例Mgr
            fileMgr = FileMgr.Instance;
            eventMgr = EventMgr.Instance;
            // 有生命周期的Mgr
            resourcesMgr = new ResourcesMgr(this);
            uiManager = new UIManager(this);
            uiMaskMgr = new UIMaskMgr(this);
            courseMgr = new CourseMgr(this);
            audioMgr = new AudioMgr(this);
            playerMgr = new PlayerMgr(this);
            robotMgr = new RobotMgr(this);
            inputMgr = new InputMgr(this);
            cameraMgr = new CameraMgr(this);
        }

        /// <summary>
        /// 初次构造后的初始化(Awake方法通常需要用到其他Mgr，因此需要在构造函数之后执行)
        /// </summary>
        public void Awake()
        {
            // 注意Awake不能放在构造函数内执行，因为这将导致主程序未构造完毕就开始使用，破坏了单例的存在，造成栈溢出错误
            uiManager.Awake();
            audioMgr.Awake();
            courseMgr.Awake();
            inputMgr.Awake();
            Debug.Log("框架初始化完成");
        }

        // 以下出现的Mgr是有生命周期的Mgr，它们不能脱离GameMgr的控制而执行，因此它们本身不为单例模式
        /// <summary>
        /// 每次场景加载后调用
        /// </summary>
        public void Initialize()
        {
            playerMgr.Initialize();
            robotMgr.Initialize();
            uiManager.Initialize();
            uiMaskMgr.Initialize();
            courseMgr.Initialize();
        }

        /// <summary>
        /// 场景切换时调用
        /// </summary>
		public void Release()
        {
            resourcesMgr.Release();
            playerMgr.Release();
            robotMgr.Release();
            uiManager.Release();
            audioMgr.Release();
            inputMgr.Release();
            cameraMgr.Release();
            courseMgr.Release();
        }

        public void FixedUpdate()
        {
            inputMgr.FixedUpdate();
            playerMgr.FixedUpdate();
            robotMgr.FixedUpdate();
            cameraMgr.FixedUpdate();
        }

        public void Update()
        {
            inputMgr.Update();
            playerMgr.Update();
            robotMgr.Update();
            cameraMgr.Update();
            courseMgr.Update();
        }
    }
}
