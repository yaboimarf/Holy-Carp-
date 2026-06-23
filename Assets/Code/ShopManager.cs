using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Money moneyManager;

    public void SellAllFish()
    {
        int totalMoney = 0;

        for (int i = 0; i < inventoryManager.inventory.Count; i++)
        {
            InventoryItem item = inventoryManager.inventory[i];

            totalMoney += item.sellPrice * item.amount;
        }

        moneyManager.AddMoney(totalMoney);
        inventoryManager.inventory.Clear();
    }
    public void SellFish(InventoryItem item)
    {
        moneyManager.money += item.sellPrice * item.amount;

        inventoryManager.inventory.Remove(item);
    }
}