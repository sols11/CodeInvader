/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/14
Description:
    简介：基地
    使用：
History:
----------------------------------------------------------------------------*/

using SFramework;
using UnityEngine;
using UnityEditor;

namespace ProjectScript
{
    public class Home
    {
        public HomeData data;

        public Home(GameObject gameObject)
        {
            data = gameObject.GetComponent<HomeData>();
            if (data == null)
            {
                Debug.LogError("Home缺少Data！");
                return;
            }

            data.Init();
        }

        public void Hurt(int damage)
        {
            data.CurrentHp -= damage;
        }

        public void Dead()
        {
            // Game Over
        }
    }
}