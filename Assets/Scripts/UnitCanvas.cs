using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnitCanvas : MonoBehaviour
{
    [SerializeField] private Transform homeUnit;
    [SerializeField] private Transform awayUnit;
    [SerializeField] private UnitUI unitUIPrefab;
    [SerializeField] private TextMeshProUGUI phaseDebugText;
    [SerializeField] private GameObject scoreDebugUI;
    [SerializeField] private TextMeshProUGUI scoreDebugUIText;
    [SerializeField] private Button scoreDebugUIYesButton;
    [SerializeField] private Button scoreDebugUINoButton;
    [SerializeField] private GameObject continueLastPhaseUI;
    [SerializeField] private Button continueLastPhaseUIYesButton;
    [SerializeField] private Button continueLastPhaseUINoButton;

    public void SetUnitUICanvas(List<Unit> home, List<Unit> away)
    {
        foreach (Unit h in home)
        {
            UnitUI unitUI = Instantiate(unitUIPrefab);
            unitUI.SetUnitUI(h);
            unitUI.transform.SetParent(homeUnit);
            BattleUnitManager.Instance.unitAndUnitUI.TryAdd(h, unitUI);
        }
        foreach (Unit a in away)
        {
            UnitUI unitUI = Instantiate(unitUIPrefab);
            unitUI.SetUnitUI(a);
            unitUI.transform.SetParent(awayUnit);
            BattleUnitManager.Instance.unitAndUnitUI.TryAdd(a, unitUI);
        }
    }

    public void SetPhaseDebugText(int phaseNum)
    {
        if (phaseNum == 1)
        {
            phaseDebugText.text = "Preventive Attack";
        }
        else if (phaseNum == 2)
        {
            phaseDebugText.text = "First Attack";
        }
        else if (phaseNum == 3)
        {
            phaseDebugText.text = "Second Attack";
        }
        else if (phaseNum == 4)
        {
            phaseDebugText.text = "Last Dance";
        }
    }

    public void SelectContinueLastPhase()
    {
        continueLastPhaseUI.SetActive(true);
        continueLastPhaseUIYesButton.onClick.AddListener(() =>
        {
            BattleUnitManager.Instance.CalculateBattle(4);
            continueLastPhaseUI.SetActive(false);

        });
        continueLastPhaseUINoButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Lobby");
        });
    }

    public void ShowScoreDebugUINoButton(string s)
    {
        scoreDebugUI.SetActive(true);
        if (s == "Away")
        {
            scoreDebugUIText.text = "You Failed";
            scoreDebugUIYesButton.gameObject.SetActive(false);
            scoreDebugUINoButton.gameObject.SetActive(true);
            scoreDebugUINoButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Lobby");
            });
        }
        else
        {
            scoreDebugUIText.text = "You Successed";
            scoreDebugUIYesButton.gameObject.SetActive(true);
            scoreDebugUIYesButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("BattleDemo");
            });
            scoreDebugUINoButton.gameObject.SetActive(true);
            scoreDebugUINoButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Lobby");
            });
        }
    }
}
