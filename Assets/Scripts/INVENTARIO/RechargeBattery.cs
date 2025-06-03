using UnityEngine;

public class RechargeBattery : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        Items item = other.gameObject.GetComponent<Items>();

        if (item.itemType == Items.ItemType.Battery && GameManager.Instance.fullBattery < 3)
        {
            item.Use();
            Inventario2.Instance.RemoveItem(item);
            Destroy(other.gameObject);
        }
    }

}
