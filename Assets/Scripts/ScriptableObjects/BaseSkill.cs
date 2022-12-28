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
    public int SetValue(int level)
    {
        int result = 10;
        ExpressionEvaluator.Evaluate(string.Format(valueExpression, level), out result);
        return result;
    }
}
