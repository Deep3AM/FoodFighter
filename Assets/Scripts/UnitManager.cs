using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UnitManager : Singleton<UnitManager>
{
    [SerializeField] private List<Unit> units = new List<Unit>();
    [SerializeField] private List<Unit> home = new List<Unit>();
    [SerializeField] private List<Unit> away = new List<Unit>();
    public ConcurrentDictionary<Unit, UnitUI> unitAndUnitUI = new ConcurrentDictionary<Unit, UnitUI>();
    private UnitCanvas unitCanvas = null;
    private List<IEnumerator> turnSimulator = new List<IEnumerator>();

    public void SetBattle()
    {
        unitCanvas = FindObjectOfType<UnitCanvas>();
        foreach (Unit h in home)
        {
            h.SetUnitStat();
            units.Add(h);
            h.onDieEvent += OnDieEvent;
        }
        foreach (Unit a in away)
        {
            a.SetUnitStat();
            units.Add(a);
            a.onDieEvent += OnDieEvent;
        }
        unitCanvas.SetUnitUICanvas(home, away);
    }

    public void CalculateBattle(int attackPhase)
    {
        turnSimulator.Clear();
        units.Sort((Unit x, Unit y) => x.SpeedStat.CompareTo(y.SpeedStat));
        Random.InitState((int)DateTime.Now.Ticks);
        for (int i = 0; i < units.Count; i++)
        {
            Unit victim;
            int damage;
            if (home.Contains(units[i]))
            {
                victim = away[Random.Range(0, away.Count)];
                damage = units[i].Attack(victim, attackPhase);
            }
            else
            {
                victim = home[Random.Range(0, home.Count)];
                damage = units[i].Attack(victim, attackPhase);
            }
            turnSimulator.Add(DamageDebug(units[i].UnitName, victim.UnitName, damage));
            turnSimulator.Add(unitAndUnitUI[victim].TakeDamage(damage));
        }
        StartCoroutine(SimulateTurn(turnSimulator, attackPhase));
    }

    private void OnDieEvent(object sender, EventArgs e)
    {
        Unit unit = (Unit)sender;
        if (home.Contains(unit))
        {
            home.Remove(unit);
        }
        else
        {
            away.Remove(unit);
        }
        units.Remove(unit);
        Debug.Log("{sender} had died");
    }

    IEnumerator DamageDebug(string name, string victimName, int damage)
    {
        Debug.Log($"{name} attacked {victimName}, damage is {damage}!");
        yield return null;
    }

    IEnumerator SimulateTurn(List<IEnumerator> enumerators, int attackPhase)
    {
        Debug.Log($"Current Attack Phase: {attackPhase}"); ;
        foreach (IEnumerator enumerator in enumerators)
        {
            yield return enumerator;
        }
        if (attackPhase < 4)
        {
            attackPhase = attackPhase + 1;
            CalculateBattle(attackPhase);
        }
    }
}
