[System.Serializable]
public class InventoryItem
{
    public string fishName;
    public int amount;

    public InventoryItem(string newFishName)
    {
        fishName = newFishName;
        amount = 1;
    }
}