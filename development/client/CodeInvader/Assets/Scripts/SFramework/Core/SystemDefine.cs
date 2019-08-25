/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/07
Description:
    简介：系统全局变量定义文件
    作用：定义系统的全局变量，在本文件保存除UI外所有全局公共枚举。UI相关的全局变量放在Common.cs文件中
    使用：可以直接为契合项目而修改本文件，设置你需要的全局变量（包括枚举类型）
    补充：UI的一部分常量在Common中定义
History:
----------------------------------------------------------------------------*/

namespace SFramework
{
    /// <summary>
    /// 系统全局变量/常量设置
    /// </summary>
    public static class SystemDefine
    {
        // InputMgr
        public static readonly string Horizontal = "Horizontal";
        public static readonly string Vertical = "Vertical";
        public static readonly string Fire1 = "Fire1";
        public static readonly string Fire2 = "Fire2";
        public static readonly string Fire3 = "Fire3";
        public static readonly string Jump = "Jump";
        public static readonly string Submit = "Submit";
        public static readonly string Concel = "Concel";
        // Tags
        public static readonly string MAIN_CAMERA = "MainCamera";
        public static readonly string PLAYER = "Player";
        public static readonly string ENVIRONMENT = "Environment";
        public static readonly string UI_CAMERA = "UICamera";
        public static readonly string MAIN_PLAYER = "MainPlayer";
    }

    public class SettingData
    {
        // 因为Litjson不能存float，所以用int放大100倍
        public int MusicVolume { get; set; }
        public int SoundVolume { get; set; }

        public SettingData()
        {
            MusicVolume = 100;
            SoundVolume = 100;
        }
    }

    #region 全局枚举常量
    public enum ObjectLayer
    {
        Default = 0,
        TransparentFX = 1,
        IgnoreRaycast = 2,
        BuiltinLayer3,
        Water = 4,
        UI = 5,
        BuiltinLayer6,
        BuiltinLayer7,
        Ground = 8,
        Player = 9,
        Robot = 10,
        Enemy = 11,
        Weapon = 12,
        Bullet = 13,
        Without = 14,
        Wall = 15,
        PostProcessing = 16,
    }

    /// <summary>
    /// 使用UnityEvent的事件
    /// </summary>
    public enum UEvent
    {
    }

    /// <summary>
    /// 使用SFrameEvent的事件，带(object sender, object args)参数，推荐使用
    /// </summary>
    public enum SEvent
    {
        CreateFreeLookCam,
        PlayerDecodeState,  // 玩家是否在Decoding
        OnJoystickDrag,

        // 房间系统相关事件
        EnterRoom,
        ExitRoom,
        StarGame,
        GetRooms,
        GetRoomByRid,
        SelectRoom,

        // 操作模块编程事件
        Place, // 放置资源
        // 玩家操作背包事件
        PlayerPick,     // 放入资源
        PlayerTakeOut,  // 取出资源
        // 背包UI事件
        ReadItems,
    }

    /// <summary>
    /// 使用标准委托的事件（经测试在绑定多个Listener时有无法预估的错误，慎用！）
    /// </summary>
    public enum ArgEvent
    {
        CreatePlayer,
        CreateFollowCam,
        CreateRobot,
        // Scene Interact
        UiInteractState,    // 交互UI是否高亮
        UiCollectState,     // 收集UI是否高亮
        Decoding,           // 正在Decoding时的数据变化
        Picking,            // 是否举起AIModule

        // UI Events

        // Battle Events
        RobotAttack,
        PlayerHurt,
    }

    public enum UpdateType
    {
        FixedUpdate,
        Update,
    }

    public enum EquipIndex
    {
        Left,
        Right,
        Leg,
        Count   // Count并不表示具体的List<Equip>的下标，而是用于表示List<Equip>的长度
    }

    public enum ModuleType
    {
        Basic,
        Object,
        Adjective,  // 形容词
        State,
        Verb,       // 动词
        Timer,      // 动作计时器
    }

    #endregion
}
