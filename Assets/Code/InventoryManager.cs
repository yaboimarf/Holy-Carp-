using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.BuiltIn.ShaderGraph;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public List<InventoryItem> inventory =
        new List<InventoryItem>();
    public Codex codex;

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
        CheckAllFish();
    }
    private void CheckAllFish()
    {
        Flounder();
        Remora();
        Tuna();
        Beardfish();
        Catfish();
        Olm();
        Carp();
        Goldfish();
        Pike();
    }
    public void Flounder()
    {
        InventoryItem item = inventory.Find(x => x.fishName == "Flounder");

        if (item != null)
        {
            Debug.Log("Flounder caught");
            codex.flounder = true;
            return;            
        }
    }
    public void Remora()
    {
        InventoryItem item = inventory.Find(x => x.fishName == "Remora");
        if (item != null)
        {
            Debug.Log("Remora caught");
            codex.remora = true;
            return;
        }
    }
    public void Tuna()
    {
        InventoryItem item = inventory.Find(x => x.fishName == "Tuna");
        if (item != null)
        {
            Debug.Log("Tuna caught");
            codex.tuna = true;
            return;
        }
    }
    public void Beardfish()
    {
        InventoryItem item = inventory.Find(x => x.fishName == "Beardfish");
        if (item != null)
        {
            Debug.Log("Beardfish caught");
            codex.beardfish = true;
            return;
        }
    }
    public void Catfish()
    {
        InventoryItem item = inventory.Find(x => x.fishName == "Catfish");
        if (item != null)
        {
            Debug.Log("Catfish caught");
            codex.catfish = true;
            return;
        }
    }
    public void Olm()
    {
        InventoryItem item = inventory.Find(x => x.fishName == "Olm");
        if (item != null)
        {
            Debug.Log("Olm caught");
            codex.olm = true;
            return;
        }
    }
    public void Carp()
    {
        InventoryItem item = inventory.Find(x => x.fishName == "Carp");
        if (item != null)
        {
            Debug.Log("Carp caught");
            codex.carp = true;
            return;
        }
    }
    public void Goldfish()
    {
        InventoryItem item = inventory.Find(x => x.fishName == "Goldfish");
        if (item != null)
        {
            Debug.Log("Goldfish caught");
            codex.goldfish = true;
            return;
        }
    }
    public void Pike()
    {
        InventoryItem item = inventory.Find(x => x.fishName == "Pike");
        if (item != null)
        {
            Debug.Log("Pike caught");
            codex.pike = true;
            return;
        }
    }
}