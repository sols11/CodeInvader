/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/21
Description:
    简介：资源实体控制类
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
    public class Item
    {
        public ItemType itemType { get; protected set; }
        public int itemId;

        #region 对外接口
        public virtual void Picked()
        {

        }
        #endregion
    }

}
