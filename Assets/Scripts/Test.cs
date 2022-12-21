using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnitManager.Instance.SetBattle();
        UnitManager.Instance.CalculateBattle(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
