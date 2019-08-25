/*----------------------------------------------------------------------------
Author:
    jiejianshu@corp.netease.com
Date:
    2019/08/17
Description:
History:
----------------------------------------------------------------------------*/

using AIMessage;
using PlayerMessage;
using SFramework;
using ProtocolMessage;
using proto_ids = AIMessage.proto_ids;


namespace ProjectScript
{
    public class RobotServiceResponse : BaseResponse
    {
        public RobotServiceResponse() : base((int)proto_ids.RobotService)
        { }

        public override void RegisterProcess()
        {
            //RegisterCommand((int)proto_ids.SendProgram, SendProgram);
        }
        public void SendProgram(ProtoMessage message)
        {

        }

        public void Move(ProtoMessage message)
        {
            RobotMoveResponse response =
                (RobotMoveResponse) GetResponse(message, typeof(RobotMoveResponse), "RobotService:Move");

            //GameMgr.Get.robotMgr.RobotMove(response.Eid, NetConverter.To(response.Pos), NetConverter.To(response.Rot));
        }

        public void Attack(ProtoMessage message)
        {
            RobotAttackResponse response =
                (RobotAttackResponse) GetResponse(message, typeof(RobotAttackResponse), "RobotService:Attack");

            GameMgr.Get.robotMgr.RobotAttack(response.Eid, true, response.Left);
        }

        public void TakeDamage(ProtoMessage message)
        {
            RobotTakeDamageResponse response =
                (RobotTakeDamageResponse)GetResponse(message, typeof(RobotTakeDamageResponse), "RobotService:TakeDamage");

            GameMgr.Get.robotMgr.RobotHurt(response.Eid, response.DamageInfo);
        }
    }
}