/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/19
Description:
    简介：网络协议分发回调方法基类
History:
----------------------------------------------------------------------------*/

namespace SFramework
{
    public abstract class BaseCallBack
    {
        public int ServiceID;
        private Dispatcher _dispatcher = Dispatcher.Instance;

        public BaseCallBack(int sid)
        {
            ServiceID = sid;
        }
        
        // 消息分发处理函数注册
        public virtual void RegisterCommand(int cid, Dispatcher.ServiceFunction function)
        {
            int protocolId = (ServiceID << 16) + cid;
            _dispatcher.Register(protocolId, function);
        }
   
        public virtual void UnregisterCommand(int cid)
        {
            int protocolId = (ServiceID << 16) + cid;
            _dispatcher.Unregister(protocolId);
        }

        // 注册过程的抽象函数
        public abstract void RegisterProcess();
        
        //TODO 提供批量取消注册的接口
        public virtual void UnregisterAllCommand()
        {
        }

    }
}

