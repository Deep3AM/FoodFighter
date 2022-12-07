using Enum;
using UnityEngine;
[CreateAssetMenu(fileName = "Recipe", menuName = "Scriptable Objects/Recipe", order = int.MaxValue)]
public class Recipe : ScriptableObject
{
    [SerializeField] private string recipeName;
    [SerializeField] private FoodType type;
    [SerializeField] private string recipeDescription;
    [SerializeField] private int foodCost1;
    [SerializeField] private int foodCost2;
    [SerializeField] private int foodCost3;

    public string RecipeName { get { return recipeName; } }
    public FoodType Type { get { return type; } }
    public string RecipeDescription { get { return recipeDescription; } }
    public int FoodCost1 { get { return foodCost1; } }
    public int FoodCost2 { get { return foodCost2; } }
    public int FoodCost3 { get { return foodCost3; } }
}
