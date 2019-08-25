/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/08
Description:
    简介：玩家数据
    作用：MVVM中的ViewModel，挂载于GameObject
    使用：
History:
----------------------------------------------------------------------------*/

using CommonStruct;
using UnityEngine;
using UnityEditor;
using SFramework;

namespace ProjectScript
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerData : MonoBehaviour
    {
        // 组件
        public Animator Animator { get; private set; }
        public Rigidbody Rgbd { get; private set; }
        public Collider Collider { get; private set; }
        public AudioSource AudioSource { get; private set; }
        // 字段
        [HideInInspector]public int eid;
        public float moveSpeed = 5;
        public float rotSpeed = 5;
        public int maxHp = 100;
        private int hp = 100;
        public NetState state = NetState.Living;
        public AudioClip[] voices;
        // 属性
        public int CurrentHp
        {
            get => hp;
            set
            {
                hp = value >= maxHp ? maxHp : value;
                if (hp <= 0)
                    hp = 0;
            }
        }

        public void Init()
        {
            Animator = gameObject.GetComponent<Animator>();
            Rgbd = gameObject.GetComponent<Rigidbody>();
            Collider = gameObject.GetComponent<Collider>();
            AudioSource = gameObject.GetComponent<AudioSource>();
            GameMgr.Get.audioMgr.AddSound(AudioSource);
        }

        public void Release()
        {
            GameMgr.Get.audioMgr.RemoveSound(AudioSource);
        }

        /// <summary>
        /// 播放语音（常用于动画帧事件）
        /// </summary>
        /// <param name="index">播放的语音在voice中的下标</param>
        public void PlayVoice(int index)
        {
            if (index >= voices.Length || index < 0)
                return;
            AudioSource.clip = voices[index];
            AudioSource.Play();
        }
    }
}
