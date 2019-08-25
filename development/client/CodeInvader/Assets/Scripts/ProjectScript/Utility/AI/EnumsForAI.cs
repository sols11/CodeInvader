/*----------------------------------------------------------------------------
Author:
    jiejianshu@corp.netease.com
Date:
    2019/08/17
Description:
History:
----------------------------------------------------------------------------*/

namespace ProjectScript
{
    public enum PhraseType
    {
        Keyword = 0,
        Verb,
        Noun,
        Adjective,
    }

    public enum KeywordType
    {
        Condition = 0,
        Action,
        WhileCondition,
        WhileAction,
        UntilCondition,
        UntilAction,
        UpperLevel,
    }

    public enum NounType
    {
        Self = 0,
        Waypoint,
        Player,
        Robot,
    }

    public enum RelativeSide
    {
        Friend = 0,
        Enemy,
    }

    public enum RobotType
    {
        Light = 0,
        Middle,
        Heavy,
        Fly,
        NotSet,
    }
    public enum ArmorType
    {
        Light = 0,
        Middle,
        Heavy,
    }

    public enum MoveType
    {
        Land = 0,
        Fly,
    }

    public enum ActionType
    {
        AttackLeft = 0,
        AttackRight,
        Attack,
        MoveTowards,
        SendSignal,
        StopSignal,
        Patrol,
        Suicide,
        Retreat,
        Still,
    }

    public enum AdjType
    {
        ValueProperty = 0,
        RangeProperty,
        SetProperty,
        BoolProperty,
        NullProperty,
        EnemyFlee,
        MostDist,
        ValueMost,
    }

    public enum ValuePropertyType
    {
        Health = 0,
        Armor,
        State
    }

    public enum AIOperator
    {
        LessEqual = 0,
        Equal,
        MoreEqual
    }

    public enum StatusType
    {
        Patrol = 0,
        Retreat,
        Attack,
    }

    public enum RangeSubjectType
    {
        Former = 0,
        Latter = 1,
    }

    public enum RangeType
    {
        Sight = 0,
        Near,
        Mid,
        Far,
        Closest,
        Farthest,
    }

    public enum SetPropertyType
    {
        Signal = 0,
    }

    public enum BoolPropertyType
    {
        Attacked = 0,
    }

    public enum NullPropertyType
    {

    }

    public enum SpecialPropertyType
    {
        EnemyFlee = 0,
    }

    public enum SpecialInt
    {
        CompareWithSelf = 63,
        CompareWithAll = 62,
        InvalidEid = 100,
        EidHasBeenSet = 101,
        This = 102,
        HasSome = 103,
    }

    public enum EidBase
    {
        Player = 3,
        FriendRobot = 4,
        Computer = 5,
        Item = 6,
        Waypoint = 7,
        EnemyRobot = 8,
    }

    public enum EntityData
    {
        Health = 0,
        Armor,
        State,
        RobotType,
        Signal,
        SightRange,
        NearRange,
        MidRange,
        FarRange,
        IsAttacked,
        AttackTarget,
        Position,
    }



    public enum ObjectType
    {
        NoObject = 0,
        OneObject,
        ManyObject,
    }

    public enum AIErrorType
    {
        NoError = 0,
        InvalidSentenceBeginToken,
        InvalidNoun,
        InvalidAdj,
        MoreThanOneReturnSingleAdj,
        UnexpectedEndWhenGettingEntity,
        WordsOtherThanNounAndAdjInNounPhrase,
        InvalidKeywordInCondition,
        InvalidCondition,
        InvalidAction,
        ThenWithoutCondition,
    }

}