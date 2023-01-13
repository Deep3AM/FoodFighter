using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitData
{
    public bool isEnable = false;
    public int hardnessLevel = 0;
    public int spicyLevel = 0;
    public int saltyLevel = 0;
    public int sweetLevel = 0;
    public int sourLevel = 0;
    public int bitterLevel = 0;

    public UnitData()
    {
        isEnable = false;
        hardnessLevel = 0;
        spicyLevel = 0;
        saltyLevel = 0;
        sweetLevel = 0;
        sourLevel = 0;
        bitterLevel = 0;
    }
}

public class UnitStat
{
    public string unitName;
    public Enum.FoodType type;
    public int hardness;
    public int spicy;
    public int sweet;
    public int sour;
    public int salty;
    public int bitter;
}

public class UnitStatManager : SingletonWithoutMonobehaviour<UnitStatManager>
{
    public Dictionary<string, UnitData> unitDatas;

    public void Save()
    {
        ES3.Save("UnitDatas", unitDatas);
    }

    public void Load()
    {
        string[] test = new string[3];
        test[0] = "TestUnit1";
        test[1] = "TestUnit2";
        test[2] = "TestUnit3";
        unitDatas = new Dictionary<string, UnitData>();
        foreach (string key in test)
        {
            unitDatas.Add(key, new UnitData());
        }
        Dictionary<string, UnitData> loadedUnitDatas = (Dictionary<string, UnitData>)ES3.Load("UnitDatas", new Dictionary<string, UnitData>());
        foreach (string key in loadedUnitDatas.Keys)
        {
            unitDatas[key] = loadedUnitDatas[key];
        }
    }

    protected override void init()
    {
        Load();
    }

    public void SetStat(string unitName, string statName, int amount)
    {
        switch (statName)
        {
            case "Hardness":
                unitDatas[unitName].hardnessLevel += amount;
                break;
            case "Spicy":
                unitDatas[unitName].spicyLevel += amount;
                break;
            case "Salty":
                unitDatas[unitName].saltyLevel += amount;
                break;
            case "Sweet":
                unitDatas[unitName].sweetLevel += amount;
                break;
            case "Sour":
                unitDatas[unitName].sourLevel += amount;
                break;
            case "Bitter":
                unitDatas[unitName].bitterLevel += amount;
                break;
            default:
                Debug.Log("Wrong Stat Name");
                break;
        }
        Save();
    }
}
