using UnityEngine;

public class RayoDetect : MonoBehaviour
{
    public static RayoDetect Instance;
    public  Transform originPoint;
    public GameObject lookingTo;
    public float range;
    public bool canInteract;
    public bool canPickUp;

    public LayerMask interactables;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        originPoint = transform.parent;
    }

    private void Update()
    {
        RaycastCollision();
    }
    public void RaycastCollision()
    {
        RaycastHit hit;
        if (Physics.Raycast(originPoint.position, originPoint.forward, out hit, range, interactables))
        {
            if (hit.collider.CompareTag("PickUpItem"))
            {
                lookingTo = hit.collider.gameObject;
                canPickUp = true;
            }
            else if (hit.collider.CompareTag("Door"))
            {
                lookingTo = hit.collider.gameObject;
                canInteract = true;
            }
            else
            {
                lookingTo = null;
                canPickUp = false;
                canInteract = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(originPoint.position, originPoint.forward * range);
    }




}
