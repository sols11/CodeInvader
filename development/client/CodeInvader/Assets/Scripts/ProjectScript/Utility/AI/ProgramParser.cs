/*----------------------------------------------------------------------------
Author:
    jiejianshu@corp.netease.com
Date:
    2019/08/16
Description:
History:
----------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectScript
{
    public enum ParserState
    {
        Init = 0,
        Waiting
    }
    public class ProgramParser
    {

        List<ProgramUnit> programUnits;

        public int indInUnits;

        public AIErrorType errorType;
        public ProgramParser()
        {

        }

        public List<List<List<List<int>>>> parse(List<ProgramUnit> programUnits)
        {
            List<List<List<List<int>>>> program = new List<List<List<List<int>>>>();
            this.programUnits = programUnits;
            this.indInUnits = 0;

            while (this.indInUnits < this.programUnits.Count)
            {
                List<List<List<int>>> sentence = GetNextSentence();
                if (errorType != AIErrorType.NoError)
                {
                    return null;
                }
                else if (sentence != null) // 过滤掉空句子，比如连续两个换行符
                {
                    program.Add(sentence);
                }
            }
            return program;
        }

        private List<List<List<int>>> GetNextSentence()
        {
            List<List<List<int>>> sentence = new List<List<List<int>>>();

            while (true)
            {
                ProgramUnit nextUnit = this.programUnits[this.indInUnits];
                if (nextUnit is AIKeyword)
                {
                    this.indInUnits++;
                    AIKeyword keyword = nextUnit as AIKeyword;
                    switch (keyword.text)
                    {
                        case ("newline"):
                        case ("EOF"):
                            if (sentence.Count == 0)
                            {
                                return null;
                            }
                            else
                            {
                                return sentence;
                            }
                        case ("if"):
                            while (true)
                            {
                                List<List<int>> condition = GetCondition();
                                if (this.errorType != AIErrorType.NoError)
                                {
                                    return null;
                                }
                                if (condition == null)
                                {
                                    break;
                                }
                                sentence.Add(condition);
                            }
                            break;
                        case ("then"):
                            if (sentence.Count == 0)
                            {
                                this.errorType = AIErrorType.ThenWithoutCondition;
                                return null;
                            }
                            else
                            {
                                while (true)
                                {
                                    List<List<int>> action = GetAction();
                                    if (this.errorType != AIErrorType.NoError)
                                    {
                                        return null;
                                    }
                                    if (action == null)
                                    {
                                        break;
                                    }
                                    sentence.Add(action);
                                }
                                break;
                            }
                    }
                }
                else if (nextUnit is AIAction)
                {
                    sentence.Add(GetAction());
                }
                else
                {
                    this.errorType = AIErrorType.InvalidSentenceBeginToken;
                    return null;
                }
            }
        }



        /// <summary>
        /// 动作除掉最开始的动作节点，后面的事情其实就是找一个名词，只是这个名词可能有各种修饰（形容词）。形容词有两种分类方法：
        /// 1、有一些形容词的返回值是一个集合，比如“血量<50”，符合条件的对象可能没有，可能只有一个，也可能有多个；有些形容词的返回值一定是一个值，比如“血量最高的”；
        /// 注意，一定要先处理返回集合的形容词，再处理返回单个值的形容词，所以返回集合的形容词可以直接加进result里，而返回单个值的形容词需要先存起来，直到确定不再有形容词时（也就是读到了需要的名词时）再加进result里。
        /// 2、距离相关的形容词会需要另一个对象（用来判断距离），我们用栈来处理这种情况。
        /// 另一点需要注意的是，由于服务端那边的设计，result里需要先出现名词节点，再出现修饰该名词的所有形容词。当出现距离相关的形容词时，直接在后面接对应另一个对象的所有描述，然后用一个专门的关键词（UpperLevel）显式出栈回到上一级。
        /// UpperLevel关键词是为了服务端的解析，要不然服务端不能确定某个形容词修饰的是哪个对象。
        /// 所以先建一个带一个随便什么对象的result，每次读到返回集合的形容词直接加进去，读到返回单例的形容词存起来，读到与距离有关的形容词递归调用本方法。
        /// 读到需要的名词后，从stack里pop出它的返回单个值的形容词加到result的最后，再把名词节点放到result的最前面（所以一开始建的时候要有一个占位的空对象）
        /// UpperLevel关键词由调用者加（因为第一层是不用的）
        /// /// 我们现在认为语法上只能有一个单例形容词修饰一个对象，所以对应的list应该最多有一个元素
        /// </summary>
        /// <returns></returns>
        private List<List<int>> GetModifiedEntity()
        {
            List<List<int>> result = new List<List<int>> { new List<int>() };
            List<List<int>> returnSingle = new List<List<int>>();
            int returnSingleCount = 0;
            List<List<int>> subResult = new List<List<int>>();

            List<int> phrase = new List<int>();

            ProgramUnit unit;

            while (this.indInUnits < this.programUnits.Count)
            {
                subResult.Clear();
                unit = this.programUnits[this.indInUnits++];
                if (unit is AIEntity)
                {
                    List<int> entity = GetEntity((AIEntity)unit);
                    if (this.errorType != AIErrorType.NoError)
                    {
                        return null;
                    }
                    result[0] = entity;
                    if (returnSingle.Count > 0)
                    {
                        result.AddRange(returnSingle);
                    }
                    return result;
                }
                else if (unit is AIStatus)
                {
                    AIStatus adjective = (AIStatus)unit;

                    // 先得到对应的phrase
                    phrase = GetAdj(adjective);
                    if (this.errorType != AIErrorType.NoError)
                    {
                        return null;
                    }
                    if (adjective.adjType == AdjType.RangeProperty) // 以后也可能会有最值条件，所以先写成这样
                    {
                        subResult = GetModifiedEntity();
                        if (this.errorType != AIErrorType.NoError)
                        {
                            return null;
                        }
                    }

                    // 根据是不是最值决定直接加进去还是存起来
                    if (adjective.adjType == AdjType.ValueMost || adjective.adjType == AdjType.MostDist)
                    {
                        if (returnSingleCount > 0)
                        {
                            this.errorType = AIErrorType.MoreThanOneReturnSingleAdj;
                            return null;
                        }
                        returnSingleCount++;
                        returnSingle.Add(phrase);
                        if (subResult.Count > 0)
                        {
                            returnSingle.AddRange(subResult);
                            // 有意留下这一句并注释掉，因为目前最值条件只能有一个，所以这个条件一定在最后，所以就没有必要加标识符了
                            // result.Add(new List<int> { (int)PhraseType.Keyword, (int)KeywordType.UpperLevel });
                        }
                    }
                    else
                    {
                        result.Add(phrase);
                        if (subResult.Count > 0)
                        {
                            returnSingle.AddRange(subResult);
                            result.Add(new List<int> { (int)PhraseType.Keyword, (int)KeywordType.UpperLevel });
                        }
                    }
                }
                else
                {
                    this.errorType = AIErrorType.WordsOtherThanNounAndAdjInNounPhrase;
                    return null;
                }
            }
            this.errorType = AIErrorType.UnexpectedEndWhenGettingEntity;
            return null;
        }

        private List<int> GetAdj(AIStatus adjective)
        {
            List<int> phrase = new List<int> { (int)PhraseType.Adjective, (int)adjective.adjType, };
            switch (adjective.adjType)
            {
                case (AdjType.ValueProperty):
                    AIValueProperty valueProperty = (AIValueProperty)adjective;
                    phrase.Add((int)ConstantHolder.ValueTypeToEntitiData[valueProperty.type]);
                    phrase.Add((int)valueProperty.aiOperator);
                    phrase.Add(valueProperty.value);
                    break;
                case (AdjType.SetProperty):
                    AISetProperty setProperty = (AISetProperty)adjective;
                    phrase.Add((int)setProperty.setProperty);
                    phrase.Add(setProperty.value);
                    break;
                case (AdjType.BoolProperty):
                    AIBoolProperty boolProperty = (AIBoolProperty)adjective;
                    phrase.Add((int)boolProperty.boolProperty);
                    break;
                case (AdjType.NullProperty):
                    AINullProperty nullProperty = (AINullProperty)adjective;
                    phrase.Add((int)nullProperty.nullProperty);
                    break;
                case (AdjType.EnemyFlee):
                    break;
                case (AdjType.MostDist):
                    AIMostDist mostDist = (AIMostDist)adjective;
                    phrase.Add((int)mostDist.aiOperator);
                    break;
                case (AdjType.ValueMost):
                    AIValueMost valueMost = (AIValueMost)adjective;
                    phrase.Add((int)valueMost.type);
                    phrase.Add((int)valueMost.aiOperator);
                    break;
                case (AdjType.RangeProperty):
                    AIRangeProperty rangeProperty = (AIRangeProperty)adjective;
                    phrase.Add((int)rangeProperty.subjectType);
                    phrase.Add((int)rangeProperty.rangeType);
                    break;
                default:
                    this.errorType = AIErrorType.InvalidAdj;
                    return null;
            }
            return phrase;
        }

        private List<int> GetEntity(AIEntity subjective)
        {
            List<int> phrase = new List<int> { (int)PhraseType.Noun, (int)subjective.nounType };
            switch (subjective.nounType)
            {
                case (NounType.Waypoint):
                    AIWaypoint waypoint = (AIWaypoint)subjective;
                    phrase.Add((int)waypoint.index);
                    break;
                case (NounType.Player):
                    AIPlayer player = (AIPlayer)subjective;
                    phrase.Add((int)player.side);
                    phrase.Add((int)player.index);
                    break;
                case (NounType.Robot):
                    AIRobot robot = (AIRobot)subjective;
                    phrase.Add((int)robot.side);
                    if (robot.type != RobotType.NotSet)
                    {
                        phrase.Add((int)robot.type);
                    }
                    break;
                case (NounType.Self):
                    break;
                default:
                    this.errorType = AIErrorType.InvalidNoun;
                    return null;
            }
            return phrase;
        }

        private List<List<int>> GetAction()
        {
            // 和条件一样，先检查是不是没有动作了，可能需要返回null
            // 动作后可以newline，可以eof，可以until
            ProgramUnit unit = this.programUnits[this.indInUnits];
            if (unit is AIKeyword)
            {
                // 允许if中换行提供了逻辑非的实现方法
                if (unit is AIEnd || unit is AINewLine)
                {
                    return null;
                }
                else
                {
                    this.errorType = AIErrorType.InvalidKeywordInCondition;
                    return null;
                }
            }
            else if (unit is AIAction)
            {
                AIAction action = this.programUnits[this.indInUnits++] as AIAction;
                List<List<int>> clause = new List<List<int>> {
                new List<int> { (int)PhraseType.Keyword, (int)KeywordType.Action },
                new List<int> { (int)PhraseType.Verb, (int)action.actionType }
                };

                List<List<int>> objectPhrases = new List<List<int>>();

                if (action.objectType == ObjectType.NoObject)
                {
                    return clause;
                }
                else if (action.objectType == ObjectType.OneObject)
                {
                    objectPhrases = GetModifiedEntity();
                    if (this.errorType != AIErrorType.NoError)
                    {
                        return null;
                    }
                    clause.AddRange(objectPhrases);
                    return clause;
                }
                else
                {
                    // 合法的接在一个动作后面的东西只有另一个动作、newline、eof、until（暂时还没有），读到这几个的时候跳出while，否则GetModifiedEntity，报错也在里面报
                    while (!(programUnits[indInUnits] is AINewLine || programUnits[indInUnits] is AIEnd || programUnits[indInUnits] is AIAction))
                    {
                        objectPhrases = GetModifiedEntity();
                        if (this.errorType != AIErrorType.NoError)
                        {
                            return null;
                        }
                        clause.AddRange(objectPhrases);
                    }
                    return clause;
                }
            }
            else
            {
                this.errorType = AIErrorType.InvalidAction;
                return null;
            }
        }

        /// <summary>
        /// GetSentence会循环调用GetCondition直到出错或者返回null为止。所以预示着条件结束的情况都应该返回null。注意then和newline这样的关键字要留给上一级用来判断。
        /// 语句可以是if 对象1 条件1 条件2 对象2 条件3 条件4 then/newline，所以GetCondition本身还要有一个循环调用。
        /// </summary>
        /// <returns></returns>
        private List<List<int>> GetCondition()
        {
            List<List<int>> clause = new List<List<int>>();
            List<int> phrase = new List<int> { (int)PhraseType.Keyword, (int)KeywordType.Condition };
            clause.Add(phrase);

            List<List<int>> returnSingle = new List<List<int>>();
            int returnSingleCount = 0;
            List<List<int>> subResult = new List<List<int>>();
            // 先检查条件是不是已经结束了
            ProgramUnit unit = this.programUnits[this.indInUnits];
            if (unit is AIKeyword)
            {
                // 允许if中换行提供了逻辑非的实现方法
                if (unit is AIThen || unit is AINewLine)
                {
                    return null;
                }
                else
                {
                    this.errorType = AIErrorType.InvalidKeywordInCondition;
                    return null;
                }
            }

            // 先检查有没有指定条件的主语，有的话解析，没有的话添加一个Self，不过，后面应该是形容词，不然要报错。检查需要放在这里，因为完全可以只有一个条件，调用完第一次之后就不一定是形容词了
            else if (unit is AIEntity)
            {
                phrase = GetEntity((AIEntity)unit);
                if (this.errorType != AIErrorType.NoError)
                {
                    return null;
                }
                clause.Add(phrase);
                this.indInUnits++;
                if (!(this.programUnits[this.indInUnits] is AIStatus))
                {
                    this.errorType = AIErrorType.InvalidCondition;
                    return null;
                }
            }
            else if (unit is AIStatus)
            {
                clause.Add(new List<int> { (int)PhraseType.Noun, (int)NounType.Self });
            }
            else
            {
                this.errorType = AIErrorType.InvalidCondition;
                return null;
            }

            // 开始不断解析条件
            while (this.indInUnits < this.programUnits.Count)
            {
                unit = this.programUnits[this.indInUnits];
                if (unit is AIStatus)
                {
                    AIStatus adjective = (AIStatus)unit;
                    subResult.Clear();

                    // 先得到对应的phrase
                    this.indInUnits++;
                    phrase = GetAdj(adjective);
                    if (this.errorType != AIErrorType.NoError)
                    {
                        return null;
                    }
                    if (adjective.adjType == AdjType.RangeProperty) // 以后也可能会有最值条件，所以先写成这样
                    {
                        subResult = GetModifiedEntity();
                        if (this.errorType != AIErrorType.NoError)
                        {
                            return null;
                        }
                    }

                    // 根据是不是最值决定直接加进去还是存起来
                    if (adjective.adjType == AdjType.ValueMost || adjective.adjType == AdjType.MostDist)
                    {
                        if (returnSingleCount > 0)
                        {
                            this.errorType = AIErrorType.MoreThanOneReturnSingleAdj;
                            return null;
                        }
                        returnSingleCount++;
                        returnSingle.Add(phrase);
                        if (subResult.Count > 0)
                        {
                            returnSingle.AddRange(subResult);
                            // 有意留下这一句并注释掉，因为目前最值条件只能有一个，所以这个条件一定在最后，所以就没有必要加标识符了
                            // result.Add(new List<int> { (int)PhraseType.Keyword, (int)KeywordType.UpperLevel });
                        }
                    }
                    else
                    {
                        clause.Add(phrase);
                        if (subResult.Count > 0)
                        {
                            clause.AddRange(subResult);
                            clause.Add(new List<int> { (int)PhraseType.Keyword, (int)KeywordType.UpperLevel });
                        }
                    }
                }
                else
                {
                    return clause;
                }
            }
            this.errorType = AIErrorType.InvalidKeywordInCondition;
            return null;
        }
    }
}