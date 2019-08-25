/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/13
Description:
    简介：AI模块数据
    作用：挂载于GameObject
    使用：模块不会旋转，来源只有破解PC或敌人掉落
History:
----------------------------------------------------------------------------*/
using ItemStruct;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

namespace ProjectScript
{
    public class ItemData : MonoBehaviour
    {
        [HideInInspector] public int eid;
        [HideInInspector] public ItemType itemType;
        [HideInInspector] public int itemId;
        [HideInInspector] public bool collectable; // 物体是否可被拾取

        public void SetItemData(BaseItemData data)
        {
            eid = data.Eid;
            itemType = data.ItemType;
            itemId = data.ItemId;
            collectable = data.Collectable;
        }

        public void OnTriggerEnter(Collider other)
        {
            // 若物体可被拾取时触发
            if (collectable && other.gameObject.CompareTag(SystemDefine.MAIN_PLAYER))
            {
                Inventory.Instance.CollectableAdd(this);
            }

        }
        public void OnTriggerExit(Collider other)
        {
            // 若物体可被拾取时触发
            if (collectable && other.gameObject.CompareTag(SystemDefine.MAIN_PLAYER))
            {
                Inventory.Instance.CollectableRemove(this);
            }
        }
    }

}
