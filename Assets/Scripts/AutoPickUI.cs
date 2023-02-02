using UnityEngine;

public class AutoPickUI : MonoBehaviour
{
    [SerializeField] private AutoPickObject pAutoPickObject;

    private void Awake()
    {
        foreach (NonUnitBaseInformation nonUnit in BaseInformationReader.Instance.NonUnitBaseInformations.Values)
        {
            AutoPickObject temp = Instantiate(pAutoPickObject);
            temp.SetAutoPickObject(nonUnit);
            temp.transform.SetParent(this.transform);
        }
    }
}
