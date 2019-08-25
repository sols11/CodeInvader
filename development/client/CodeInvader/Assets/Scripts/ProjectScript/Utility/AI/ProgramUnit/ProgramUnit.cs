/*----------------------------------------------------------------------------
Author:
    jiejianshu@corp.netease.com
Date:
    2019/08/16
Description:
History:
----------------------------------------------------------------------------*/

namespace ProjectScript
{
    public enum ProgramUnitType { Keyword, Entity, Status, Act }

    public class ProgramUnit
    {
        public int typeId { get; protected set; }
        public bool canClick = false;
        public int aiType;
        public int aiId;

        public string name;

        public ProgramUnit()
        {
            typeId = 0;
            name = "模块";
        }
        public ProgramUnit(int type)
        {
            typeId = type;
            name = "模块";
        }

    }

    public class AIKeyword : ProgramUnit
    {
        public string text;
        public AIKeyword() : base(0x1000)
        {
            aiType = 0;
            aiId = -1;
        }

        public AIKeyword(int type) : base(type)
        {
            aiType = 0;
            aiId = -1;
        }

    }

    public class AIEntity : ProgramUnit
    {
        public NounType nounType;
        public AIEntity() : base(0x2000)
        {
            typeId = 0x2000;
            nounType = NounType.Self;
        }
        public AIEntity(int type) : base(type)
        {
        }
    }

    public class AIStatus : ProgramUnit
    {
        public AdjType adjType;
        public AIStatus() : base(0x3000)
        {
        }
        public AIStatus(int type) : base(type)
        {
        }
    }

    public class AIAction : ProgramUnit
    {
        public ActionType actionType;
        public ObjectType objectType;
        public AIAction() : base(0x4000)
        {
        }
        public AIAction(int type) : base(type)
        {
        }
    }

}