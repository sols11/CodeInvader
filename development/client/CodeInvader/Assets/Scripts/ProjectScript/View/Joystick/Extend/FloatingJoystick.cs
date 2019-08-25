/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/16
Description:
    简介：最常用的悬浮摇杆
History:
----------------------------------------------------------------------------*/

using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectScript
{
    public class FloatingJoystick : Joystick
    {
        protected override void Start()
        {
            base.Start();
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            // 当指针按下时，出现摇杆（仅Rect范围内接收该事件）
            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            // 当指针提起时，关闭摇杆
            background.gameObject.SetActive(false);
            base.OnPointerUp(eventData);
        }
    }
}