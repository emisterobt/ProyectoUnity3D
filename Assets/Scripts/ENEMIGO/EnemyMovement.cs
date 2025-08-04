using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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

    private RaycastEnemigo raycast;

    public int coord = 0;
    void Start()
    {
        raycast = GetComponent<RaycastEnemigo>();
        deteccionCono = GetComponent<DeteccionCono>();
        iniPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        detect = Physics.CheckSphere(transform.position, radius,mask);
        if (!deteccionCono.onFOV && soundDetected == false && soundEmmiter == null && !raycast.playerInRange || pM.isHiding)
        {
            Patrullar();
        }
        else if (soundDetected == true && !deteccionCono.onFOV)
        {
            transform.LookAt(soundEmmiter.position);
            agent.SetDestination(soundEmmiter.position);
        }
        else if (deteccionCono.onFOV && !pM.isHiding || raycast.playerInRange && !pM.isHiding && !pM.isCrouching)
        {
            transform.LookAt(player);
            agent.SetDestination(player.position);
        }

        if (raycast.changeLoc)
        {
            transform.position = iniPos;
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

        if (other.CompareTag("Player"))
        {
            Debug.Log("Atrapo Al Jugador");
            SceneManager.LoadScene("EscenaMuerte");
            Cursor.lockState = CursorLockMode.None;
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
        if (Vector3.Distance(transform.position, positionsToMove[coord].position) < .4f || raycast.changeLoc)
        {
            coord = Random.Range(0, positionsToMove.Length);
            if (coord >= positionsToMove.Length)
            {
                coord = 0;
            }
        }
    }
}
