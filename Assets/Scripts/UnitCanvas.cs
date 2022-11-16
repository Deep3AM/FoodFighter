using System.Collections.Generic;
using UnityEngine;

public class UnitCanvas : MonoBehaviour
{
    [SerializeField] private Transform homeUnit;
    [SerializeField] private Transform awayUnit;
    [SerializeField] private UnitUI unitUIPrefab;

    public void SetUnitUICanvas(List<Unit> home, List<Unit> away)
    {
        foreach (Unit h in home)
        {
            UnitUI unitUI = Instantiate(unitUIPrefab);
            unitUI.SetUnitUI(h);
            unitUI.transform.SetParent(homeUnit);
            UnitManager.Instance.unitAndUnitUI.TryAdd(h, unitUI);
        }
        foreach (Unit a in away)
        {
            UnitUI unitUI = Instantiate(unitUIPrefab);
            unitUI.SetUnitUI(a);
            unitUI.transform.SetParent(awayUnit);
            UnitManager.Instance.unitAndUnitUI.TryAdd(a, unitUI);
        }
    }
}
