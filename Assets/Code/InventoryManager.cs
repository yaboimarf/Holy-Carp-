using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public List<InventoryItem> inventory =
        new List<InventoryItem>();

    public void AddFish(Fish fish)
    {
        foreach (InventoryItem item in inventory)
        {
            if (item.fishName == fish.fishName)
            {
                item.amount++;

                return;
            }
        }

        inventory.Add(
            new InventoryItem(fish.fishName)
        );

    }
}