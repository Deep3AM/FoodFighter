using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitViewUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI unitDescriptionText;
    [SerializeField] private TextMeshProUGUI[] skillTexts = new TextMeshProUGUI[4];
    [SerializeField] private TextMeshProUGUI[] statLevelTexts = new TextMeshProUGUI[6];
    [SerializeField] private Button[] plusButton = new Button[6];
    [SerializeField] private Button[] minusButton = new Button[6];
    public void ShowUI(UnitBaseInformation unitBaseInformation)
    {
        gameObject.SetActive(true);
        unitDescriptionText.text =
            unitBaseInformation.RecipeName + "\n" +
            unitBaseInformation.Type.ToString() + "\n" +
            unitBaseInformation.BaseHardness.ToString() + "\n" +
            unitBaseInformation.BaseSpicy.ToString() + "\n" +
            unitBaseInformation.BaseSour.ToString() + "\n" +
            unitBaseInformation.BaseSweet.ToString() + "\n" +
            unitBaseInformation.BaseBitter.ToString() + "\n" +
            unitBaseInformation.BaseSalty.ToString() + "\n";
        skillTexts[0].text = unitBaseInformation.FirstAttack;
        skillTexts[1].text = unitBaseInformation.SecondAttack;
        skillTexts[2].text = unitBaseInformation.ThirdAttack;
        skillTexts[3].text = unitBaseInformation.FourthAttack;
        ShowLevel(unitBaseInformation.RecipeName);
        plusButton[0].onClick.AddListener(() =>
        {
            UserData.Instance.SetStat(unitBaseInformation.RecipeName, "Hardness", 1);
            ShowLevel(unitBaseInformation.RecipeName);
        });
        plusButton[1].onClick.AddListener(() =>
        {
            UserData.Instance.SetStat(unitBaseInformation.RecipeName, "Spicy", 1);
            ShowLevel(unitBaseInformation.RecipeName);
        });
        plusButton[2].onClick.AddListener(() =>
        {
            UserData.Instance.SetStat(unitBaseInformation.RecipeName, "Sour", 1);
            ShowLevel(unitBaseInformation.RecipeName);
        });
        plusButton[3].onClick.AddListener(() =>
        {
            UserData.Instance.SetStat(unitBaseInformation.RecipeName, "Sweet", 1);
            ShowLevel(unitBaseInformation.RecipeName);
        });
        plusButton[4].onClick.AddListener(() =>
        {
            UserData.Instance.SetStat(unitBaseInformation.RecipeName, "Salty", 1);
            ShowLevel(unitBaseInformation.RecipeName);
        });
        plusButton[5].onClick.AddListener(() =>
        {
            UserData.Instance.SetStat(unitBaseInformation.RecipeName, "Bitter", 1);
            ShowLevel(unitBaseInformation.RecipeName);
        });

        minusButton[0].onClick.AddListener(() =>
        {
            UserData.Instance.SetStat(unitBaseInformation.RecipeName, "Hardness", -1);
            ShowLevel(unitBaseInformation.RecipeName);
        });
        minusButton[1].onClick.AddListener(() =>
        {
            UserData.Instance.SetStat(unitBaseInformation.RecipeName, "Spicy", -1);
            ShowLevel(unitBaseInformation.RecipeName);
        });
        minusButton[2].onClick.AddListener(() =>
        {
            UserData.Instance.SetStat(unitBaseInformation.RecipeName, "Sour", -1);
            ShowLevel(unitBaseInformation.RecipeName);
        });
        minusButton[3].onClick.AddListener(() =>
        {
            UserData.Instance.SetStat(unitBaseInformation.RecipeName, "Sweet", -1);
            ShowLevel(unitBaseInformation.RecipeName);
        });
        minusButton[4].onClick.AddListener(() =>
        {
            UserData.Instance.SetStat(unitBaseInformation.RecipeName, "Salty", -1);
            ShowLevel(unitBaseInformation.RecipeName);
        });
        minusButton[5].onClick.AddListener(() =>
        {
            UserData.Instance.SetStat(unitBaseInformation.RecipeName, "Bitter", -1);
            ShowLevel(unitBaseInformation.RecipeName);
        });
    }

    private void ShowLevel(string unitName)
    {
        statLevelTexts[0].text = "hardness level: " + UserData.Instance.UnitDatas[unitName].hardnessLevel.ToString();
        statLevelTexts[1].text = "spicy level: " + UserData.Instance.UnitDatas[unitName].spicyLevel.ToString();
        statLevelTexts[2].text = "sour level: " + UserData.Instance.UnitDatas[unitName].sourLevel.ToString();
        statLevelTexts[3].text = "sweet level: " + UserData.Instance.UnitDatas[unitName].sweetLevel.ToString();
        statLevelTexts[4].text = "salty level: " + UserData.Instance.UnitDatas[unitName].saltyLevel.ToString();
        statLevelTexts[5].text = "bitter level: " + UserData.Instance.UnitDatas[unitName].bitterLevel.ToString();
    }
}
