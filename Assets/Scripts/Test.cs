using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BattleUnitManager.Instance.InitBattleUnits();
        BattleUnitManager.Instance.InitEnemy();
        BattleUnitManager.Instance.SetBattle();
        BattleUnitManager.Instance.CalculateBattle(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
