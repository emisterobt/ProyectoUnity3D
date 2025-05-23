using UnityEngine;

public abstract class Items : MonoBehaviour
{
    public enum ItemType { Battery, Key }

    public ItemType itemType;

    public string itemID;

    public string itemName;

    public GameObject physicalRepresentation;
    private void Update()
    {
        PickUpItem();
    }
    public void PickUpItem()
    {
        if (RayoDetect.Instance.lookingTo == gameObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Inventario.Instance.PickUpItem(this);
            }
        }


    }
    public abstract void Use();

    public abstract GameObject CreatePhysicalItem(Vector3 position);

}
