/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/07
Description:
    简介：UI继承的基类
    作用：设置3个枚举的值
          提供4种生命周期状态供外界调用
    使用：
    补充：
History:
----------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SFramework
{
    public class ViewBase : MonoBehaviour
    {
        // 字段
        private UIFormType uiFormType = UIFormType.Normal;
        private UIFormShowMode uiFormShowMode = UIFormShowMode.Normal;
        private UIFormLucenyType uiFormLucencyType = UIFormLucenyType.Lucency;

        // 属性
        // 对UIMgr的引用将在生成该UI时赋值
        public UIManager UiManager { get; set; }
        public UIMaskMgr UiMaskMgr { get; set; }

        // UI窗体（位置）类型
        public UIFormType UIFormType { get { return uiFormType; }set { uiFormType = value; } }
        // UI窗体显示类型
        public UIFormShowMode UIFormShowMode { get { return uiFormShowMode; } set { uiFormShowMode = value; } }
        // UI窗体透明度类型
        public UIFormLucenyType UIFormLucencyType { get { return uiFormLucencyType; } set { uiFormLucencyType = value; } }

        public virtual void UpdateUI() { }

        #region  窗体的四种(生命周期)状态

        /// <summary>
        /// 显示状态
        /// </summary>
        public virtual void Display()
        {
            this.gameObject.SetActive(true);
            //设置模态窗体调用(必须是弹出窗体)
            if (UIFormType == UIFormType.PopUp)
            {
                if(UiMaskMgr!=null)
                    UiMaskMgr.SetMaskWindow(this.gameObject, UIFormLucencyType);
                else
                {
                    UiMaskMgr = GameMgr.Get.uiMaskMgr;
                    UiMaskMgr.SetMaskWindow(this.gameObject, UIFormLucencyType);
                    Debug.Log("UI未获取UI_MaskMgr，自动从主程序获取");
                }
            }
        }

        /// <summary>
        /// 隐藏状态
        /// </summary>
	    public virtual void Hiding()
        {
            this.gameObject.SetActive(false);
            //取消模态窗体调用
            if (UIFormType == UIFormType.PopUp)
            {
                if (UiMaskMgr != null)
                    UiMaskMgr.CancelMaskWindow();
                else
                {
                    UiMaskMgr = GameMgr.Get.uiMaskMgr;
                    UiMaskMgr.CancelMaskWindow();
                    Debug.Log("UI未获取UI_MaskMgr，自动从主程序获取");
                }
            }
        }

        /// <summary>
        /// 重新显示状态
        /// </summary>
	    public virtual void Redisplay()
        {
            this.gameObject.SetActive(true);
            //设置模态窗体调用(必须是弹出窗体)
            if (UiMaskMgr != null)
                UiMaskMgr.SetMaskWindow(this.gameObject, UIFormLucencyType);
            else
            {
                UiMaskMgr = GameMgr.Get.uiMaskMgr;
                UiMaskMgr.SetMaskWindow(this.gameObject, UIFormLucencyType);
                Debug.Log("UI未获取UI_MaskMgr，自动从主程序获取");
            }
        }

        /// <summary>
        /// 冻结状态
        /// </summary>
	    public virtual void Freeze()
        {
            this.gameObject.SetActive(true);
        }


        #endregion

        #region 封装子类常用的方法

        /// <summary>
        /// 打开UI窗体
        /// </summary>
        /// <param name="uiFormName"></param>
	    public void OpenUIForm(string uiFormName)
        {
            //如果没有引用到的话使用主程序调用
            if (UiManager != null)
                UiManager.ShowUI(uiFormName);
            else
                GameMgr.Get.uiManager.ShowUI(uiFormName);
        }

        /// <summary>
        /// 关闭当前UI窗体
        /// </summary>
	    public void CloseUIForm()
        {
            string strUIFromName = string.Empty;            //处理后的UIFrom 名称
            int intPosition = -1;

            strUIFromName = GetType().ToString();             //命名空间+类名
            intPosition = strUIFromName.IndexOf('.');
            if (intPosition != -1)
            {
                //剪切字符串中“.”之间的部分，也就是命名空间后面的部分
                strUIFromName = strUIFromName.Substring(intPosition + 1);
            }
            //最后得到的就是当前UI窗体名称
            if (UiManager != null)
                UiManager.CloseUI(strUIFromName);
            else
                GameMgr.Get.uiManager.CloseUI(strUIFromName);
        }

        #endregion
    }
}
