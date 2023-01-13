using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnchantUI : MonoBehaviour
{
    private int enchantCost = 1;//after database is created, it will be changed 
    private BaseUnitStat curBaseUnitStat;
    [SerializeField] private TextMeshProUGUI enchantDescriptionText;
    [SerializeField] private TextMeshProUGUI enchantCostText;
    [SerializeField] private List<BaseUnitStat> baseUnitStats;
    [SerializeField] private Button pEnchantButton;
    [SerializeField] private Transform enchantContentTransform;
    [SerializeField] private UnitViewUI unitViewUI;
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        SetEnchantUI(baseUnitStats[0]);
    }

    private void Init()
    {
        foreach (BaseUnitStat baseUnitStat in baseUnitStats)
        {
            Button temp = Instantiate(pEnchantButton);
            temp.onClick.AddListener(() =>
            {
                SetEnchantUI(baseUnitStat);
                unitViewUI.ShowUI(baseUnitStat);
            }
            );
            //if (!UnitStatManager.Instance.unitDatas[baseUnitStat.UnitName].isEnable)
            //    temp.interactable = false;
            temp.transform.SetParent(enchantContentTransform, false);
        }
    }

    public void SetEnchantUI(BaseUnitStat baseUnitStat)
    {
        curBaseUnitStat = baseUnitStat;
        enchantCostText.text = $"cost: {enchantCost}";
        enchantDescriptionText.text = $"Name: {curBaseUnitStat.UnitName}\nType: {curBaseUnitStat.Type.ToString()}";
    }

    public void Enchant()
    {
        Debug.Log($"Enchant {curBaseUnitStat.UnitName}!");
    }
}
