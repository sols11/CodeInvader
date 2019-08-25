/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/11
Description:
    简介：相机的基类，主要用于CameraMgr管理
History:
----------------------------------------------------------------------------*/

namespace SFramework
{
    public class ICamera
    {
        public virtual void Awake() { }
        public virtual void Init() { }
        public virtual void Release() { }
        public virtual void FixedUpdate() { }
        public virtual void Update() { }
    }
}
