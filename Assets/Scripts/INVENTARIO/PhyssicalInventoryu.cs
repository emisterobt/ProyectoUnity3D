using UnityEngine;

public class PhyssicalInventoryu : MonoBehaviour
{
    private Items item;
    private Camera cam;
    private GameObject camInv;
    Vector3 mousePosition;

    private void Update()
    {
        cam = GameObject.Find("CamaraInventario")?.GetComponent<Camera>();
    }
    public void Setup(Items itemReference)
    {
        item = itemReference;
    }

    private Vector3 GetMousePosition()
    {
        return cam.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePosition();
    }
    private void OnMouseDrag()
    {
        transform.position = cam.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }



}
