using UnityEngine;
[CreateAssetMenu(fileName = "Base Unit Stat Data", menuName = "Scriptable Objects/Base Unit Stat Data", order = int.MaxValue)]
public class BaseUnitStat : ScriptableObject
{
    [SerializeField] private string unitName;
    [SerializeField] private Enum.PropertyName property;
    [SerializeField] private int baseHP;
    [SerializeField] private int baseAttack;
    [SerializeField] private int baseDefense;
    [SerializeField] private int baseAccuracy;
    [SerializeField] private int baseLuck;
    [SerializeField] private float baseSpeed;
    [SerializeField] private int baseTier;

    public string UnitName { get { return unitName; } }
    public Enum.PropertyName Property { get { return property; } }
    public int BaseHP { get { return baseHP; } }
    public int BaseAttack { get { return baseAttack; } }
    public int BaseDefense { get { return baseDefense; } }
    public int BaseAccuracy { get { return baseAccuracy; } }
    public int BaseLuck { get { return baseLuck; } }
    public float BaseSpeed { get { return baseSpeed; } }
    public int BaseTier { get { return baseTier; } }

    public void SetStat()
    {
        //Later Set These Base Stats from Server or Cloud.
    }
}
