/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/16
Description:
    简介：摇杆实现，此为各摇杆的Base基类
    原理：基于UGUI，主要是通过Pointer之类的事件实现
    使用：请使用Extend下的实例
History:
----------------------------------------------------------------------------*/

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using SFramework;

namespace ProjectScript
{
    public class Joystick : ViewBase, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        // 记录输入，受snap设置影响
        public float Horizontal => (snapX) ? SnapFloat(input.x, AxisOptions.Horizontal) : input.x;
        public float Vertical => (snapY) ? SnapFloat(input.y, AxisOptions.Vertical) : input.y;
        public Vector2 Direction => new Vector2(Horizontal, Vertical);

        public float HandleRange
        {
            get => handleRange;
            set => handleRange = Mathf.Abs(value);
        }

        public float DeadZone
        {
            get => deadZone;
            set => deadZone = Mathf.Abs(value);
        }

        public AxisOptions AxisOptions
        {
            get => axisOptions;
            set => axisOptions = value;
        }

        public bool SnapX
        {
            get => snapX;
            set => snapX = value;
        }

        public bool SnapY
        {
            get => snapY;
            set => snapY = value;
        }

        [SerializeField] private float handleRange = 1;
        [SerializeField] private float deadZone = 0.1f;
        [SerializeField] private AxisOptions axisOptions = AxisOptions.Both;
        [SerializeField] private bool snapX = false;
        [SerializeField] private bool snapY = false;

        [SerializeField] protected RectTransform background = null;
        [SerializeField] private RectTransform handle = null;
        private RectTransform baseRect = null;

        private Canvas canvas;
        private Camera cam;

        private Vector2 input = Vector2.zero;

        protected virtual void Start()
        {
            HandleRange = handleRange;
            DeadZone = deadZone;
            baseRect = GetComponent<RectTransform>();
            // 拿到Canvas和Camera
            GameObject canvasObj = GameMgr.Get.uiManager.CanvasGO;
            if (canvasObj)
                canvas = canvasObj.GetComponent<Canvas>();
            if (canvas == null)
                canvas = GetComponentInParent<Canvas>();
            if (canvas == null)
                Debug.LogError("The Joystick is not placed inside a canvas");
            else if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
                cam = canvas.worldCamera;   // ScreenSpace和WorldSpace都是用这个UiCamera
            // Init
            Vector2 center = new Vector2(0.5f, 0.5f);
            background.pivot = center;
            handle.anchorMin = center;
            handle.anchorMax = center;
            handle.pivot = center;
            handle.anchoredPosition = Vector2.zero;
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            //cam = null;
            //if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
            //    cam = canvas.worldCamera;   // ScreenSpace和WorldSpace都是用这个UiCamera
            // Calculate
            Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, background.position);
            Vector2 radius = background.sizeDelta / 2;
            // 将input的数据，通过屏幕坐标和输入半径等参数限制到[0,1]之间
            input = (eventData.position - position) / (radius * canvas.scaleFactor);
            FormatInput();
            // 限制到normalized避免总值超过1
            HandleInput(input.magnitude, input.normalized, radius, cam);
            handle.anchoredPosition = input * radius * handleRange;
        }

        protected virtual void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
        {
            if (magnitude > deadZone)
            {
                if (magnitude > 1)
                    input = normalised;
            }
            else
                input = Vector2.zero;
        }

        private void FormatInput()
        {
            if (axisOptions == AxisOptions.Horizontal)
                input = new Vector2(input.x, 0f);
            else if (axisOptions == AxisOptions.Vertical)
                input = new Vector2(0f, input.y);
        }

        private float SnapFloat(float value, AxisOptions snapAxis)
        {
            if (Math.Abs(value) < Mathf.Epsilon)
                return value;

            if (axisOptions == AxisOptions.Both)
            {
                float angle = Vector2.Angle(input, Vector2.up);
                if (snapAxis == AxisOptions.Horizontal)
                {
                    if (angle < 22.5f || angle > 157.5f)
                        return 0;
                    else
                        return (value > 0) ? 1 : -1;
                }
                else if (snapAxis == AxisOptions.Vertical)
                {
                    if (angle > 67.5f && angle < 112.5f)
                        return 0;
                    else
                        return (value > 0) ? 1 : -1;
                }

                return value;
            }
            else
            {
                if (value > 0)
                    return 1;
                if (value < 0)
                    return -1;
            }

            return 0;
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            input = Vector2.zero;
            handle.anchoredPosition = Vector2.zero;
        }

        protected Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
        {
            Vector2 localPoint = Vector2.zero;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(baseRect, screenPosition, cam, out localPoint))
            {
                Vector2 sizeDelta;
                Vector2 pivotOffset = baseRect.pivot * (sizeDelta = baseRect.sizeDelta);
                return localPoint - (background.anchorMax * sizeDelta) + pivotOffset;
            }

            return Vector2.zero;
        }
    }

    public enum AxisOptions
    {
        Both,
        Horizontal,
        Vertical
    }
}