/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/14
Description:
    简介：基地数据
    作用：挂载于GameObject
    使用：电脑有一个Trigger来检测玩家是否在可交互范围内，若在则触发UI按钮显示的事件
History:
----------------------------------------------------------------------------*/
using UnityEngine;
using UnityEditor;
using SFramework;

namespace ProjectScript
{
    [RequireComponent(typeof(Collider))]
    public class HomeData : MonoBehaviour
    {
        // 组件
        public Collider Collider { get; private set; }
        // 属性
        [HideInInspector] public int eid;
        public int maxHp = 10;
        private int hp = 10;
        public int CurrentHp
        {
            get { return hp; }
            set
            {
                hp = value >= maxHp ? maxHp : value;
                if (hp <= 0)
                    hp = 0;
            }
        }

        public void Init()
        {
            Collider = gameObject.GetComponent<Collider>();
        }

        // TODO：接触门后应该触发打开选择房间UI的事件
    }
}