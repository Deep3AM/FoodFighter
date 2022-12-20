using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class StageMap
{
    [SerializeField] private string regionName;
    [SerializeField] private List<StageInfo> stageInfos = new List<StageInfo>();

    public string RegionName { get { return regionName; } }
    public List<StageInfo> StageInfos { get { return stageInfos; } }
}
public class AdventureUI : MonoBehaviour
{
    [SerializeField] private List<StageMap> stageMaps = new List<StageMap>();
    private List<GameObject> regionButtons = new List<GameObject>();
    [SerializeField] private GameObject pRegionButton;
    private List<GameObject> regionLevelButtons = new List<GameObject>();
    [SerializeField] private GameObject pRegionLevelButton;
    [SerializeField] private Transform regionNumButtonsContent;
    [SerializeField] private Transform regionLevelBackground;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        SetAdventureUI(stageMaps[0]);
    }

    private void Init()
    {
        foreach (GameObject obj in regionButtons)
            Destroy(obj);
        regionButtons.Clear();
        foreach (StageMap stage in stageMaps)
        {
            GameObject tempObject = Instantiate(pRegionButton);
            regionButtons.Add(tempObject);
            Transform temp = tempObject.transform;
            temp.SetParent(regionNumButtonsContent);
            temp.GetComponentInChildren<TextMeshProUGUI>().text = stage.RegionName;
            temp.GetComponent<Button>().onClick.AddListener(() => SetAdventureUI(stage));
        }
    }

    private void SetAdventureUI(StageMap stageMap)
    {
        foreach (GameObject obj in regionLevelButtons)
            Destroy(obj);
        regionLevelButtons.Clear();
        foreach (StageInfo info in stageMap.StageInfos)
        {
            GameObject tempObject = Instantiate(pRegionLevelButton);
            regionLevelButtons.Add(tempObject);
            Transform temp = tempObject.transform;
            temp.SetParent(regionLevelBackground);
            temp.GetComponentInChildren<TextMeshProUGUI>().text = info.MapLevel.ToString();
            temp.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("MapGenerator"));
        }
    }
}
