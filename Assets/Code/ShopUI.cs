using UnityEngine;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public TMP_Text fishNameText;
    public TMP_Text amountText;
    public TMP_Text priceText;

    private InventoryItem item;
    public ShopManager shopManager;

    public void Setup(InventoryItem inventoryItem)
    {
        item = inventoryItem;

        fishNameText.text = item.fishName;
        amountText.text = item.amount.ToString();
        priceText.text = "€" + item.sellPrice;
    }

    public void Sell()
    {
        shopManager.SellFish(item);
    }
}