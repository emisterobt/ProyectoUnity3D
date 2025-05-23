using UnityEngine;

public class PhyssicalInventoryu : MonoBehaviour
{
    private Items item;

    public void Setup(Items itemReference)
    {
        item = itemReference;
    }

    private void OnMouseDown()
    {
        item.Use();
    }

}
