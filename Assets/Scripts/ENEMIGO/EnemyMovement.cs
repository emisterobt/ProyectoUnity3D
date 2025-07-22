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
    private bool soundDetected = false;

    [SerializeField]
    private Transform soundEmmiter;

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
        if (!deteccionCono.onFOV && soundDetected == false && soundEmmiter == null)
        {
            Patrullar();
        }
        else if (soundDetected == true && !deteccionCono.onFOV)
        {
            transform.LookAt(soundEmmiter.position);
            agent.SetDestination(soundEmmiter.position);
        }
        else if (deteccionCono.onFOV && !pM.isHiding)
        {
            transform.LookAt(player);
            agent.SetDestination(player.position);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Deteccion"))
        {
            Debug.Log("s");
            soundEmmiter = other.transform;
            soundDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Deteccion"))
        {
            Debug.Log("Out");
            Patrullar();
            soundEmmiter = null;
            soundDetected = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.purple;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    public void Patrullar()
    {
        Debug.Log("Patrol");
        agent.SetDestination(positionsToMove[coord].position);
        if (Vector3.Distance(transform.position, positionsToMove[coord].position) < .4f)
        {
            coord = Random.Range(0, positionsToMove.Length);
            Debug.Log(coord);
            if (coord >= positionsToMove.Length)
            {
                coord = 0;
            }
        }
    }
}
