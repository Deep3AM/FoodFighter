using System.Text;
using UnityEngine;
[CreateAssetMenu(fileName = "Base Skill", menuName = "Scriptable Objects/Base Skill", order = int.MaxValue)]
public class BaseSkill : ScriptableObject
{
    [SerializeField] string skillName;
    [SerializeField] string explain;
    [SerializeField] string valueExpression;
    [SerializeField, Range(1, 4)] int attackRange;

    public string AttackName { get { return skillName; } }
    public string Explain { get { return explain; } }
    public int AttackRange { get { return attackRange; } }
    public int SetValue(Stat stat)
    {
        int result = 0;
        string[] values = valueExpression.Split(" ");
        StringBuilder sb = new StringBuilder();
        foreach (string value in values)
        {
            if (value.Equals("Hardness"))
            {
                sb.Append(stat.Hardness);
            }
            else if (value.Equals("Sweet"))
            {
                sb.Append(stat.Sweet);
            }
            else if (value.Equals("Sour"))
            {
                sb.Append(stat.Sour);
            }
            else if (value.Equals("Salty"))
            {
                sb.Append(stat.Salty);
            }
            else if (value.Equals("Spicy"))
            {
                sb.Append(stat.Spicy);
            }
            else if (value.Equals("Bitter"))
            {
                sb.Append(stat.Bitter);
            }
            else
            {
                sb.Append(value);
            }
        }
        ExpressionEvaluator.Evaluate(sb.ToString(), out result);
        return result;
    }
}
