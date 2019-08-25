/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/19
Description:
    Base CallBack of Protocol Service
History:
----------------------------------------------------------------------------*/

namespace SFramework
{
    public abstract class BaseNotification : BaseCallBack
    {
        public BaseNotification(int sid) : base(sid)
        {
        }



        // 消息分发处理函数注册
        public sealed override void RegisterCommand(int cid, Dispatcher.ServiceFunction function)
        {
            base.RegisterCommand(cid, function);
        }

        public sealed override void UnregisterCommand(int cid)
        {
            base.UnregisterCommand(cid);
        }

        // 注册过程的抽象函数
        public abstract override void RegisterProcess();

        //TODO 提供批量取消注册的接口
        /* public virtual void UnregisterAllCommand()
         {
         }*/

    }
}

