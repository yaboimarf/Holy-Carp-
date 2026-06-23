[System.Serializable]
public class InventoryItem
{
    public string fishName;
    public int amount;
    public int sellPrice;

    public InventoryItem(string newFishName, int newSellPrice)
    {
        fishName = newFishName;
        sellPrice = newSellPrice;
        amount = 1;
    }
}