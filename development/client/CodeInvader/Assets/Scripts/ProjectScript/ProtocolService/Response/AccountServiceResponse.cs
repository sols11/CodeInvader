/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date: 
    2019/8/15 16:28
Description:
    Response for Account Service Protocol Message
History:
----------------------------------------------------------------------------*/
using System;
using UnityEngine;
using SFramework;
using ProtocolMessage;
using AccountMessage;

namespace ProjectScript
{
    public class AccountServiceResponse : BaseResponse
    {
        public AccountServiceResponse() : base((int)proto_ids.AccountService)
        { }

        public override void RegisterProcess()
        {
            RegisterCommand((int)proto_ids.CidLogin, Login);
            RegisterCommand((int)proto_ids.CidRegister, Register);
        }

        public void Login(ProtoMessage message)
        {
            // 这句感觉没有简单多少， 只是把解析和show log 封装了一遍，可以按原来的写法写
            LoginResponse loginResponse = (LoginResponse)GetResponse(message, typeof(LoginResponse), "AccountService:Login");

            if (loginResponse.Result == 1)
            {
                // setting uid
                UserData.uid = loginResponse.Uid;
                UserData.isLogin = true;

                // switch to main scene
                GameLoop.Instance.sceneController.SetScene(SceneState.MainScene);
            }
            else
            {
                // TODO hints when login failure occurred
            }
        }

        public void Register(ProtoMessage message)
        {
            RegisterResponse registerResponse = (RegisterResponse)GetResponse(message, typeof(RegisterResponse), "AccountService:Register"); 
            // do other things
            registerResponse = RegisterResponse.Parser.ParseFrom(message.ProtoData);

        }

    }
}