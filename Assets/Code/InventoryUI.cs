using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI inventoryText;
    public InventoryManager inventoryManager;

    public void UpdateUI()
    {
        inventoryText.text = "";

        foreach (InventoryItem item in inventoryManager.inventory)
        {
            inventoryText.text +=
                item.fishName +
                " x" +
                item.amount +
                "\n";
        }
    }
}