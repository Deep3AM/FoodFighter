using Class;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private string unitName;
    private UnitStat unitStat;
    private int level;
    private int hpStat;
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
        level = unitStat.Level;
        hpStat = unitStat.SetUnitAttack();
        attackStat = unitStat.SetUnitAttack();
        defenseStat = unitStat.SetUnitDefense();
        accuracyStat = unitStat.SetUnitAccuracy();
        luckStat = unitStat.SetUnitLuck();
        speedStat = unitStat.SetUnitSpeed();
    }

    public void Attack(Unit enemy)
    {
        enemy.Damaged(this, attackBlock.Value);
    }

    public void Damaged(Unit enemy, int damage)
    {
        hpStat -= damage;
    }
}
