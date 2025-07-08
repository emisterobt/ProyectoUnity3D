using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string requiredKeyID;
    private Animator doorAnim;
    public bool isOpen = false;

    [SerializeField]
    private bool requiresKey;

    private void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && RayoDetect.Instance.lookingTo == this.gameObject && !isOpen)
        {
            TryOpen();
        }
        else if (Input.GetKeyDown(KeyCode.E) && RayoDetect.Instance.lookingTo == this.gameObject && isOpen)
        {
            isOpen = false;
            doorAnim.SetTrigger("Cerrar");
        }
    }

    private void TryOpen()
    {
        if (!requiresKey)
        {
            isOpen = true;
            doorAnim.SetTrigger("Abrir");
        }
        else if (requiresKey && !isOpen && Inventario2.Instance.HasKey(requiredKeyID))
        {
            isOpen = true;
            doorAnim.SetTrigger("Abrir");
        }
    }

}