using UnityEngine;

public class LobbyCanvas : MonoBehaviour
{
    [SerializeField] private GameObject createUI;
    [SerializeField] private GameObject enchantUI;
    [SerializeField] private GameObject adventureUI;

    public void OpenUI(GameObject uiGo)
    {
        createUI.SetActive(false);
        enchantUI.SetActive(false);
        adventureUI.SetActive(false);
        uiGo.SetActive(true);
    }
}
