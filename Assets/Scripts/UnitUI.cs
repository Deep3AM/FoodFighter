using System.Collections;
using TMPro;
using UnityEngine;

public class UnitUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI unitName;
    [SerializeField] private TextMeshProUGUI hp;

    public void SetUnitUI(Unit unit)
    {
        unitName.text = unit.UnitName;
        hp.text = unit.UnitStat.Hardness.ToString();
    }

    public IEnumerator TakeDamage(int damage)
    {
        int currentHP = int.Parse(hp.text) - damage;
        if (currentHP <= 0)
        {
            hp.text = "0";
        }
        else
        {
            hp.text = currentHP.ToString();
        }
        yield return new WaitForSeconds(1f);
    }
}
