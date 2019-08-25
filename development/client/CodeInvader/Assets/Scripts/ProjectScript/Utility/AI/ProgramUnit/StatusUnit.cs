/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/15
Description:
    简介：AI模块：编程实体模块
History:
----------------------------------------------------------------------------*/

using UnityEngine;
using SFramework;

namespace ProjectScript
{
    public class AIValueProperty : AIStatus
    {
        public ValuePropertyType type;
        public AIOperator aiOperator;
        public int value;
        public AIValueProperty(ValuePropertyType type, AIOperator aiOperator, int value) : base()
        {
            this.adjType = AdjType.ValueProperty;
            this.type = type;
            this.aiOperator = aiOperator;
            this.value = value;
        }
    }

    public class AIRangeProperty : AIStatus
    {
        public RangeSubjectType subjectType;
        public RangeType rangeType;

        public AIRangeProperty(RangeSubjectType subjectType, RangeType rangeType) : base()
        {
            this.adjType = AdjType.RangeProperty;
            this.subjectType = subjectType;
            this.rangeType = rangeType;
        }
    }

    public class AISetProperty : AIStatus
    {
        public SetPropertyType setProperty;
        public int value;

        public AISetProperty(SetPropertyType setProperty, int value) : base()
        {
            this.adjType = AdjType.SetProperty;
            this.setProperty = setProperty;
            this.value = value;
        }
    }

    public class AIBoolProperty : AIStatus
    {
        public BoolPropertyType boolProperty;

        public AIBoolProperty(BoolPropertyType boolProperty) : base()
        {
            this.adjType = AdjType.BoolProperty;
            this.boolProperty = boolProperty;
        }
    }

    public class AINullProperty : AIStatus
    {
        public NullPropertyType nullProperty;

        public AINullProperty(NullPropertyType nullProperty) : base()
        {
            this.adjType = AdjType.NullProperty;
            this.nullProperty = nullProperty;
        }
    }

    public class AIEnemyFlee : AIStatus
    {
        public AIEnemyFlee() : base()
        {
            this.adjType = AdjType.EnemyFlee;
        }
    }

    public class AIMostDist : AIStatus
    {
        public AIOperator aiOperator;

        public AIMostDist(AIOperator aiOperator) : base()
        {
            this.adjType = AdjType.MostDist;
            this.aiOperator = aiOperator;
        }
    }

    public class AIValueMost : AIStatus
    {
        public ValuePropertyType type;
        public AIOperator aiOperator;

        public AIValueMost(ValuePropertyType type, AIOperator aiOperator) : base()
        {
            this.adjType = AdjType.ValueMost;
            this.type = type;
            this.aiOperator = aiOperator;
        }
    }
    #region deprecated
    public class HealthAt : AIStatus
    {
        public AIOperator aiOperator;
        public int value;

        public HealthAt() : base(0x3001) { }

        public HealthAt(int aiOperator, int value) : base(0x3001)
        {
            this.aiOperator = (AIOperator)aiOperator;
            this.value = value;
            canClick = true;
            aiType = 2;
            aiId = 1;
            name = "血<50%";
        }
    }

    public class ArmorAt : AIStatus
    {
        public AIOperator aiOperator;
        public int value;

        public ArmorAt() : base(0x3002) { }

        public ArmorAt(AIOperator aiOperator, int value) : base(0x3002)
        {
            this.aiOperator = aiOperator;
            this.value = value;
            canClick = true;
            aiType = 2;
            aiId = 2;
            name = "甲<50";
        }
    }

    public class ReceivedSignal : AIStatus
    {
        public int signal;

        public ReceivedSignal() : base(0x3003) { }

        public ReceivedSignal(int signal) : base(0x3003)
        {
            this.signal = signal;
            canClick = true;
            aiType = 2;
            aiId = 4;
        }
    }

    public class WithinRange : AIStatus
    {
        public RangeType type;

        public WithinRange() : base(0x3004) { }

        public WithinRange(RangeType type) : base(0x3004)
        {
            this.type = type;
            canClick = true;
            aiType = 2;
            aiId = 3;
            name = "在视野范围内";
        }
    }

    public class Attacking : AIStatus
    {
        public Attacking() : base(0x3005)
        {
            canClick = false;
            aiType = 2;
            aiId = 6;
        }
    }

    public class Patrolling : AIStatus
    {
        public int statusType;
        public Patrolling() : base(0x3006)
        {
            canClick = false;
            aiType = 2;
            aiId = 0;
            statusType = 0;
        }
    }

    public class Retreating : AIStatus
    {
        public int statusType;
        public Retreating() : base(0x3007)
        {
            canClick = false;
            aiType = 2;
            aiId = 0;
            statusType = 1;
        }
    }

    public class Attacked : AIStatus
    {
        public Attacked() : base(0x3008)
        {
            canClick = false;
            aiType = 2;
            aiId = 5;
        }
    }
    #endregion

}