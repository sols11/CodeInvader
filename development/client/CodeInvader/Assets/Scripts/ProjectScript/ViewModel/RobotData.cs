/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/08
Description:
    简介：AI机器人数据
    作用：MVVM中的ViewModel，挂载于GameObject
    使用：我们可以把不同类型的机器人的基础数值设定好做成不同的prefab
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
    public class RobotData : MonoBehaviour
    {
        // 组件
        public Animator Animator { get; private set; }
        public Rigidbody Rgbd { get; private set; }
        public Collider Collider { get; private set; }
        public AudioSource[] AudioSources { get; private set; } // 一般有2个音源，分别播放语音和音效
        // 属性
        [HideInInspector] public int eid;
        public int maxHp = 1500;
        private int hp = 1500;
        public int maxArmor = 600;
        private int armor = 600;                  // 护甲值
        public float armorRecoverDelay = 2f;      // 护甲恢复延迟
        public float armorRecoverSpeed = 100;    // 护甲每秒恢复的数值
        public int freeWeight = 20;
        public NetState state = NetState.Living;
        public RobotType type = RobotType.Light;
        [Header("会受装备影响的基本属性")]
        public float moveSpeed = 3;
        public float rotSpeed = 2;
        // 语音+音效
        public AudioClip[] voices;
        public AudioClip[] sounds;
        [Header("骨骼结点")]
        public Transform[] rootBones;

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
        public int CurrentArmor
        {
            get => armor;
            set
            {
                armor = value >= maxArmor ? maxArmor : value;
                if (armor <= 0)
                    armor = 0;
            }
        }

        public void Init()
        {
            Animator = gameObject.GetComponent<Animator>();
            Rgbd = gameObject.GetComponent<Rigidbody>();
            Collider = gameObject.GetComponent<Collider>();
            AudioSources = gameObject.GetComponents<AudioSource>();
            foreach (var sound in AudioSources)
            {
                GameMgr.Get.audioMgr.AddSound(sound);
            }
        }

        public void Release()
        {
            foreach (var sound in AudioSources)
            {
                GameMgr.Get.audioMgr.RemoveSound(sound);
            }
        }

        /// <summary>
        /// 播放语音（常用于动画帧事件）
        /// </summary>
        /// <param name="index">播放的语音在voice中的下标</param>
        public void PlayVoice(int index)
        {
            if (index >= voices.Length || index < 0)
                return;
            AudioSources[0].clip = voices[index];
            AudioSources[0].Play();
        }

        /// <summary>
        /// 播放音效，使用不同的音源（常用于动画帧事件）
        /// </summary>
        /// <param name="index">播放的语音在sounds中的下标</param>
        public void PlaySound(int index)
        {
            if (index >= sounds.Length || index < 0)
                return;
            if (AudioSources.Length > 1)
            {
                AudioSources[1].clip = sounds[index];
                AudioSources[1].Play();
            }
        }
    }
}

