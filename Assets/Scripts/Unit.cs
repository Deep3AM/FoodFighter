using UnityEngine;

[System.Serializable]
public class Stat
{
    private int hardness;
    private int sweet;
    private int sour;
    private int salty;
    private int spicy;
    private float bitter;
    public int Hardness { get { return hardness; } }
    public int Sweet { get { return sweet; } }
    public int Sour { get { return sour; } }
    public int Salty { get { return salty; } }
    public int Spicy { get { return spicy; } }
    public float Bitter { get { return bitter; } }

    public Stat(int _hardness, int _sweet, int _sour, int _salty, int _spicy, int _bitter)
    {
        hardness = _hardness;
        sweet = _sweet;
        sour = _sour;
        salty = _salty;
        spicy = _spicy;
        bitter = _bitter;
    }

    public void ChangeStat(string statName, int num)
    {
        switch (statName)
        {
            case "Hardness":
                hardness += num;
                break;
            case "Sweet":
                sweet += num;
                break;
            case "Sour":
                sour += num;
                break;
            case "Salty":
                salty += num;
                break;
            case "Spicy":
                spicy += num;
                break;
            case "Bitter":
                bitter += num;
                break;
            default:
                Debug.Log("Invaild Value");
                break;
        }
    }

    public void HPZero()
    {
        hardness = 0;
    }
}
[System.Serializable]
public class Unit
{
    public System.EventHandler onDieEvent;
    private string unitName;
    private Stat unitStat;
    private BaseSkill firstAttack;
    private BaseSkill secondAttack;
    private BaseSkill thirdAttack;
    private BaseSkill fourthAttack;

    public string UnitName { get { return unitName; } }
    public Stat UnitStat { get { return unitStat; } }

    public Unit(string enemyName, string mapInformation)
    {
        unitName = enemyName;
        UnitBaseInformation unitBaseInformation = BaseInformationReader.Instance.EnemyUnitBaseInformations[enemyName];
        unitStat = new Stat(unitBaseInformation.BaseHardness,
    unitBaseInformation.BaseSweet,
    unitBaseInformation.BaseSour,
    unitBaseInformation.BaseSalty,
    unitBaseInformation.BaseSpicy,
    unitBaseInformation.BaseBitter);

        firstAttack = (BaseSkill)Resources.Load("Skills" + "/" + unitBaseInformation.FirstAttack);
        secondAttack = (BaseSkill)Resources.Load("Skills" + "/" + unitBaseInformation.SecondAttack); ;
        thirdAttack = (BaseSkill)Resources.Load("Skills" + "/" + unitBaseInformation.ThirdAttack);
        fourthAttack = (BaseSkill)Resources.Load("Skills" + "/" + unitBaseInformation.FourthAttack);
    }

    public Unit(string _unitName)
    {
        unitName = _unitName;
        UnitBaseInformation unitBaseInformation = BaseInformationReader.Instance.UnitBaseInformations[_unitName];
        UnitData unitData = UserData.Instance.UnitDatas[unitName];
        unitStat = new Stat(unitBaseInformation.BaseHardness + unitData.hardnessLevel,
            unitBaseInformation.BaseSweet + unitData.sweetLevel,
            unitBaseInformation.BaseSour + unitData.sourLevel,
            unitBaseInformation.BaseSalty + unitData.saltyLevel,
            unitBaseInformation.BaseSpicy + unitData.spicyLevel,
            unitBaseInformation.BaseBitter + unitData.bitterLevel);

        firstAttack = (BaseSkill)Resources.Load("Skills" + "/" + unitBaseInformation.FirstAttack);
        secondAttack = (BaseSkill)Resources.Load("Skills" + "/" + unitBaseInformation.SecondAttack); ;
        thirdAttack = (BaseSkill)Resources.Load("Skills" + "/" + unitBaseInformation.ThirdAttack);
        fourthAttack = (BaseSkill)Resources.Load("Skills" + "/" + unitBaseInformation.FourthAttack);
    }

    public int Attack(Unit enemy, int attackPhase)
    {
        if (attackPhase == 1)
        {
            firstAttack.SetValue(UnitStat);
            enemy.Damaged(this, firstAttack.SetValue(UnitStat));
            return firstAttack.SetValue(UnitStat);
        }
        else if (attackPhase == 2)
        {
            secondAttack.SetValue(UnitStat);
            enemy.Damaged(this, secondAttack.SetValue(UnitStat));
            return secondAttack.SetValue(UnitStat);
        }
        else if (attackPhase == 3)
        {
            thirdAttack.SetValue(UnitStat);
            enemy.Damaged(this, thirdAttack.SetValue(UnitStat));
            return thirdAttack.SetValue(UnitStat);
        }
        else
        {
            fourthAttack.SetValue(UnitStat);
            enemy.Damaged(this, fourthAttack.SetValue(UnitStat));
            return fourthAttack.SetValue(UnitStat);
        }

    }

    public void Damaged(Unit enemy, int damage)
    {
        UnitStat.ChangeStat("Hardness", -damage);
        if (UnitStat.Hardness <= 0)
        {
            UnitStat.HPZero();
            onDieEvent?.Invoke(this, System.EventArgs.Empty);
        }
    }
}
