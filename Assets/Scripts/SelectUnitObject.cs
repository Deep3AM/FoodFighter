using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectUnitObject : MonoBehaviour
{
    private string unitName;
    [SerializeField] private TextMeshProUGUI unitNameText;
    [SerializeField] private Button selectUnitObjectButton;
    private BattleUnitPickUI battleUnitPickUI;
    private bool isSelected;
    public void SetSelectUnitButton(UnitBaseInformation _unitBaseInformation, BattleUnitPickUI _battleUnitPickUI)
    {
        unitName = _unitBaseInformation.RecipeName;
        unitNameText.text = unitName;
        battleUnitPickUI = _battleUnitPickUI;
        selectUnitObjectButton.onClick.AddListener(() => SelectSelectUnitObject());
        if (UserData.Instance.BattleUnits.Contains(unitName))
        {
            isSelected = true;
        }
        else
        {
            isSelected = false;
        }
        SetIsSelected();
    }
    private void SelectSelectUnitObject()
    {
        if (!isSelected)
        {
            if (UserData.Instance.BattleUnits.Count >= 4)
                return;
            UserData.Instance.AddBattleUnit(unitName);
            isSelected = true;
            SetIsSelected();
            battleUnitPickUI.SetSelectedUnitObject();
            return;
        }
        UserData.Instance.RemoveBattleUnit(unitName);
        isSelected = false;
        SetIsSelected();
        battleUnitPickUI.SetSelectedUnitObject();
    }

    private void SetIsSelected()
    {
        if (isSelected)
        {
            selectUnitObjectButton.GetComponent<Image>().color = Color.red;
            return;
        }
        selectUnitObjectButton.GetComponent<Image>().color = Color.white;
    }
}
