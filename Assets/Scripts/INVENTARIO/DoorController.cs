using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string requiredKeyID;

    private bool isOpen = false;

    private void Update()
    {
        if (RayoDetect.Instance.canInteract && RayoDetect.Instance.lookingTo == gameObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TryOpen();
            }
        }
        
        if (isOpen)
        {
            Destroy(gameObject);
        }
    }

    private void TryOpen()
    {
        if(!isOpen && Inventario.Instance.HasKey(requiredKeyID))
        {
            isOpen = true;
            RemoveKeyFromInventory();
        }
        else if (!isOpen && !Inventario.Instance.HasKey(requiredKeyID))
        {
            Debug.Log("No tienes la llave");
        }
    }

    private void RemoveKeyFromInventory()
    {
        foreach (Items item in Inventario.Instance.GetInventoryItems())
        {
            if (item.itemType == Items.ItemType.Key && ((KeyItem)item).doorID == requiredKeyID)
            {
                Inventario.Instance.RemoveItem(item);
                break;
            }
        }
    }
}
