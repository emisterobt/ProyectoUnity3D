using UnityEngine;

public class InteraccionInventario : MonoBehaviour
{
    public Camera camRenderTexture;
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        camRenderTexture.gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camRenderTexture.gameObject.SetActive(false);

    }
}
