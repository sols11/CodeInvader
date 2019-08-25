/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/23
Description:
    简介：机器人组装UI里的每一个格子（挂载在格子上）
    行为：显示，拖拽，放下
History:
----------------------------------------------------------------------------*/

using System;
using ItemStruct;
using SFramework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjectScript
{
    public class UIAssemblyGrid : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        public Image icon;
        public Image lockSquare;
        public UIAssembly uiParent;
        public EquipItemInfo equipInfo;
        private string path = @"Icons\";
        private bool isLocked = false;
        private Vector3 originPos;
        private Vector3 dragPos;         // 因为使用的是WorldPoint所以用3维

        private void Start()
        {
            // load icon from path
            
            // load data from equipId
        }

        public void Init(UIAssembly parent, EquipItemInfo info)
        {
            uiParent = parent;
            equipInfo = info;
            icon.sprite = GameMgr.Get.resourcesMgr.LoadResource<Sprite>(path + equipInfo.Name, false);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            return;
            originPos = icon.rectTransform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            return;
            // 移动位置，保持偏移
            RectTransformUtility.ScreenPointToWorldPointInRectangle(icon.rectTransform, eventData.position, eventData.pressEventCamera, out dragPos);
            icon.transform.position = dragPos;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            return;
            // if in trigger
            // else return origin pos
            icon.transform.position = originPos;
        }

        // 点击装备
        public void OnPointerClick(PointerEventData eventData)
        {
            if (isLocked)
            {
                if (uiParent && uiParent.UnEquip(this))
                {
                    isLocked = false;
                    lockSquare.gameObject.SetActive(isLocked);
                }
            }
            else
            {
                if (uiParent && uiParent.Equip(this))
                {
                    isLocked = true;
                    lockSquare.gameObject.SetActive(isLocked);
                }
            }
        }

        public void Unlock()
        {
            isLocked = false;
            lockSquare.gameObject.SetActive(isLocked);
        }
    }
}