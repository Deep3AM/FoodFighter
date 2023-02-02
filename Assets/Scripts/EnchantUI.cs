using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnchantUI : MonoBehaviour
{
    private int enchantCost = 1;//after database is created, it will be changed 
    private UnitBaseInformation curUnitBaseInformation;
    [SerializeField] private TextMeshProUGUI enchantDescriptionText;
    [SerializeField] private TextMeshProUGUI enchantCostText;
    [SerializeField] private Button pEnchantButton;
    [SerializeField] private Transform enchantContentTransform;
    [SerializeField] private UnitViewUI unitViewUI;
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        SetEnchantUI(BaseInformationReader.Instance.UnitBaseInformations.Values.ToList()[0]);
    }

    private void Init()
    {
        foreach (var unitInformation in BaseInformationReader.Instance.UnitBaseInformations.Values)
        {
            Button temp = Instantiate(pEnchantButton);
            temp.onClick.AddListener(() =>
            {
                SetEnchantUI(unitInformation);
                unitViewUI.ShowUI(unitInformation);
            }
            );
            //if (!UnitStatManager.Instance.unitDatas[baseUnitStat.UnitName].isEnable)
            //    temp.interactable = false;
            temp.transform.SetParent(enchantContentTransform, false);
        }
    }

    public void SetEnchantUI(UnitBaseInformation unitBaseInformation)
    {
        curUnitBaseInformation = unitBaseInformation;
        enchantCostText.text = $"cost: {enchantCost}";
        enchantDescriptionText.text = $"Name: {curUnitBaseInformation.RecipeName}\nType: {curUnitBaseInformation.Type.ToString()}";
    }

    public void Enchant()
    {
        Debug.Log($"Enchant {curUnitBaseInformation.RecipeName}!");
    }
}
