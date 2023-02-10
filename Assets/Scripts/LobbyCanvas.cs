using UnityEngine;

public class LobbyCanvas : MonoBehaviour
{
    [SerializeField] private GameObject createUI;
    [SerializeField] private GameObject enchantUI;
    [SerializeField] private GameObject adventureUI;
    [SerializeField] private GameObject autoPickUI;
    [SerializeField] private GameObject battleUnitPickUI;
    [SerializeField] private GameObject inventoryUI;

    public void OpenUI(GameObject uiGo)
    {
        if (uiGo.activeInHierarchy)
        {
            uiGo.SetActive(false);
            return;
        }
        createUI.SetActive(false);
        enchantUI.SetActive(false);
        adventureUI.SetActive(false);
        autoPickUI.SetActive(false);
        battleUnitPickUI.SetActive(false);
        uiGo.SetActive(true);
    }
}
