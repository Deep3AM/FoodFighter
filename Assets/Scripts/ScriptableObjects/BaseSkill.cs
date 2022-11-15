using UnityEngine;
[CreateAssetMenu(fileName = "Base Skill", menuName = "Scriptable Objects/Base Skill", order = int.MaxValue)]
public class BaseSkill : ScriptableObject
{
    [SerializeField] string attackName;
    [SerializeField] string explain;
    [SerializeField] int value;
    [SerializeField] string valueExpression;

    public string AttackName { get { return attackName; } }
    public string Explain { get { return explain; } }
    public int Value { get { return value; } }
    public void SetValue(int level)
    {
        int result = 0;
        ExpressionEvaluator.Evaluate(valueExpression, out result);
        value = result;
    }
}
