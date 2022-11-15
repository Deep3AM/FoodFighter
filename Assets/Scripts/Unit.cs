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
    [SerializeField] private BaseSkill attackBlock;

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
        hpStat = baseUnitStat.BaseHP;
        attackStat = baseUnitStat.BaseAttack;
        defenseStat = baseUnitStat.BaseDefense;
        accuracyStat = baseUnitStat.BaseAccuracy;
        luckStat = baseUnitStat.BaseLuck;
        speedStat = baseUnitStat.BaseSpeed;
    }

    public void Attack(Unit enemy)
    {
        attackBlock.SetValue(attackStat);
        enemy.Damaged(this, attackBlock.Value);
    }

    public void Damaged(Unit enemy, int damage)
    {
        hpStat -= damage;
    }
}
