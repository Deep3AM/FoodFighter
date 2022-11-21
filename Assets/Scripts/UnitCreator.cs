using System.Collections.Generic;
using UnityEngine;

public class UnitCreator : MonoBehaviour
{
    [SerializeField] private List<Resource> resources;

    public void UnitCreate()
    {
        for (int i = 0; i < resources.Count; i++)
        {
            Debug.Log($"{resources[i].GetName()}: {resources[i].GetAmount()}");
        }
        Debug.Log("Create Unit!");
    }
}
