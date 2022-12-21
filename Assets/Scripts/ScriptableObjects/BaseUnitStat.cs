using UnityEngine;
[CreateAssetMenu(fileName = "Base Unit Stat Data", menuName = "Scriptable Objects/Base Unit Stat Data", order = int.MaxValue)]
public class BaseUnitStat : ScriptableObject
{
    [SerializeField] private string unitName;
    [SerializeField] private Enum.FoodType type;
    [SerializeField] private int baseHP;
    [SerializeField] private int baseAttack;
    [SerializeField] private int baseDefense;
    [SerializeField] private int baseAccuracy;
    [SerializeField] private int baseLuck;
    [SerializeField] private float baseSpeed;
    [SerializeField] private int baseTier;
    [SerializeField] private BaseSkill firstAttack;
    [SerializeField] private BaseSkill secondAttack;
    [SerializeField] private BaseSkill thirdAttack;
    [SerializeField] private BaseSkill fourthAttack;

    public string UnitName { get { return unitName; } }
    public Enum.FoodType Type { get { return type; } }
    public int BaseHP { get { return baseHP; } }
    public int BaseAttack { get { return baseAttack; } }
    public int BaseDefense { get { return baseDefense; } }
    public int BaseAccuracy { get { return baseAccuracy; } }
    public int BaseLuck { get { return baseLuck; } }
    public float BaseSpeed { get { return baseSpeed; } }
    public int BaseTier { get { return baseTier; } }
    public BaseSkill FirstAttack { get { return firstAttack; } }
    public BaseSkill SecondAttack { get { return secondAttack; } }
    public BaseSkill ThirdAttack { get { return thirdAttack; } }
    public BaseSkill FourthAttack { get { return fourthAttack; } }

    public void SetStat()
    {
        //Later Set These Base Stats from Server or Cloud.
    }
}
