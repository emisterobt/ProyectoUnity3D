using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string requiredKeyID;

    public bool isOpen = false;

    private void Update()
    {
        if (isOpen)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.E) && RayoDetect.Instance.lookingTo == this.gameObject)
        {
            TryOpen();
        }
    }

    private void TryOpen()
    {
        if (!isOpen && Inventario2.Instance.HasKey(requiredKeyID))
        {
            isOpen = true;

        }
    }

}