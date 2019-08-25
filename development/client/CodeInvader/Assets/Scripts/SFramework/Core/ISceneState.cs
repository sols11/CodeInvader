/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/07
Description:
    简介：场景状态类的基类（接口类）
    作用：控制接口方法的初始化、更新、释放
    使用：场景状态类决定了这个场景中存在哪些对象，使用哪些功能，执行什么样的逻辑
History:
----------------------------------------------------------------------------*/

namespace SFramework
{
    /// <summary>
    /// 场景状态基类
    /// </summary>
    public abstract class ISceneState
    {
        public string SceneName { get; set; }               // UnityScene文件对应的名称，即需要加载的场景名称
        protected SceneController Controller { get; set; }  // 控制者
        protected GameMgr gameMgr;                          // 主程序

        public ISceneState(SceneController controller)
        {
            Controller = controller;
        }

        /// <summary>
        /// 初始化GameMgr，初始化场景，场景初始设置
        /// </summary>
        public virtual void StateBegin()
        {
            gameMgr = GameMgr.Get;
            gameMgr.Initialize();
        }

        /// <summary>
        /// 结束场景
        /// </summary>
        public virtual void StateEnd()
        {
            gameMgr.Release();
        }

        public virtual void FixedUpdate()
        {
            gameMgr.FixedUpdate();
        }

        public virtual void StateUpdate()
        {
            gameMgr.Update();
        }

        public override string ToString()
        {
            return SceneName;
        }
    }
}