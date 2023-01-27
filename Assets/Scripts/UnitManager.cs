using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UnitManager : Singleton<UnitManager>
{
    private List<Unit> units = new List<Unit>();
    private List<Unit> home = new List<Unit>();
    private List<Unit> away = new List<Unit>();
    public ConcurrentDictionary<Unit, UnitUI> unitAndUnitUI = new ConcurrentDictionary<Unit, UnitUI>();
    private UnitCanvas unitCanvas = null;
    private List<IEnumerator> turnSimulator = new List<IEnumerator>();
    private bool isEndedBeforeEndPhase = false;

    public void SetBattle()
    {
        unitCanvas = FindObjectOfType<UnitCanvas>();
        foreach (Unit h in home)
        {
            units.Add(h);
            h.onDieEvent += OnDieEvent;
        }
        foreach (Unit a in away)
        {
            units.Add(a);
            a.onDieEvent += OnDieEvent;
        }
        unitCanvas.SetUnitUICanvas(home, away);
    }

    public void CalculateBattle(int attackPhase)
    {
        unitCanvas.SetPhaseDebugText(attackPhase);
        turnSimulator.Clear();
        units.Sort((Unit x, Unit y) => x.UnitStat.Bitter.CompareTo(y.UnitStat.Bitter));
        Random.InitState((int)DateTime.Now.Ticks);
        for (int i = 0; i < units.Count; i++)
        {
            Unit unit = units[i];
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
            //save current state and compensation before simulating this phase!
            //users can't stop after current phase started!
            turnSimulator.Add(DamageDebug(unit.UnitName, victim.UnitName, damage));
            turnSimulator.Add(unitAndUnitUI[victim].TakeDamage(damage));
            if (home.Count == 0)
            {
                turnSimulator.Add(ScoreDebug("away"));
                isEndedBeforeEndPhase = true;
                break;
            }
            else if (away.Count == 0)
            {
                turnSimulator.Add(ScoreDebug("home"));
                isEndedBeforeEndPhase = true;
                break;
            }
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
        Debug.Log($"{unit.UnitName} had died");
    }

    IEnumerator DamageDebug(string name, string victimName, int damage)
    {
        Debug.Log($"{name} attacked {victimName}, damage is {damage}!");
        yield return null;
    }

    IEnumerator ScoreDebug(string s)
    {
        unitCanvas.ShowScoreDebugUINoButton(s);
        yield return null;
    }

    IEnumerator SimulateTurn(List<IEnumerator> enumerators, int attackPhase)
    {
        Debug.Log($"Current Attack Phase: {attackPhase}"); ;
        foreach (IEnumerator enumerator in enumerators)
        {
            yield return enumerator;
        }
        if (attackPhase < 3 && !isEndedBeforeEndPhase)
        {
            attackPhase = attackPhase + 1;
            CalculateBattle(attackPhase);
        }
        else if (attackPhase == 3 && !isEndedBeforeEndPhase)
        {
            unitCanvas.SelectContinueLastPhase();
        }
    }
}
