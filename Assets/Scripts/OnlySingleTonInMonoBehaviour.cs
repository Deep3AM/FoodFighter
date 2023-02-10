using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlySingleTonInMonoBehaviour : Singleton<OnlySingleTonInMonoBehaviour>
{
    private Dictionary<string, IEnumerator> autoPickCoroutines = new Dictionary<string, IEnumerator>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (string name in UserData.Instance.AutoPickObjects)
        {
            AddAutoPickCoroutine(name);
        }
    }

    private IEnumerator AutoPickCoroutine(string _name)
    {
        yield return new WaitForSeconds(BaseInformationReader.Instance.NonUnitBaseInformations[_name].BaseAutoPickTime);
        UserData.Instance.SetIngredientNum(_name, 1);
        Debug.Log(_name + " 1 up");
        yield return AutoPickCoroutine(_name);
    }

    public void AddAutoPickCoroutine(string _name)
    {
        autoPickCoroutines.Add(_name, AutoPickCoroutine(_name));
        StartCoroutine(autoPickCoroutines[_name]);
    }

    public void RemoveAutoPickCoroutine(string _name)
    {
        StopCoroutine(autoPickCoroutines[_name]);
        autoPickCoroutines.Remove(_name);
    }
}
