/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/20
Description:
    简介：编程单元类型映射表
    使用：所有可放置于背包中的资源实体（目前包括机器人组件、AI编程模块）都会继承该类
History:
----------------------------------------------------------------------------*/
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

namespace ProjectScript
{
    public static class ProgramUnitMap
    {
        private static bool init = false;
        public static Dictionary<int, Type> unitType = new Dictionary<int, Type>();

        public static void SetUnitType()
        {
            if (init) return;
            // 第一层类型: 子类型
            var sonTypes = typeof(ProgramUnit).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(ProgramUnit)));
            foreach (var sonType in sonTypes)
            {
               var concreteSon = Activator.CreateInstance(sonType) as ProgramUnit;
               unitType.Add(concreteSon.typeId, sonType);
            }
            Debug.Log("初始化AI模块资源列表成功");
            init = true;
        }
    }
}
