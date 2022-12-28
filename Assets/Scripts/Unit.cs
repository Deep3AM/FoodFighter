using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public EventHandler onDieEvent;
    [SerializeField] private BaseUnitStat baseUnitStat;
    private string unitName;
    private int level;
    [SerializeField] private int hpStat;
    private int attackStat;
    private int defenseStat;
    private int accuracyStat;
    private int luckStat;
    private float speedStat;
    private BaseSkill firstAttack;
    private BaseSkill secondAttack;
    private BaseSkill thirdAttack;
    private BaseSkill fourthAttack;

    public string UnitName { get { return unitName; } }
    public int Level { get { return level; } }
    public int HPStat { get { return hpStat; } }
    public int AttackStat { get { return attackStat; } }
    public int DefenseStat { get { return defenseStat; } }
    public int AccuracyStat { get { return accuracyStat; } }
    public int LuckStat { get { return luckStat; } }
    public float SpeedStat { get { return speedStat; } }

    public void SetUnitStat()
    {
        level = 1;
        unitName = baseUnitStat.UnitName;
        hpStat = baseUnitStat.BaseHP;
        attackStat = baseUnitStat.BaseAttack;
        defenseStat = baseUnitStat.BaseDefense;
        accuracyStat = baseUnitStat.BaseAccuracy;
        luckStat = baseUnitStat.BaseLuck;
        speedStat = baseUnitStat.BaseSpeed;
        firstAttack = baseUnitStat.FirstAttack;
        secondAttack = baseUnitStat.SecondAttack;
        thirdAttack = baseUnitStat.ThirdAttack;
        fourthAttack = baseUnitStat.FourthAttack;
    }

    public int Attack(Unit enemy, int attackPhase)
    {
        if (attackPhase == 1)
        {
            firstAttack.SetValue(level);
            enemy.Damaged(this, firstAttack.SetValue(level));
            return firstAttack.SetValue(level);
        }
        else if (attackPhase == 2)
        {
            secondAttack.SetValue(level);
            enemy.Damaged(this, secondAttack.SetValue(level));
            return secondAttack.SetValue(level);
        }
        else if (attackPhase == 3)
        {
            thirdAttack.SetValue(level);
            enemy.Damaged(this, thirdAttack.SetValue(level));
            return thirdAttack.SetValue(level);
        }
        else
        {
            fourthAttack.SetValue(level);
            enemy.Damaged(this, fourthAttack.SetValue(level));
            return fourthAttack.SetValue(level);
        }

    }

    public void Damaged(Unit enemy, int damage)
    {
        hpStat -= damage;
        if (hpStat <= 0)
        {
            hpStat = 0;
            onDieEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
