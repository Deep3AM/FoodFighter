using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateUI : MonoBehaviour
{
    private int foodCost1;
    private int foodCost2;
    private int foodCost3;
    private Recipe curRecipe;
    [SerializeField] private TextMeshProUGUI createDescriptionText;
    [SerializeField] private TextMeshProUGUI createCostText;
    [SerializeField] private List<Recipe> recipes;
    [SerializeField] private Button pRecipeButton;
    [SerializeField] private Transform createContentTransform;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        SetCreatUI(recipes[0]);
    }

    private void Init()
    {
        foreach (Recipe recipe in recipes)
        {
            Button temp = Instantiate(pRecipeButton);
            temp.onClick.AddListener(() => SetCreatUI(recipe));
            temp.transform.SetParent(createContentTransform, false);
        }
    }

    public void SetCreatUI(Recipe recipe)
    {
        curRecipe = recipe;
        foodCost1 = curRecipe.FoodCost1;
        foodCost2 = curRecipe.FoodCost2;
        foodCost3 = curRecipe.FoodCost3;
        createCostText.text = $"1: {foodCost1}\n2: {foodCost2}\n3: {foodCost3}";
        createDescriptionText.text = $"Name: {curRecipe.RecipeName}\nType: {curRecipe.Type.ToString()}\n{curRecipe.RecipeDescription}";
    }

    public void Create()
    {
        Debug.Log($"1: {foodCost1}\n2: {foodCost2}\n3: {foodCost3}\nCreate {curRecipe.RecipeName}");
    }


}
