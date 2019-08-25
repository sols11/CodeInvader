/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/11
Description:
    简介：登录UI
History:
----------------------------------------------------------------------------*/

using UnityEngine;
using UnityEngine.UI;
using SFramework;

namespace ProjectScript
{
    public class UILogin : ViewBase
    {
        public InputField inputUsername;
        public InputField inputPassword;
        public Button btnLogin;
        public Button btnRegister;

        private void Awake()
        {
            //定义本窗体的性质(默认数值，可以不写)
            base.UIFormType = UIFormType.Normal;
            base.UIFormShowMode = UIFormShowMode.HideOther;
            base.UIFormLucencyType = UIFormLucenyType.Lucency;
        }
        private void Start()
        {
            btnLogin.onClick.AddListener(OnLoginButton);
            btnRegister.onClick.AddListener(OnRegisterButton);
        }

        private void OnLoginButton()
        {
            // 用户名密码为空
            if (inputUsername.text == "" || inputPassword.text == "")
            {
                //msgInfo.text = "用户名密码不能为空!";
                return;
            }
            AccountServiceRequest.Login(inputUsername.text, inputPassword.text);
        }

        private void OnRegisterButton()
        {
            // 用户名密码为空
            if (inputUsername.text == "" || inputPassword.text == "")
            {
                //msgInfo.text = "用户名密码不能为空!";
                return;
            }
            AccountServiceRequest.Register(inputUsername.text, inputPassword.text);
        }

    }
}