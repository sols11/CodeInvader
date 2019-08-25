/*----------------------------------------------------------------------------
Author:
    jiejianshu@corp.netease.com
Date:
    2019/08/19
Description:
    简介：编程用的棋盘
History:
----------------------------------------------------------------------------*/

using System.Collections.Generic;
using UnityEngine;

namespace ProjectScript
{
    public class Board
    {
        public BoardData data;

        public int highlightCellX;
        public int highlightCellY;

        public Board(GameObject gameObject)
        {
            data = gameObject.GetComponent<BoardData>();
            if (data == null)
            {
                Debug.LogError("Board缺少Data！");
                return;
            }
            data.Init();
        }

        private void GetCode()
        {

        }

        // public void Compile(List<ProgramUnit> code)
        // {
        //     int errorInd;
        //     List<List<List<int>>> program = data.programParser.parse(code, out errorInd);
        //     if (errorInd == -1)
        //     {
        //         RobotServiceRequest.SendProgram(program);
        //     }
        //     else
        //     {
        //         RaiseCompileError(errorInd);
        //     }
        // }

        private void RaiseCompileError(int errorInd)
        {

        }

        public void HighlightCell(Transform playerTransform)
        {
            int x, y;
            GetTargetInd(playerTransform, out x, out y);
        }

        public void PutDownBox(Transform playerTransform)
        {
            int x, y;
            GetTargetInd(playerTransform, out x, out y);
        }

        private void GetTargetInd(Transform playerTransform, out int x, out int y)
        {
            x = 1;
            y = 1;
        }

    }
}