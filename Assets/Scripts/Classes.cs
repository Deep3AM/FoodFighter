using UnityEngine;

namespace Class
{
    class UnitStat
    {
        private string unitName;
        private BaseUnitStat baseUnitStat;
        private float unitHPOffset;
        private float unitDefenseOffset;
        private float unitAttackOffset;
        private float unitAccuracyOffset;
        private float unitLuckOffset;
        private float unitSpeedOffset;
        private int unitTier;
        private int level;

        public UnitStat(BaseUnitStat baseUnitStat)
        {
            unitName = baseUnitStat.UnitName;
            unitTier = baseUnitStat.BaseTier;
            level = 1;//추후에 json에서 불러올 예정
        }

        public int Level { get { return level; } }
        public string UnitName { get { return unitName; } }
        public int SetUnitHP()
        {
            return Mathf.RoundToInt(baseUnitStat.BaseHP + unitHPOffset);
        }
        public int SetUnitAttack()
        {
            return Mathf.RoundToInt(baseUnitStat.BaseAttack + unitAttackOffset);
        }
        public int SetUnitDefense()
        {
            return Mathf.RoundToInt(baseUnitStat.BaseDefense + unitDefenseOffset);
        }
        public int SetUnitAccuracy()
        {
            return Mathf.RoundToInt(baseUnitStat.BaseAccuracy + unitAccuracyOffset);
        }
        public int SetUnitLuck()
        {
            return Mathf.RoundToInt(baseUnitStat.BaseLuck + unitLuckOffset);
        }
        public float SetUnitSpeed()
        {
            return baseUnitStat.BaseSpeed + unitSpeedOffset;
        }
        public void SetOffsets()
        {
            unitHPOffset = 0;
            unitAttackOffset = 0;
            unitDefenseOffset = 0;
            unitLuckOffset = 0;
            unitSpeedOffset = 0;
            unitAccuracyOffset = 0;
            //수식 넣을 예정
        }
        public void SetLevel(int level)
        {
            this.level = level;
            SetOffsets();
        }
    }


}
