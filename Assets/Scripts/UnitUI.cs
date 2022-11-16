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
        hp.text = unit.HPStat.ToString();
    }

    public IEnumerator TakeDamage(int damage)
    {
        hp.text = (int.Parse(hp.text) - damage).ToString();
        yield return new WaitForSeconds(1f);
    }
}
