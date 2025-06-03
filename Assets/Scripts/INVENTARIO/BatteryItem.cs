using UnityEngine;

public class BatteryItem : Items
{
    public float chargeAmount;

    public override void Use()
    {
        GameManager.Instance.AddEnergy(chargeAmount);
    }


}