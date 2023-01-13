using UnityEngine;
[CreateAssetMenu(fileName = "Base Unit Stat Data", menuName = "Scriptable Objects/Base Unit Stat Data", order = int.MaxValue)]
public class BaseUnitStat : ScriptableObject
{
    [SerializeField] private string unitName;
    [SerializeField] private Enum.FoodType type;
    [SerializeField] private int baseHardness;
    [SerializeField] private int baseSpicy;
    [SerializeField] private int baseSweet;
    [SerializeField] private int baseSour;
    [SerializeField] private float baseSalty;
    [SerializeField] private int baseBitter;
    [SerializeField] private int baseTier;
    [SerializeField] private BaseSkill firstAttack;
    [SerializeField] private BaseSkill secondAttack;
    [SerializeField] private BaseSkill thirdAttack;
    [SerializeField] private BaseSkill fourthAttack;

    public string UnitName { get { return unitName; } }
    public Enum.FoodType Type { get { return type; } }
    public int BaseHardnessLevel { get { return baseHardness; } }
    public int BaseSpicyLevel { get { return baseSpicy; } }
    public int BaseSweetLevel { get { return baseSweet; } }
    public int BaseSourLevel { get { return baseSour; } }
    public float BaseSaltyLevel { get { return baseSalty; } }
    public int BaseBitterLevel { get { return baseBitter; } }
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
