using UnityEngine;
[CreateAssetMenu(fileName = "StageInfo", menuName = "Scriptable Objects/StageInfo", order = int.MaxValue)]
public class StageInfo : ScriptableObject
{
    [SerializeField] private string mapName;
    [SerializeField] private int mapLevel;

    public string MapName { get { return mapName; } }
    public int MapLevel { get { return mapLevel; } }
}
