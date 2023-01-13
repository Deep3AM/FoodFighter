using TMPro;
using UnityEngine;

public class SellTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [HideInInspector] public float currentTime = 0;
    int totalSoldNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = (float)ES3.Load("currentTime", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = ((int)currentTime).ToString();
        if (currentTime > 15)
        {
            totalSoldNum++;
            currentTime = 0;
            Debug.Log(totalSoldNum);
        }
    }

    private void OnApplicationQuit()
    {
        ES3.Save("currentTime", currentTime);
    }
}
