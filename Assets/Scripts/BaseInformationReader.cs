using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Ingredient
{
    public string ingredientName;
    public int num;

    public Ingredient(string parsedData)
    {
        var splittedData = parsedData.Split('|');
        ingredientName = splittedData[0];
        num = int.Parse(splittedData[1]);
    }
}
[System.Serializable]
public class NonUnitBaseInformation
{
    [SerializeField] private string recipeName;
    [SerializeField] private float baseAutoPickTime;
    public string RecipeName { get { return recipeName; } }
    public float BaseAutoPickTime { get { return baseAutoPickTime; } }

    public NonUnitBaseInformation(string _recipeName, float _baseAutoPickTime)
    {
        recipeName = _recipeName;
        baseAutoPickTime = _baseAutoPickTime;
    }
}
[System.Serializable]
public class UnitBaseInformation
{
    [SerializeField] private string recipeName;
    [SerializeField] private Enum.FoodType type;
    [SerializeField] private int baseHardness;
    [SerializeField] private int baseSpicy;
    [SerializeField] private int baseSweet;
    [SerializeField] private int baseSour;
    [SerializeField] private int baseSalty;
    [SerializeField] private int baseBitter;
    [SerializeField] private int baseTier;
    [SerializeField] private string firstAttack;
    [SerializeField] private string secondAttack;
    [SerializeField] private string thirdAttack;
    [SerializeField] private string fourthAttack;
    [SerializeField] private List<Ingredient> ingredientInformation = new List<Ingredient>();
    public string RecipeName { get { return recipeName; } }
    public Enum.FoodType Type { get { return type; } }
    public int BaseHardness { get { return baseHardness; } }
    public int BaseSpicy { get { return baseSpicy; } }
    public int BaseSweet { get { return baseSweet; } }
    public int BaseSour { get { return baseSour; } }
    public int BaseSalty { get { return baseSalty; } }
    public int BaseBitter { get { return baseBitter; } }
    public int BaseTier { get { return baseTier; } }
    public string FirstAttack { get { return firstAttack; } }
    public string SecondAttack { get { return secondAttack; } }
    public string ThirdAttack { get { return thirdAttack; } }
    public string FourthAttack { get { return fourthAttack; } }
    public List<Ingredient> IngredinetInformation { get { return ingredientInformation; } }

    public UnitBaseInformation(string _recipeName, string _type, int _baseHardness, int _baseSweet, int _baseSour,
        int _baseSalty, int _baseBitter, int _baseTier, string _firstAttack,
        string _secondAttack, string _thirdAttack, string _fourthAttack, string _ingredientInformation)
    {
        recipeName = _recipeName;
        if (_type.Contains('|'))
        {
            type = (Enum.FoodType)System.Enum.Parse(typeof(Enum.FoodType), _type.Replace('|', ','));
        }
        else
            type = (Enum.FoodType)System.Enum.Parse(typeof(Enum.FoodType), _type);
        baseHardness = _baseHardness;
        baseSweet = _baseSweet;
        baseSour = _baseSour;
        baseSalty = _baseSalty;
        baseBitter = _baseBitter;
        baseTier = _baseTier;
        firstAttack = _firstAttack;
        secondAttack = _secondAttack;
        thirdAttack = _thirdAttack;
        fourthAttack = _fourthAttack;
        var parsedIngredientInformation = _ingredientInformation.Split('+');
        foreach (string ingredient in parsedIngredientInformation)
        {
            Ingredient temp = new Ingredient(ingredient);
            ingredientInformation.Add(temp);
        }
    }

    public UnitBaseInformation(string _recipeName, string _type, int _baseHardness, int _baseSweet, int _baseSour,
    int _baseSalty, int _baseBitter, int _baseTier, string _firstAttack,
    string _secondAttack, string _thirdAttack, string _fourthAttack)
    {
        recipeName = _recipeName;
        if (_type.Contains('|'))
        {
            type = (Enum.FoodType)System.Enum.Parse(typeof(Enum.FoodType), _type.Replace('|', ','));
        }
        else
            type = (Enum.FoodType)System.Enum.Parse(typeof(Enum.FoodType), _type);
        baseHardness = _baseHardness;
        baseSweet = _baseSweet;
        baseSour = _baseSour;
        baseSalty = _baseSalty;
        baseBitter = _baseBitter;
        baseTier = _baseTier;
        firstAttack = _firstAttack;
        secondAttack = _secondAttack;
        thirdAttack = _thirdAttack;
        fourthAttack = _fourthAttack;
    }
}
public class BaseInformationReader : SingletonWithoutMonobehaviour<BaseInformationReader>
{
    List<string> recipeNames = new List<string>();
    Dictionary<string, UnitBaseInformation> unitBaseInformations = new Dictionary<string, UnitBaseInformation>();
    Dictionary<string, UnitBaseInformation> enemyUnitBaseInformations = new Dictionary<string, UnitBaseInformation>();
    Dictionary<string, NonUnitBaseInformation> nonUnitBaseInformations = new Dictionary<string, NonUnitBaseInformation>();
    public List<string> RecipeNames { get { return recipeNames; } }
    public Dictionary<string, UnitBaseInformation> UnitBaseInformations { get { return unitBaseInformations; } }
    public Dictionary<string, UnitBaseInformation> EnemyUnitBaseInformations { get { return enemyUnitBaseInformations; } }
    public Dictionary<string, NonUnitBaseInformation> NonUnitBaseInformations { get { return nonUnitBaseInformations; } }

    protected override void init()
    {
        Read();
    }

    public void Read()
    {
        var list = new List<Dictionary<string, object>>();
        list = CSVReader.Read("UnitBaseInformationSheets");
        foreach (var recipe in list)
        {
            recipeNames.Add(recipe["RecipeName"].ToString());
            if (recipe["Type"].ToString().Equals("None"))
            {
                var tempNonUnit = new NonUnitBaseInformation(recipe["RecipeName"].ToString(), float.Parse(recipe["AutoPickTime"].ToString()));
                nonUnitBaseInformations.Add(tempNonUnit.RecipeName, tempNonUnit);
                continue;
            }
            var temp = new UnitBaseInformation(recipe["RecipeName"].ToString(), recipe["Type"].ToString(),
                (int)recipe["BaseHardness"], (int)recipe["BaseSweet"], (int)recipe["BaseSour"],
                (int)recipe["BaseSalty"], (int)recipe["BaseBitter"], (int)recipe["BaseTier"],
                recipe["FirstAttack"].ToString(), recipe["SecondAttack"].ToString(),
                recipe["ThirdAttack"].ToString(), recipe["FourthAttack"].ToString(),
                recipe["IngredientInformation"].ToString());
            unitBaseInformations.Add(temp.RecipeName, temp);
        }
        list = CSVReader.Read("EnemyBaseInformationSheets");
        foreach (var recipe in list)
        {
            var temp = new UnitBaseInformation(recipe["RecipeName"].ToString(), recipe["Type"].ToString(),
                (int)recipe["BaseHardness"], (int)recipe["BaseSweet"], (int)recipe["BaseSour"],
                (int)recipe["BaseSalty"], (int)recipe["BaseBitter"], (int)recipe["BaseTier"],
                recipe["FirstAttack"].ToString(), recipe["SecondAttack"].ToString(),
                recipe["ThirdAttack"].ToString(), recipe["FourthAttack"].ToString());
            enemyUnitBaseInformations.Add(temp.RecipeName, temp);
        }
    }
}
