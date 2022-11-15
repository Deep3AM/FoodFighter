using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UnitManager : Singleton<UnitManager>
{
    [SerializeField] private List<Unit> units = new List<Unit>();
    [SerializeField] private List<Unit> home = new List<Unit>();
    [SerializeField] private List<Unit> away = new List<Unit>();

    public void SetBattle()
    {
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
    }

    public void CalculateBattle()
    {
        units.Sort((Unit x, Unit y) => x.SpeedStat.CompareTo(y.SpeedStat));
        Random.InitState((int)DateTime.Now.Ticks);
        for (int i = 0; i < units.Count; i++)
        {
            if (home.Contains(units[i]))
            {
                Debug.Log("attack");
                units[i].Attack(away[Random.Range(0, away.Count)]);
            }
            else
            {
                units[i].Attack(home[Random.Range(0, home.Count)]);
            }
        }
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
}
