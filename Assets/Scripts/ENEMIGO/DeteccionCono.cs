using UnityEngine;

public class DeteccionCono : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    Vector3 v = Vector3.zero;
    float distance = 0.0f;

    public float radius = 0.0f;

    private float dot = 0.0f;

    public float fov = 30.0f;
    private float dotFov = 0.0f;

    
    public bool onFOV = false;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if ((distance <= radius * radius) && (dot >= dotFov))
        {
            onFOV = true;
        }
        else
        {
            onFOV=false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);

        v = target.position - transform.position;
        distance = v.sqrMagnitude;


        v.Normalize();

        dotFov = Mathf.Cos(fov * 0.5f * Mathf.Deg2Rad);
        dot = Vector3.Dot(transform.forward, v);

        if ((distance <= radius * radius) && (dot >= dotFov))
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawLine(transform.position, target.position);

    }
}
