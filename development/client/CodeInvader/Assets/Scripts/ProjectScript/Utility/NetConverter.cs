/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/18
Description:
    简介：将网络传输用的NetStruct数据结构与Unity客户端的数据结构互转
    使用：使用To这个API即可，对于非Mono类型和NetStruct均可直接转换并返回相应类型
          对于Mono类型，若要将Net转为Mono类型，需要使用Convert这个API将Mono类型作为第二个参数传入，返回是否成功
History:
----------------------------------------------------------------------------*/

using System.Linq;
using CommonStruct;
using Google.Protobuf.Collections;
using UnityEngine;
using SFramework;

namespace ProjectScript
{
    public class NetConverter
    {
        #region 非Mono类型

        public static NetVector2 To(Vector2 local)
        {
            NetVector2 netStruct = new NetVector2()
            {
                X = local.x,
                Y = local.y
            };
            return netStruct;
        }

        public static Vector2 To(NetVector2 netStruct)
        {
            if (netStruct == null)
                return Vector2.zero;
            Vector2 local = new Vector2(netStruct.X, netStruct.Y);
            return local;
        }

        public static NetVector3 To(Vector3 local)
        {
            NetVector3 netStruct = new NetVector3()
            {
                X = local.x,
                Y = local.y,
                Z = local.z
            };
            return netStruct;
        }

        public static Vector3 To(NetVector3 netStruct)
        {
            if (netStruct == null)
                return Vector3.zero;
            Vector3 local = new Vector3(netStruct.X, netStruct.Y, netStruct.Z);
            return local;
        }

        public static NetQuaternion To(Quaternion local)
        {
            NetQuaternion netStruct = new NetQuaternion()
            {
                X = local.x,
                Y = local.y,
                Z = local.z,
                W = local.w
            };
            return netStruct;
        }

        public static Quaternion To(NetQuaternion netStruct)
        {
            if (netStruct == null)
                return Quaternion.identity;
            Quaternion local = new Quaternion(netStruct.X, netStruct.Y, netStruct.Z, netStruct.W);
            return local;
        }

        #endregion

        // 对于自定义的struct和enum类型，无需转换，一次定义，双端皆可用

        #region Mono类型

        public static NetTransform To(Transform local)
        {
            NetTransform netStruct = new NetTransform()
            {
                Position = To(local.position),
                Rotation = To(local.rotation)
            };
            return netStruct;
        }

        public static bool Convert(NetTransform src, Transform dest)
        {
            if (src == null || dest == null)
                return false;
            dest.position = To(src.Position);
            dest.rotation = To(src.Rotation);
            return true;
        }

        public static NetPlayerData To(PlayerData local)
        {
            NetPlayerData netStruct = new NetPlayerData()
            {
                Eid = local.eid,
                MoveSpeed = local.moveSpeed,
                RotSpeed = local.rotSpeed,
                MaxHp = local.maxHp,
                Hp = local.CurrentHp,
                State = local.state,
                Transform = To(local.transform)
            };
            return netStruct;
        }

        public static bool Convert(NetPlayerData src, PlayerData dest)
        {
            if (src == null || dest == null)
                return false;
            dest.eid = src.Eid;
            dest.moveSpeed = src.MoveSpeed;
            dest.rotSpeed = src.RotSpeed;
            dest.maxHp = src.MaxHp;
            dest.CurrentHp = src.Hp;
            dest.state = src.State;
            Convert(src.Transform, dest.transform);
            return true;
        }

        public static NetComputerData To(ComputerData local)
        {
            NetComputerData netStruct = new NetComputerData()
            {
                Eid = local.eid,
                NeedTime = local.needTime,
                CrackTimer = local.CrackTimer,
                Completed = local.completed,
                BeingDecoded = local.beingDecoded,
                Transform = To(local.transform),
            };
            return netStruct;
        }

        public static bool Convert(NetComputerData src, ComputerData dest)
        {
            if (src == null || dest == null)
                return false;
            dest.eid = src.Eid;
            dest.needTime = src.NeedTime;
            dest.CrackTimer = src.CrackTimer;
            dest.completed = src.Completed;
            dest.beingDecoded = src.BeingDecoded;
            Convert(src.Transform, dest.transform);
            return true;
        }

        public static NetRobotData To(RobotData local)
        {
            NetRobotData netStruct = new NetRobotData()
            {
                Eid = local.eid,
                MoveSpeed = local.moveSpeed,
                RotSpeed = local.rotSpeed,
                MaxHp = local.maxHp,
                Hp = local.CurrentHp,
                State = local.state,
                Armor = local.CurrentArmor,
                MaxArmor = local.maxArmor,
                ArmorRecoverDelay = local.armorRecoverDelay,
                ArmorRecoverSpeed = local.armorRecoverSpeed,
                FreeWeight = local.freeWeight,
                Transform = To(local.transform)
            };
            return netStruct;
        }

        public static bool Convert(NetRobotData src, RobotData dest)
        {
            if (src == null || dest == null)
                return false;
            dest.eid = src.Eid;
            dest.moveSpeed = src.MoveSpeed;
            dest.rotSpeed = src.RotSpeed;
            dest.maxHp = src.MaxHp;
            dest.CurrentHp = src.Hp;
            dest.state = src.State;
            dest.maxArmor = src.Armor;
            dest.CurrentArmor = src.Armor;
            dest.armorRecoverDelay = src.ArmorRecoverDelay;
            dest.armorRecoverSpeed = src.ArmorRecoverSpeed;
            dest.freeWeight = src.FreeWeight;
            Convert(src.Transform, dest.transform);
            return true;
        }

        public static NetHomeData To(HomeData local)
        {
            NetHomeData netStruct = new NetHomeData()
            {
                Eid = local.eid,
                MaxHp = local.maxHp,
                Hp = local.CurrentHp,
                Transform = To(local.transform)
            };
            return netStruct;
        }

        public static bool Convert(NetHomeData src, HomeData dest)
        {
            if (src == null || dest == null)
                return false;
            dest.eid = src.Eid;
            dest.maxHp = src.MaxHp;
            dest.CurrentHp = src.Hp;
            Convert(src.Transform, dest.transform);
            return true;
        }

      /*  public static NetAiItemData To(AIModuleData local)
        {
            NetAiItemData netStruct = new NetAiItemData()
            {
                BasicInfo = new NetBasicItem(){
                    Eid = local.eid,
                    TypeId = local.typeId,
                },
                Name = local.name,
                Info = local.info
            };
            return netStruct;
        }

        public static bool Convert(NetAiItemData src, AIModuleData dest)
        {
            // src或dest不能为空，且物体不能已被收集
            if (src == null || dest == null || src.BasicInfo.Collected)
                return false;
            dest.eid = src.BasicInfo.Eid;
            dest.typeId = src.BasicInfo.TypeId;
            Convert(src.BasicInfo.Transform, dest.transform);
            
            dest.name = src.Name;
            dest.info = src.Info;
            
            return true;
        }

        public static NetEquipData To(EquipData local)
        {
            NetEquipData netStruct = new NetEquipData()
            {
                BasicInfo = new NetBasicItem
                {
                    Eid = local.eid,
                    TypeId = local.typeId,
                    Collected = false,
                    Transform = To(local.transform)
                },
                Type = local.type,
                Name = local.name,
                Weight = local.weight,
                SetupTime = local.setupTime,
                AttackDuration = local.attackDuration,
                Attack = local.attack,
                RotSpeedReduce = local.rotSpeedReduce,
                WeaponType = local.weaponType,
                BreakDefense = local.breakDefense,
                SlowDown = local.slowDown,
                SlowDownSpeed = local.slowDownSpeed,
                BeatBack = local.beatBack,
                BeatBackForce = local.beatBackForce,
                MoveSpeed = local.moveSpeed,
                RotSpeed = local.rotSpeed,
                IsFly = local.isFly
            };
            foreach (var v in local.atkRange)
            {
                netStruct.AtkRange.Add(To(v));
            }

            return netStruct;
        }

        public static bool Convert(NetEquipData src, EquipData dest)
        {
            // 用于挂接武器
            if (src == null || dest == null)
                return false;
            dest.eid = src.BasicInfo.Eid;
            dest.typeId = src.BasicInfo.TypeId;

            dest.type = src.Type;
            dest.name = src.Name;
            dest.weight = src.Weight;
            dest.setupTime = src.SetupTime;
            dest.attackDuration = src.AttackDuration;
            dest.attack = src.Attack;
            dest.rotSpeedReduce = src.RotSpeedReduce;
            dest.weaponType = src.WeaponType;
            dest.breakDefense = src.BreakDefense;
            dest.slowDown = src.SlowDown;
            dest.slowDownSpeed = src.SlowDownSpeed;
            dest.beatBack = src.BeatBack;
            dest.beatBackForce = src.BeatBackForce;
            dest.moveSpeed = src.MoveSpeed;
            dest.rotSpeed = src.RotSpeed;
            dest.isFly = src.IsFly;
            return true;
        }*/

        #endregion
    }
}