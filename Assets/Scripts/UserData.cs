using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitData
{
    public bool isEnable = false;
    public int hardnessLevel = 0;
    public int sweetLevel = 0;
    public int sourLevel = 0;
    public int saltyLevel = 0;
    public int spicyLevel = 0;
    public int bitterLevel = 0;

    public UnitData()
    {
        isEnable = false;
        hardnessLevel = 0;
        sweetLevel = 0;
        sourLevel = 0;
        saltyLevel = 0;
        spicyLevel = 0;
        bitterLevel = 0;
    }
}

public class UserData : SingletonWithoutMonobehaviour<UserData>
{
    private Dictionary<string, UnitData> unitDatas;
    private Dictionary<string, int> ingredientDatas;
    private List<string> battleUnits;
    private List<string> autoPickObjects;
    public Dictionary<string, UnitData> UnitDatas { get { return unitDatas; } }
    public Dictionary<string, int> IngredientDatas { get { return ingredientDatas; } }
    public List<string> BattleUnits { get { return battleUnits; } }
    public List<string> AutoPickObjects { get { return autoPickObjects; } }
    public void LoadAll()
    {
        LoadUnitDatas();
        LoadIngredientDatas();
        LoadAutoPickObjects();
        LoadBattleUnits();
    }

    public void SaveAll()
    {
        SaveUnitDatas();
        SaveIngredientDatas();
        SaveBattleUnits();
        SaveAutoPickObjects();
    }

    public void SaveUnitDatas()
    {
        ES3.Save("UnitDatas", unitDatas);
    }


    public void LoadUnitDatas()
    {
        unitDatas = new Dictionary<string, UnitData>();
        foreach (var temp in BaseInformationReader.Instance.UnitBaseInformations.Values)
        {
            unitDatas.Add(temp.RecipeName, new UnitData());
        }
        Dictionary<string, UnitData> loadedUnitDatas = (Dictionary<string, UnitData>)ES3.Load("UnitDatas", new Dictionary<string, UnitData>());
        foreach (string key in loadedUnitDatas.Keys)
        {
            unitDatas[key] = loadedUnitDatas[key];
        }
    }

    public void SaveIngredientDatas()
    {
        ES3.Save("IngredientDatas", ingredientDatas);
    }

    public void LoadIngredientDatas()
    {
        ingredientDatas = new Dictionary<string, int>();
        foreach (var temp in BaseInformationReader.Instance.RecipeNames)
        {
            ingredientDatas.Add(temp, 0);
        }
        Dictionary<string, int> loadedIngredientDatas = (Dictionary<string, int>)ES3.Load("IngredientDatas", new Dictionary<string, int>());
        foreach (string key in loadedIngredientDatas.Keys)
        {
            ingredientDatas[key] = loadedIngredientDatas[key];
            if (ingredientDatas[key] < 0)
            {
                ingredientDatas[key] = 0;
            }
        }
    }

    public void SaveBattleUnits()
    {
        ES3.Save("BattleUnits", battleUnits);
    }

    public void LoadBattleUnits()
    {
        battleUnits = new List<string>();
        List<string> loadedBattleUnits = ES3.Load("BattleUnits", new List<string>());
        foreach (var unit in loadedBattleUnits)
        {
            battleUnits.Add(unit);
        }
    }

    public void SaveAutoPickObjects()
    {
        ES3.Save("AutoPickObjects", autoPickObjects);
    }

    public void LoadAutoPickObjects()
    {
        autoPickObjects = new List<string>();
        List<string> loadedAutoPickObjects = ES3.Load("AutoPickObjects", new List<string>());
        foreach (var autoPickObject in loadedAutoPickObjects)
        {
            autoPickObjects.Add(autoPickObject);
            Debug.Log(autoPickObject);
        }
    }

    protected override void init()
    {
        LoadAll();
    }

    public void SetStat(string unitName, string statName, int amount)
    {
        switch (statName)
        {
            case "Hardness":
                unitDatas[unitName].hardnessLevel += amount;
                break;
            case "Sweet":
                unitDatas[unitName].sweetLevel += amount;
                break;
            case "Sour":
                unitDatas[unitName].sourLevel += amount;
                break;
            case "Salty":
                unitDatas[unitName].saltyLevel += amount;
                break;
            case "Spicy":
                unitDatas[unitName].spicyLevel += amount;
                break;
            case "Bitter":
                unitDatas[unitName].bitterLevel += amount;
                break;
            default:
                Debug.Log("Wrong Stat Name");
                break;
        }
        SaveUnitDatas();
    }

    public void SetIngredientNum(string ingredinetName, int ingredientNum)
    {
        ingredientDatas[ingredinetName] += ingredientNum;
        SaveIngredientDatas();
    }

    public void AddAutoPickObject(string _autoPickObject)
    {
        if (!autoPickObjects.Contains(_autoPickObject))
        {
            autoPickObjects.Add(_autoPickObject);
            SaveAutoPickObjects();
        }
    }

    public void RemoveAutoPickObject(string _autoPickObject)
    {
        if (autoPickObjects.Contains(_autoPickObject))
        {
            autoPickObjects.Remove(_autoPickObject);
            SaveAutoPickObjects();
        }
    }

    public void AddBattleUnit(string _battleUnit)
    {
        if (!battleUnits.Contains(_battleUnit))
        {
            battleUnits.Add(_battleUnit);
            SaveBattleUnits();
        }
    }

    public void RemoveBattleUnit(string _battleUnit)
    {
        if (battleUnits.Contains(_battleUnit))
        {
            battleUnits.Remove(_battleUnit);
            SaveBattleUnits();
        }
    }
}
