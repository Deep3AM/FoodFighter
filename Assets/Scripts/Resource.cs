using TMPro;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private string resourceName;
    [SerializeField] private int amount;
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private TextMeshProUGUI nameText;

    private void Start()
    {
        DisplayAmount();
        DisplayName();
    }

    private void DisplayName()
    {
        nameText.text = resourceName;
    }

    private void DisplayAmount()
    {
        amountText.text = amount.ToString();
    }

    public int GetAmount()
    {
        return amount;
    }

    public string GetName()
    {
        return resourceName;
    }

    public void Up()
    {
        amount++;
        DisplayAmount();
    }
    public void Down()
    {
        if (amount > 0)
            amount--;
        DisplayAmount();
    }

}
