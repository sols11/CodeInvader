/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/15
Description:
    简介：AI模块：关键词编程模块
History:
----------------------------------------------------------------------------*/

using UnityEngine;
using SFramework;

namespace ProjectScript
{
    public class AIIf : AIKeyword
    {
        public AIIf() : base(0x1001)
        {
            aiId = 0;
            text = "if";
            name = "如果";
        }
    }

    public class AIElse : AIKeyword
    {
        public AIElse() : base(0x1002)
        {
            aiId = 1;
            text = "else";
            name = "否则";
        }
    }

    public class AIThen : AIKeyword
    {
        public AIThen() : base(0x1003)
        {
            aiId = 2;
            text = "then";
            name = "则";
        }
    }

    public class AINewLine : AIKeyword
    {
        public AINewLine() : base(0x1004)
        {
            aiId = 3;
            text = "newline";
            name = "换行";
        }
    }

    public class AIEnd : AIKeyword
    {
        public AIEnd() : base(0x1005)
        {
            aiId = 4;
            text = "EOF";
            name = "结束";
        }
    }

}