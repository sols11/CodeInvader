/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/21
Description:
    简介：AI模块实体控制类
    使用：在背包中的AI模块数据，与场景中的实体无关
History:
----------------------------------------------------------------------------*/
using System;
using ItemStruct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectScript
{
    public class AIModule: Item
    {
        public AIModuleData data;
        public GameObject moduleObject;
        public AIModule(GameObject aiModule)
        {
            itemType = ItemType.Aimodule;
            // 缓冲数据
            data = aiModule.GetComponent<AIModuleData>();
            data.name = GetProgramUnit().name;
            // 缓冲对象
            moduleObject = aiModule;
        }

        #region 对外接口
        public void Picked()
        {

        }


        public ProgramUnit GetProgramUnit()
        {
            // 获取编程原子信息
            ProgramUnit result = Activator.CreateInstance(ProgramUnitMap.unitType[data.itemId]) as ProgramUnit;
            return result;
        }

        #endregion
    }

}
