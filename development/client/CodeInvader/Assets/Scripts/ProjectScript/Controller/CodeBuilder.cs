/*----------------------------------------------------------------------------
Author:
    wuzelin@corp.netease.com
Date:
    2019/08/17
Description:
    简介: 编程环境
History:
----------------------------------------------------------------------------*/
using System.Collections.Generic;
using UnityEngine;
using SFramework;

namespace ProjectScript
{
    public class CodeBuilder
    {
        private ProgramParser programParser = new ProgramParser();

        public void Run(List<ProgramUnit> code)
        {
            int x;
            // List<List<List<int>>> program = programParser.parse(code, out x);
            // // foreach (var sentence in program)
            // // {
            // //     foreach (var clause in sentence)
            // //     {
            // //         foreach (var word in clause)
            // //         {
            // //             Debug.Log(word);
            // //         }
            // //         // Debug.Log("end of clause");
            // //     }
            // //     // Debug.Log("end of sentence");
            // // }
            // RobotServiceRequest.SendProgram(program);
        }

        // 硬编码的一条AI指令，只用于测试
        public List<ProgramUnit> HardCodeForTest()
        {
            List<ProgramUnit> code = new List<ProgramUnit>
            {
                new AIIf(), new HealthAt((int)AIOperator.LessEqual,1200), new MoveTowards(), new EnemyRobot(), new AINewLine()
            };
            return code;
        }

        #region Events

        #endregion

    }
}