using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoPickObject : MonoBehaviour
{
    private NonUnitBaseInformation nonUnitBaseInformation;
    [SerializeField] private TextMeshProUGUI autoPickObjectNameText;
    [SerializeField] private TextMeshProUGUI autoPickObjectProductionTime;
    [SerializeField] private Button autoPickSelectButton;
    private bool isSelected;

    public void SetAutoPickObject(NonUnitBaseInformation _nonUnitBaseInformation)
    {
        nonUnitBaseInformation = _nonUnitBaseInformation;
        autoPickObjectNameText.text = nonUnitBaseInformation.RecipeName;
        autoPickObjectProductionTime.text = "Production Time: " + nonUnitBaseInformation.BaseAutoPickTime.ToString();
        autoPickSelectButton.onClick.AddListener(() => SelectAutoPickObject());
        if (UserData.Instance.AutoPickObjects.Contains(nonUnitBaseInformation.RecipeName))
        {
            isSelected = true;
        }
        else
        {
            isSelected = false;
        }
        SetIsSelected();
    }

    private void SelectAutoPickObject()
    {
        if (!isSelected)
        {
            UserData.Instance.AddAutoPickObject(nonUnitBaseInformation.RecipeName);
            isSelected = true;
            SetIsSelected();
            return;
        }
        UserData.Instance.RemoveAutoPickObject(nonUnitBaseInformation.RecipeName);
        isSelected = false;
        SetIsSelected();
    }

    private void SetIsSelected()
    {
        if (isSelected)
        {
            autoPickSelectButton.GetComponent<Image>().color = Color.red;
            return;
        }
        autoPickSelectButton.GetComponent<Image>().color = Color.white;
    }
}
