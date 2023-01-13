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
    public void ShowUI(BaseUnitStat baseUnitStat)
    {
        gameObject.SetActive(true);
        unitDescriptionText.text =
            baseUnitStat.UnitName + "\n" +
            baseUnitStat.Type.ToString() + "\n" +
            baseUnitStat.BaseHardnessLevel.ToString() + "\n" +
            baseUnitStat.BaseSpicyLevel.ToString() + "\n" +
            baseUnitStat.BaseSourLevel.ToString() + "\n" +
            baseUnitStat.BaseSweetLevel.ToString() + "\n" +
            baseUnitStat.BaseBitterLevel.ToString() + "\n" +
            baseUnitStat.BaseSaltyLevel.ToString() + "\n";
        skillTexts[0].text = baseUnitStat.FirstAttack.AttackName;
        skillTexts[1].text = baseUnitStat.SecondAttack.AttackName;
        skillTexts[2].text = baseUnitStat.ThirdAttack.AttackName;
        skillTexts[3].text = baseUnitStat.FourthAttack.AttackName;
        ShowLevel(baseUnitStat.UnitName);
        plusButton[0].onClick.AddListener(() =>
        {
            UnitStatManager.Instance.SetStat(baseUnitStat.UnitName, "Hardness", 1);
            ShowLevel(baseUnitStat.UnitName);
        });
        plusButton[1].onClick.AddListener(() =>
        {
            UnitStatManager.Instance.SetStat(baseUnitStat.UnitName, "Spicy", 1);
            ShowLevel(baseUnitStat.UnitName);
        });
        plusButton[2].onClick.AddListener(() =>
        {
            UnitStatManager.Instance.SetStat(baseUnitStat.UnitName, "Sour", 1);
            ShowLevel(baseUnitStat.UnitName);
        });
        plusButton[3].onClick.AddListener(() =>
        {
            UnitStatManager.Instance.SetStat(baseUnitStat.UnitName, "Sweet", 1);
            ShowLevel(baseUnitStat.UnitName);
        });
        plusButton[4].onClick.AddListener(() =>
        {
            UnitStatManager.Instance.SetStat(baseUnitStat.UnitName, "Salty", 1);
            ShowLevel(baseUnitStat.UnitName);
        });
        plusButton[5].onClick.AddListener(() =>
        {
            UnitStatManager.Instance.SetStat(baseUnitStat.UnitName, "Bitter", 1);
            ShowLevel(baseUnitStat.UnitName);
        });

        minusButton[0].onClick.AddListener(() =>
        {
            UnitStatManager.Instance.SetStat(baseUnitStat.UnitName, "Hardness", -1);
            ShowLevel(baseUnitStat.UnitName);
        });
        minusButton[1].onClick.AddListener(() =>
        {
            UnitStatManager.Instance.SetStat(baseUnitStat.UnitName, "Spicy", -1);
            ShowLevel(baseUnitStat.UnitName);
        });
        minusButton[2].onClick.AddListener(() =>
        {
            UnitStatManager.Instance.SetStat(baseUnitStat.UnitName, "Sour", -1);
            ShowLevel(baseUnitStat.UnitName);
        });
        minusButton[3].onClick.AddListener(() =>
        {
            UnitStatManager.Instance.SetStat(baseUnitStat.UnitName, "Sweet", -1);
            ShowLevel(baseUnitStat.UnitName);
        });
        minusButton[4].onClick.AddListener(() =>
        {
            UnitStatManager.Instance.SetStat(baseUnitStat.UnitName, "Salty", -1);
            ShowLevel(baseUnitStat.UnitName);
        });
        minusButton[5].onClick.AddListener(() =>
        {
            UnitStatManager.Instance.SetStat(baseUnitStat.UnitName, "Bitter", -1);
            ShowLevel(baseUnitStat.UnitName);
        });
    }

    private void ShowLevel(string unitName)
    {
        statLevelTexts[0].text = "hardness level: " + UnitStatManager.Instance.unitDatas[unitName].hardnessLevel.ToString();
        statLevelTexts[1].text = "spicy level: " + UnitStatManager.Instance.unitDatas[unitName].spicyLevel.ToString();
        statLevelTexts[2].text = "sour level: " + UnitStatManager.Instance.unitDatas[unitName].sourLevel.ToString();
        statLevelTexts[3].text = "sweet level: " + UnitStatManager.Instance.unitDatas[unitName].sweetLevel.ToString();
        statLevelTexts[4].text = "salty level: " + UnitStatManager.Instance.unitDatas[unitName].saltyLevel.ToString();
        statLevelTexts[5].text = "bitter level: " + UnitStatManager.Instance.unitDatas[unitName].bitterLevel.ToString();
    }
}
