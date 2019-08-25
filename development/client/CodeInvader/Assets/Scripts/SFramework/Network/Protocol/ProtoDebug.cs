/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/19
Description:
    简介： 打印服务协议日志消息
History:
----------------------------------------------------------------------------*/
using System;
using UnityEngine;

namespace SFramework
{
    public enum ProtoMsgType{Request, Response, Notification}

    public class ProtoDebug:Singleton<ProtoDebug>
    {
        public void Log(ProtoMsgType type , string svcName, int proto_id)
        {
            string logMsg = "";
            switch (type)
            {
                case (ProtoMsgType.Request):
                    logMsg = "Request";
                    break;
                case (ProtoMsgType.Response):
                    logMsg = "Response";
                    break;
                case (ProtoMsgType.Notification):
                    logMsg = "Notification";
                    break;
            }
            Debug.Log(logMsg + $" {svcName}(protocol id: {proto_id:x8})");
        }

      public void LogError(ProtoMsgType type, string svcName, int proto_id, Exception e)
      {
            string logMsg = "";
            switch (type)
            {
                case (ProtoMsgType.Request):
                    logMsg = "Request";
                    break;
                case (ProtoMsgType.Response):
                    logMsg = "Response";
                    break;
                case (ProtoMsgType.Notification):
                    logMsg = "Notification";
                    break;
            }
            Debug.Log(logMsg + $" {svcName}(protocol id: {proto_id:x8}) Error:{e.Message}");
        }

    }
}