using System.Collections.Generic;
using UnityEngine;

public class Inventario2 : MonoBehaviour
{
    public static Inventario2 Instance;
    public List<Items> inventarioPruebas = new List<Items>();

    public Transform inventorySpawn;

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
    public void CollectItems(Items item)
    {
        Items clone = Instantiate(item, inventorySpawn.position, inventorySpawn.rotation);
        inventarioPruebas.Add(clone);
        clone.gameObject.AddComponent<PhyssicalInventoryu>();
        clone.gameObject.AddComponent<Rigidbody>();
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        clone.transform.localScale = clone.transform.localScale * 3;

        if (clone.itemType == Items.ItemType.Key)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
        else if (clone.itemType == Items.ItemType.Battery)
        {
            clone.transform.Rotate(-90f, 0f, 0f);
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
        }
        Destroy(item.gameObject);
    }

    public bool HasKey(string keyID)
    {
        foreach (Items item in inventarioPruebas)
        {
            if (item.itemType == Items.ItemType.Key && ((KeyItem)item).doorID == keyID)
            {
                return true;
            }
        }
        return false;
    }
    public void RemoveItem(Items item)
    {
        inventarioPruebas.Remove(item);

    }


}
