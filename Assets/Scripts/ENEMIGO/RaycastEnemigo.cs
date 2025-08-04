using UnityEngine;

public class RaycastEnemigo : MonoBehaviour
{
    [SerializeField]
    private Transform rayOrigin;

    [SerializeField]
    private float range;
    [SerializeField]
    private LayerMask playerMask;

    [SerializeField]
    private float timeToReset = 5;
    
    public bool changeLoc;
    [SerializeField]
    private float countdown;

    public bool playerInRange;
    void Start()
    {
        rayOrigin = transform.GetChild(0);
    }

    void Update()
    {
        RaycastEnemy();
    }

    public void RaycastEnemy()
    {
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, range))
        {
            if (hit.collider.CompareTag("Deteccion"))
            {
                playerInRange = true;
            }
            else if (hit.collider.CompareTag("Door"))
            {
                if (countdown > 0)
                {
                    countdown -= Time.deltaTime;
                }
                else if (countdown <= 0)
                {
                    changeLoc = true;
                    countdown = timeToReset;
                }
            }
            else
            {
                changeLoc = false;
                playerInRange = false;
                countdown = timeToReset;
            }


        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.purple;
        Gizmos.DrawRay(rayOrigin.position, rayOrigin.forward * range);
    }
}
