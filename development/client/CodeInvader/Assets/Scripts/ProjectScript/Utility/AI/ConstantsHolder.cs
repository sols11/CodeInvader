/*----------------------------------------------------------------------------
Author:
    jiejianshu@corp.netease.com
Date:
    2019/08/24
Description:
History:
----------------------------------------------------------------------------*/

using System.Collections.Generic;

namespace ProjectScript
{
    public static class ConstantHolder
    {
        public static Dictionary<RangeType, EntityData> RangeTypeToEntitiyData = new Dictionary<RangeType, EntityData>
        {
            { RangeType.Sight, EntityData.SightRange},
            { RangeType.Near, EntityData.NearRange},
            { RangeType.Mid, EntityData.MidRange},
            { RangeType.Far, EntityData.FarRange},
        };

        public static Dictionary<ValuePropertyType, EntityData> ValueTypeToEntitiData = new Dictionary<ValuePropertyType, EntityData> {
            {ValuePropertyType.Health, EntityData.Health},
            {ValuePropertyType.Armor, EntityData.Armor},
            {ValuePropertyType.State, EntityData.State},
        };
    }
}