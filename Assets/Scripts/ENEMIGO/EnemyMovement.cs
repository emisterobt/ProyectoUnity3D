using System.Collections;
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

    private Animator anim;

    public int coord = 0;

    public EnemyType type;

    [SerializeField]
    private bool detectedPlayer;

    private int maxChangesCoord = 5;
    void Start()
    {
        raycast = GetComponent<RaycastEnemigo>();
        deteccionCono = GetComponent<DeteccionCono>();
        iniPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        if (anim == null)
        {
            anim = transform.GetChild(1).GetComponent<Animator>();
        }
        anim.SetBool("isWalking", true);
    }
    void Update()
    {
        detect = Physics.CheckSphere(transform.position, radius, mask);
        if (!deteccionCono.onFOV && soundDetected == false && soundEmmiter == null && !raycast.playerInRange || pM.isHiding)
        {
            Patrullar();
            detectedPlayer = false;
        }
        else if (soundDetected == true && !deteccionCono.onFOV)
        {
            transform.LookAt(soundEmmiter.position);
            detectedPlayer = false;
            agent.SetDestination(soundEmmiter.position);
        }
        else if (deteccionCono.onFOV && !pM.isHiding || raycast.playerInRange && !pM.isHiding && !pM.isCrouching)
        {
            transform.LookAt(player);
            detectedPlayer = true;
            agent.SetDestination(player.position);
        }

        Sonidos();

        if (raycast.changeLoc)
        {
            maxChangesCoord--;
            coord = UnityEngine.Random.Range(0, positionsToMove.Length);
            raycast.changeLoc = false;
            if (maxChangesCoord == 0)
            {
                transform.position = iniPos;
                maxChangesCoord = 5;
            }
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
        anim.SetBool("isWalking", true);

        if (Vector3.Distance(transform.position, positionsToMove[coord].position) < .4f || raycast.changeLoc)
        {
            StartCoroutine(MantenerPosicion());
            coord = UnityEngine.Random.Range(0, positionsToMove.Length);
            if (coord >= positionsToMove.Length)
            {
                coord = 0;
            }

        }
    }

    public void Sonidos()
    {
        switch (type)
        {
            case EnemyType.Xperimento:
                {
                    if (detectedPlayer)
                    {
                        AudioMngr.Instance.Play("XperimentoDetect");
                    }
                    break;
                }
            case EnemyType.Guillotina:
                {
                    if (detectedPlayer)
                    {
                        AudioMngr.Instance.Play("FantasmaDetect");
                    }
                    break;
                }

        }
    }

    private IEnumerator MantenerPosicion()
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
        yield return new WaitForSeconds(2);
        agent.isStopped = false;
        anim.SetBool("isWalking", true);

    }

    public enum EnemyType
    {
        Xperimento, Guillotina
    }

}