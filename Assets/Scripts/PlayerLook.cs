using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Transform padre;
    private float moX;
    private float moY;
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    

    private float rotX = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        padre = transform.parent;
    }

    private void Update()
    {
        moX = Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        padre.Rotate(0, moX, 0);
        
        moY = Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
        rotX -= moY;
        rotX = Mathf.Clamp(rotX, -90,90);
        transform.localRotation = Quaternion.Euler(rotX, 0, 0);
        
    }
}
