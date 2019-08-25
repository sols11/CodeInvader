/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/15
Description:
    简介：AI模块：实体类编程模块
History:
----------------------------------------------------------------------------*/

using UnityEngine;
using SFramework;

namespace ProjectScript
{
    public class AISelf : AIEntity
    {
        public AISelf() : base(0x2001)
        {
            aiType = 1;
            aiId = 0;
            name = "自己";
        }
    }

    #region deprecated
    public class FriendPlayer : AIEntity
    {
        // public int index;
        public FriendPlayer() : base(0x2002)
        { }

        public FriendPlayer(int index = 0) : base(0x2002)
        {
            canClick = true;
            aiType = 1;
            aiId = 4;
            name = "友人";
        }
    }

    public class EnemyPlayer : AIEntity
    {
        // public int index = 0;
        public EnemyPlayer() : base(0x2003) { }

        public EnemyPlayer(int index = 0) : base(0x2003)
        {
            canClick = true;
            aiType = 1;
            aiId = 3;
            name = "敌人";
        }
    }

    public class FriendRobot : AIEntity
    {
        // public int index = 0;
        public ArmorType armorType = ArmorType.Light;
        public MoveType moveType = MoveType.Land;

        public FriendRobot() : base(0x2004) { }

        public FriendRobot(int index = 0) : base(0x2004)
        {
            canClick = true;
            aiType = 1;
            aiId = 2;
            name = "友机";
        }
    }

    public class EnemyRobot : AIEntity
    {
        // public int index = 0;
        public ArmorType armorType = ArmorType.Light;
        public MoveType moveType = MoveType.Land;

        public EnemyRobot() : base(0x2005) { }

        public EnemyRobot(int index = 0) : base(0x2005)
        {
            canClick = true;
            aiType = 1;
            aiId = 1;
            name = "敌机";
        }
    }
    #endregion

    public class AIWaypoint : AIEntity
    {
        public int index = 0;
        public AIWaypoint() : base(0x2006) { }

        public AIWaypoint(int index = 0) : base(0x2006)
        {
            canClick = true;
            aiType = 1;
            aiId = 5;
            this.index = index;
        }
    }

    public class AIPlayer : AIEntity
    {
        public RelativeSide side;
        public int index;

        public AIPlayer(int index = 0, RelativeSide side = RelativeSide.Friend) : base(0x2007)
        {
            this.nounType = NounType.Player;
            this.index = index;
            this.side = side;
        }
    }

    public class AIRobot : AIEntity
    {
        public RelativeSide side;
        public RobotType type;
    }
}