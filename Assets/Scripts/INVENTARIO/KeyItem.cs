using UnityEngine;

public class KeyItem : Items
{
    public string doorID;
    public string keyName;

    public override void Use()
    {

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



}
