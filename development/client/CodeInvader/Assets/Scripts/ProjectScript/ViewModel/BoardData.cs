/*----------------------------------------------------------------------------
Author:
    jiejianshu@corp.netease.com
Date:
    2019/08/19
Description:
    简介：编程用的棋盘
    作用：挂载于GameObject
History:
----------------------------------------------------------------------------*/
using UnityEngine;
using SFramework;
using System.Collections.Generic;

namespace ProjectScript
{
    public class BoardData : MonoBehaviour
    {
        public float CellWidth
        {
            get
            {
                return firstCellBox.size.x;
            }
        }
        public float CellHeight
        {
            get
            {
                return firstCellBox.size.z;
            }
        }
        public int numCellsCol;
        public int numCellsRow;

        private BoxCollider firstCellBox;

        public ProgramUnit[,] programUnits;
        [HideInInspector] public int eid;

        public ProgramParser programParser;

        public void Init()
        {
            programParser = new ProgramParser();
            programUnits = new ProgramUnit[numCellsCol, numCellsRow];
        }
    }
}