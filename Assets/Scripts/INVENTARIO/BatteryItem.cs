using UnityEngine;

public class BatteryItem : Items
{
    public float chargeAmount;

    public override void Use()
    {
        FlashLightBattery flashlight = FindAnyObjectByType<FlashLightBattery>();
        if (flashlight != null)
        {
            flashlight.AddEnergy(chargeAmount);
            DestroyPhysicalRepresentation();
        }
    }

    public override GameObject CreatePhysicalItem(Vector3 position)
    {
        if (physicalRepresentation != null)
        {
            GameObject physicalItem = Instantiate(physicalRepresentation, position, Quaternion.identity);

            physicalItem.GetComponent<PhyssicalInventoryu>().Setup(this);
            return physicalItem;
        }
        return null;
    }

    private void DestroyPhysicalRepresentation()
    {
        Inventario.Instance.RemoveItem(this);
    }

}
