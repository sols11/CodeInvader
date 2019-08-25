/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/21
Description:
    简介：用于接收指针输入，用于控制相机等
History:
----------------------------------------------------------------------------*/

using SFramework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ProjectScript
{
    public class UITouchInput : ViewBase, IDragHandler
    {
        private RectTransform rect;
        private FreeLookCam freeCam;

        // 不能放在Awake或Start，因为这无法保证执行顺序在CreateFreeLookCam之前
        public void Init()
        {
            rect = transform as RectTransform;
            EventMgr.Instance.Listen(SEvent.CreateFreeLookCam, this.EventCreateCamera);
        }

        private void OnDestroy()
        {
            EventMgr.Instance.Remove(SEvent.CreateFreeLookCam, this.EventCreateCamera);
        }

        public void OnDrag(PointerEventData pointer)
        {
            if (freeCam == null)
                return;
            var rect1 = rect.rect;
            float x = 100 * pointer.delta.x / rect1.width;
            float y = 100 * pointer.delta.y / rect1.height;
            // 如果只是根据分辨率限制大小的话就太小了，所以*100比例放大输入
            freeCam.HandleRotationMovement(x, y);
        }

        private void EventCreateCamera(object sender, object args)
        {
            if (sender is FreeLookCam cam)
            {
                freeCam = cam;
            }
        }
    }
}