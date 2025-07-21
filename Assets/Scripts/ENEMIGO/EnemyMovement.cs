using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 iniPos;

    private DeteccionCono deteccionCono;

    private NavMeshAgent agent;

    [SerializeField]
    private Transform player;
    [SerializeField]
    private PlayerMove pM;

    private bool detect;
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private Transform[] positionsToMove;

    public int coord = 0;
    void Start()
    {
        deteccionCono = GetComponent<DeteccionCono>();
        iniPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        detect = Physics.CheckSphere(transform.position, radius,mask);

        if (Vector3.Distance(transform.position, positionsToMove[coord].position) < .4f)
        {
            coord = Random.Range(0,positionsToMove.Length);
            Debug.Log(coord);
            if (coord >= positionsToMove.Length)
            {
                coord = 0;
            }          
        }

        if (deteccionCono.onFOV && !pM.isHiding)
        {
            transform.LookAt(player);
            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(positionsToMove[coord].position);
            agent.stoppingDistance = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deteccion"))
        {
            Debug.Log("s");
            transform.LookAt(other.transform.position);
            agent.SetDestination(other.transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.purple;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
