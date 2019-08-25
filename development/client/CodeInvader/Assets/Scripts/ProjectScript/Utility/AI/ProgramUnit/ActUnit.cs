/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/15
Description:
    简介：AI模块：行动类编程模块
History:
----------------------------------------------------------------------------*/

using UnityEngine;
using SFramework;

namespace ProjectScript
{
    public class BeginSignal : AIAction
    {
        public int obj;
        public BeginSignal() : base(0x4001)
        {
        }

        public BeginSignal(int signal) : base(0x4001)
        {
            actionType = ActionType.SendSignal;
            typeId = 0x4001;
            objectType = ObjectType.NoObject;
            this.obj = signal;
            canClick = false;
            aiType = 3;
            aiId = 4;
        }
    }
    public class EndSignal : AIAction
    {
        public int obj;

        public EndSignal() : base(0x4002)
        { }

        public EndSignal(int signal) : base(0x4002)
        {
            actionType = ActionType.StopSignal;
            objectType = ObjectType.NoObject;
            this.obj = signal;
            canClick = false;
            aiType = 3;
            aiId = 5;
        }
    }

    public class AttackLeft : AIAction
    {
        public AttackLeft() : base(0x4003)
        {
            actionType = ActionType.AttackLeft;
            objectType = ObjectType.OneObject;
            aiType = 3;
            aiId = 0;
        }

    }

    public class AttackRight : AIAction
    {
        public AttackRight() : base(0x4004)
        {
            actionType = ActionType.AttackRight;
            objectType = ObjectType.OneObject;
            aiType = 3;
            aiId = 1;
        }

    }

    public class Attack : AIAction
    {
        public Attack() : base(0x4005)
        {
            actionType = ActionType.Attack;
            objectType = ObjectType.OneObject;
            aiType = 3;
            aiId = 2;
            name = "攻击";
        }
    }

    public class MoveTowards : AIAction
    {
        public MoveTowards() : base(0x4006)
        {
            actionType = ActionType.MoveTowards;
            objectType = ObjectType.OneObject;
            aiType = 3;
            aiId = 3;
            name = "移向";
        }
    }

    public class Patrol : AIAction
    {
        public Patrol() : base(0x4007)
        {
            actionType = ActionType.Patrol;
            objectType = ObjectType.ManyObject;
            aiType = 3;
            aiId = 6;
        }
    }

    public class Retreat : AIAction
    {
        public Retreat() : base(0x4008)
        {
            actionType = ActionType.Retreat;
            objectType = ObjectType.NoObject;
            aiType = 3;
            aiId = 8;
        }
    }

    public class Suicide : AIAction
    {
        public Suicide() : base(0x4009)
        {
            actionType = ActionType.Suicide;
            objectType = ObjectType.NoObject;
            aiType = 3;
            aiId = 7;
        }
    }

    public class NoAction : AIAction
    {
        public NoAction() : base(0x400a)
        {
            actionType = ActionType.Still;
            objectType = ObjectType.NoObject;
            aiType = 3;
            aiId = 9;
        }
    }
}