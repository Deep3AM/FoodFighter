using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleUnitPickUI : MonoBehaviour
{
    [SerializeField] private SelectUnitObject pSelectUnitObject;
    [SerializeField] private Transform selectUnitContent;
    [SerializeField] private List<TextMeshProUGUI> selectedUnitTexts;
    [SerializeField] private List<GameObject> selectedUnitObject;
    private void Awake()
    {
        foreach (UnitBaseInformation unit in BaseInformationReader.Instance.UnitBaseInformations.Values)
        {
            SelectUnitObject temp = Instantiate(pSelectUnitObject);
            temp.SetSelectUnitButton(unit, this);
            temp.transform.SetParent(selectUnitContent);
        }
        SetSelectedUnitObject();
    }

    public void SetSelectedUnitObject()
    {
        for (int i = 0; i < 4; i++)
        {
            selectedUnitObject[i].SetActive(false);
        }
        for (int i = 0; i < UserData.Instance.BattleUnits.Count; i++)
        {
            selectedUnitObject[i].SetActive(true);
            selectedUnitTexts[i].text = UserData.Instance.BattleUnits[i];
        }
    }
}
