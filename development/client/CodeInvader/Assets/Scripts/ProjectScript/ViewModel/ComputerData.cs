/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/14
Description:
    简介：电脑数据
    作用：挂载于GameObject
    使用：电脑有一个Trigger来检测玩家是否在可交互范围内，若在则触发UI按钮显示的事件
    补充：除此之外，并不是出现UI按钮就一定可以破解电脑，服务端会校验
History:
----------------------------------------------------------------------------*/

using System;
using System.Timers;
using UnityEngine;
using UnityEditor;
using SFramework;

namespace ProjectScript
{
    [RequireComponent(typeof(Collider))]
    public class ComputerData : MonoBehaviour
    {
        // 组件
        public Collider[] Colliders { get; private set; }
        public Transform DecodePos { get; private set; }        // 破解时角色需要处于的位置
        // 属性
        [HideInInspector] public int eid;
        public float needTime = 10;          // 破解需要的时间量
        private float crackTimer = 0;
        [HideInInspector] public bool completed = false;
        [HideInInspector] public bool beingDecoded = false;     // 正在被破解时其他人不可破解
        public float CrackTimer
        {
            get => crackTimer;
            set
            {
                //crackTimer = value >= needTime ? needTime : value; 超就超了，不需要限制
                crackTimer = value <= 0 ? 0 : value;
            }
        }

        public void Init()
        {
            Colliders = gameObject.GetComponents<Collider>();
            DecodePos = transform.Find("DecodePos");
        }

        // 这本来是行为，但由于行为属于Collider组件，故只得在Data中执行
        private void OnTriggerEnter(Collider other)
        {
            // 可以破解且是主玩家接触
            if (!completed && !beingDecoded && other.gameObject.CompareTag(SystemDefine.MAIN_PLAYER))
            {
                // 可以交互，交互的对象是本对象（需要发送要交互的对象）若InterActiveArgs参数的类型是是decode则可交互
                EventMgr.Instance.Invoke(ArgEvent.UiInteractState, this, new InteractiveArgs(UiOperativeType.Decode, true));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!completed && !beingDecoded && other.gameObject.CompareTag(SystemDefine.MAIN_PLAYER))
            {
                // 禁止交互
                EventMgr.Instance.Invoke(ArgEvent.UiInteractState, this, new InteractiveArgs(UiOperativeType.Decode, false));
            }
        }

    }
}