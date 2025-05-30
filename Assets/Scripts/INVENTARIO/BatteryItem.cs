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
        }
    }


}