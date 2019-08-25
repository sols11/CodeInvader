/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/07
Description:
    简介：协程控制系统
    作用：让不继承Monobehavior的物体也能够使用协程
    使用：CoroutineMgr.Instance.方法
    补充：单例模式。
History:
----------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework
{
    /// <summary>
    /// 协程管理器
    /// </summary>
    public class CoroutineMgr : MonoBehaviour
    {
        private static CoroutineMgr instance;

        public static CoroutineMgr Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<CoroutineMgr>();

                    if (instance == null)
                        instance = new GameObject("CoroutineMgr").AddComponent<CoroutineMgr>();
                }
                return instance;
            }
        }

        void Awake()
        {
            if (instance == null)
                instance = GetComponent<CoroutineMgr>();
            else if (instance != GetComponent<CoroutineMgr>())
            {
                Debug.LogWarningFormat("There is more than one {0} in the scene，auto inactive the copy one.", typeof(CoroutineMgr).ToString());
                gameObject.SetActive(false);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }

        // 其实这里不封装也能调用，因为继承了
        public new Coroutine StartCoroutine(IEnumerator routine)
        {
            return base.StartCoroutine(routine);
        }

        public new void StopCoroutine(IEnumerator routine)
        {
            base.StopCoroutine(routine);
        }

        public new void StopAllCoroutines()
        {
            base.StopAllCoroutines();
        }

        public new void StopCoroutine(Coroutine routine)
        {
            base.StopCoroutine(routine);
        }
    }
}