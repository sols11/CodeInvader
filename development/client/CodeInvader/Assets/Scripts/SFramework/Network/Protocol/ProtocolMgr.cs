/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/19
Description:
    简介：网络服务协议注册
    使用：Init()方法可以调用所有继承BaseResponse和BaseNotification的子类中的RegisterProcess方法，进行服务协议注册
History:
----------------------------------------------------------------------------*/

using System;
using System.Linq;
using UnityEngine;

namespace SFramework
{
    public class ProtocolMgr : Singleton<ProtocolMgr>
    {
        public void Init()
        {
            var responseService = typeof(BaseResponse).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(BaseResponse)));
            foreach (var service in responseService)
            {
                Debug.Log(service.FullName);

                BaseResponse obj = Activator.CreateInstance(service) as BaseResponse;

                obj.RegisterProcess();
            }

            var notificationService = typeof(BaseNotification).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(BaseNotification)));
            foreach (var service in notificationService)
            {
                Debug.Log(service.FullName);

                BaseNotification obj = Activator.CreateInstance(service) as BaseNotification;

                obj.RegisterProcess();
            }

            Debug.Log("服务协议检查完毕");
        }
    }
}
