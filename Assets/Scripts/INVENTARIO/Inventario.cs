using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario Instance;

    [Header("Inventory Settings")]
    public Transform inventoryLocation;
    public float itemSpacing = 0.5f;

    private List<Items> inventory = new List<Items>();
    private List<GameObject> physicalItems = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public List<Items> GetInventoryItems()
    {
        return new List<Items>(inventory);
    }
    public void PickUpItem(Items item)
    {
        if (item.itemType == Items.ItemType.Key && HasKey(item.itemID))
        {
            Debug.Log("Ya tienes esta llave");
            return;
        }
        inventory.Add(item);
        AddToPhysicalInventory(item);
        item.gameObject.SetActive(false);
    }

    public void RemoveItem(Items item)
    {
        inventory.Remove(item);
        RefreshPhysicalInventory();
    }

    public bool HasKey(string keyID)
    {
        foreach(Items item in inventory)
        {
            if (item.itemType == Items.ItemType.Key && ((KeyItem)item).doorID == keyID)
            {
                return true;
            }
        }
            return false;
    }

    private void AddToPhysicalInventory(Items item)
    {
        Vector3 spawnPosition = inventoryLocation.position + new Vector3(physicalItems.Count * itemSpacing,0,0 );

        GameObject physicalItem = item.CreatePhysicalItem(spawnPosition);
        if (physicalItem != null)
        {
            physicalItems.Add(physicalItem);
        }
    }

    private void RefreshPhysicalInventory()
    {
        foreach (GameObject item in physicalItems)
        {
            if (item != null) Destroy(item);
        }
        physicalItems.Clear();

        for (int i = 0; i < inventory.Count; i++)
        {
            Vector3 spawnPosition = inventoryLocation.position +
                                  new Vector3(i * itemSpacing, 0, 0);

            GameObject physicalItem = inventory[i].CreatePhysicalItem(spawnPosition);
            if (physicalItem != null)
            {
                physicalItems.Add(physicalItem);
            }
        }

    }

}
