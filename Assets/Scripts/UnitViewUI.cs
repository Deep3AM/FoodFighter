using TMPro;
using UnityEngine;

public class UnitViewUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI unitDescriptionText;
    [SerializeField] private TextMeshProUGUI[] skillTexts = new TextMeshProUGUI[4];
    public void ShowUI(BaseUnitStat baseUnitStat)
    {
        gameObject.SetActive(true);
        unitDescriptionText.text =
            baseUnitStat.UnitName + "\n" +
            baseUnitStat.Type.ToString() + "\n" +
            baseUnitStat.BaseHP.ToString() + "\n" +
            baseUnitStat.BaseAttack.ToString() + "\n" +
            baseUnitStat.BaseDefense.ToString() + "\n" +
            baseUnitStat.BaseAccuracy.ToString() + "\n" +
            baseUnitStat.BaseLuck.ToString() + "\n" +
            baseUnitStat.BaseSpeed.ToString() + "\n";
        skillTexts[0].text = baseUnitStat.FirstAttack.AttackName;
        skillTexts[1].text = baseUnitStat.SecondAttack.AttackName;
        skillTexts[2].text = baseUnitStat.ThirdAttack.AttackName;
        skillTexts[3].text = baseUnitStat.FourthAttack.AttackName;
    }
}
