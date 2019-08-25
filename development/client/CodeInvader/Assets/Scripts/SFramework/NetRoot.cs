/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/15 18:03
Description:
    简介：网络连接接口
History:
    TODO:NetRoot是否有必要？offline是否应该写到netroot中？
----------------------------------------------------------------------------*/
using System;
using UnityEngine;

namespace SFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class NetRoot : MonoBehaviour
    {
        private static NetRoot instance;
        public static NetRoot Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<NetRoot>();

                    if (instance == null)
                        instance = new GameObject("GameLoop").AddComponent<NetRoot>();
                }

                return instance;
            }
        }

        void Start()
        {
            Application.runInBackground = true;
            NetMgr.Connect();
            ProtocolMgr.Instance.Init();
        }

        void Update()
        {
            NetMgr.Update();
        }
    }


}