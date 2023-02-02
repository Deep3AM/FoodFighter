using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateUI : MonoBehaviour
{
    private UnitBaseInformation curUnitBaseInformation;
    [SerializeField] private TextMeshProUGUI createDescriptionText;
    [SerializeField] private TextMeshProUGUI createCostText;
    [SerializeField] private Button pRecipeButton;
    [SerializeField] private Button pIngredientButton;
    [SerializeField] private Transform createContentTransform;
    [SerializeField] private Transform createIngredientTransform;
    [SerializeField] private List<Ingredient> curIngredientInformation = new List<Ingredient>();
    [SerializeField] private Burner burner;
    private string recipeText;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        SetCreatUI(BaseInformationReader.Instance.UnitBaseInformations.Values.ToList()[0]);
    }

    private void Init()
    {
        foreach (UnitBaseInformation unitBaseInformation in BaseInformationReader.Instance.UnitBaseInformations.Values)
        {
            Button temp = Instantiate(pRecipeButton);
            temp.onClick.AddListener(() => SetCreatUI(unitBaseInformation));
            temp.transform.SetParent(createContentTransform, false);
        }
    }

    public void SetCreatUI(UnitBaseInformation unitBaseInformation)
    {
        foreach (Transform child in createIngredientTransform)
        {
            Destroy(child.gameObject);
        }
        curIngredientInformation.Clear();
        curUnitBaseInformation = unitBaseInformation;
        string temp = "";
        foreach (Ingredient ingredient in unitBaseInformation.IngredinetInformation)
        {
            temp += ingredient.ingredientName + ": " + ingredient.num.ToString() + "\n";
            if (ingredient.ingredientName.Contains("BaseTier"))
            {
                int tier = int.Parse(ingredient.ingredientName[8].ToString());
                foreach (var unit in BaseInformationReader.Instance.UnitBaseInformations.Values)
                {
                    if (unit.BaseTier == tier)
                    {
                        Button tierIngredientTemp = Instantiate(pIngredientButton, createIngredientTransform);
                        tierIngredientTemp.GetComponentInChildren<TextMeshProUGUI>().text = unit.RecipeName + ": "
                            + UserData.Instance.IngredientDatas[unit.RecipeName].ToString();
                    }
                }
                continue;
            }
            Button ingredientTemp = Instantiate(pIngredientButton, createIngredientTransform);
            ingredientTemp.GetComponentInChildren<TextMeshProUGUI>().text = ingredient.ingredientName + ": "
                + UserData.Instance.IngredientDatas[ingredient.ingredientName].ToString();
            curIngredientInformation.Add(ingredient);
        }
        createCostText.text = temp;
    }

    public void Create()
    {
        foreach (var ingredient in curIngredientInformation)
        {
            UserData.Instance.SetIngredientNum(ingredient.ingredientName, -ingredient.num);
        }
        UserData.Instance.SetIngredientNum(curUnitBaseInformation.RecipeName, 1);
        burner.gameObject.SetActive(true);
    }


}
