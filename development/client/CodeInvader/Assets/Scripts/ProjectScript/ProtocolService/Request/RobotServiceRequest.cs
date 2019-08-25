/*----------------------------------------------------------------------------
Author:
    jiejianshu@corp.netease.com
Date:
    2019/08/17
Description:
History:
----------------------------------------------------------------------------*/
using ProtocolMessage;
using AIMessage;
using System.Collections.Generic;
using SFramework;

namespace ProjectScript
{
    public class RobotServiceRequest : BaseRequest
    {
        public static int SID = (int)proto_ids.RobotService;

        public static void SendProgram(List<List<List<int>>> programInput, int eid = (4 << 16) + 1)
        {
            List<SentenceObject> programObj = new List<SentenceObject>();

            GetBehaviorTreeRequest sendrequest = new GetBehaviorTreeRequest
            {
                Rid = 1,
                Eid = eid,
            };
            foreach (var sentenceInput in programInput)
            {
                SentenceObject sentenceObject = new SentenceObject();
                foreach (var clauseInput in sentenceInput)
                {
                    ClauseObject clauseObject = new ClauseObject { };
                    if (clauseInput[0] == (int)KeywordType.Condition)
                    {
                        clauseObject.ClauseType = (int)KeywordType.Condition;
                        clauseObject.Condition = new ConditionObject
                        {
                            SubjectType = clauseInput[1],
                            SubjectInd = clauseInput[2],
                            StatusType = clauseInput[3],
                        };
                        for (int i = 4; i < clauseInput.Count; i++)
                        {
                            clauseObject.Condition.Parameters.Add(clauseInput[i]);
                        }
                        // if (clauseInput.Count == 5)
                        // {
                        //     clauseObject.Condition = new ConditionObject
                        //     {
                        //         SubjectType = clauseInput[1],
                        //         SubjectInd = clauseInput[2],
                        //         StatusType = clauseInput[3],
                        //         Parameter = clauseInput[4]
                        //     };
                        // }
                        // else
                        // {
                        //     clauseObject.Condition = new ConditionObject
                        //     {
                        //         SubjectType = clauseInput[1],
                        //         SubjectInd = clauseInput[2],
                        //         StatusType = clauseInput[3],
                        //         ParameterList = new ParametersObject
                        //         {
                        //             Parameter1 = clauseInput[4],
                        //             Parameter2 = clauseInput[5]
                        //         }
                        //     };
                        // }
                    }
                    else
                    {
                        clauseObject.ClauseType = (int)KeywordType.Action;
                        clauseObject.Action = new ActionObject
                        {
                            ActionType = clauseInput[1],
                            TargetType = clauseInput[2],
                            TargetInd = clauseInput[3]
                        };
                    }
                    sentenceObject.Sentence.Add(clauseObject);
                }
                sendrequest.Program.Add(sentenceObject);
            }

            RequestSend(SID, (int)proto_ids.GetBehaviorTree, sendrequest, "SendAI");
        }

    }
}