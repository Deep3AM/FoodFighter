using System.Collections.Generic;

public class UnitManager : Singleton<UnitManager>
{
    private List<Unit> units = new List<Unit>();
    private List<Unit> home = new List<Unit>();
    private List<Unit> away = new List<Unit>();

    public void CalculateBattle()
    {

    }
}
