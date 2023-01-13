using System;

namespace Enum
{
    [System.Serializable]
    [Flags]
    public enum FoodType
    {
        None = 0,
        Rice = 1 << 0,
        Bread = 1 << 1,
        Noodle = 1 << 2,
        Meat = 1 << 3,
    };

    [System.Serializable]
    public enum MapNodeType
    {
        None,
        Monster,
        EpicMonster,
        Regain,
        Enchant,
        Boss
    }
}