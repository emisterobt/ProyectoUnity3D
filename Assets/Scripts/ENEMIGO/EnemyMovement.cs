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
    private bool detectedPlayer = false;

    private int maxChangesCoord = 5;
    void Start()
    {
        raycast = GetComponent<RaycastEnemigo>();
        deteccionCono = GetComponent<DeteccionCono>();
        iniPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = transform.GetChild(1).GetComponent<Animator>();

        anim.SetBool("IsWalking", true);
        Patrullar();
    }

    void Update()
    {


        if (!deteccionCono.onFOV && !soundDetected && soundEmmiter == null && !raycast.playerInRange || pM.isHiding)
        {
            Patrullar();
            Debug.Log("Patrullando");
            detectedPlayer = false;
        }
        else if (soundDetected == true && !deteccionCono.onFOV)
        {
            ChaseSound();
            Debug.Log("Persiguiendo");

        }
        else if (deteccionCono.onFOV && !pM.isHiding || raycast.playerInRange && !pM.isHiding && !pM.isCrouching)
        {
            ChasePlayer();
            Debug.Log("Escuchando");

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
            soundEmmiter = other.transform;
            soundDetected = true;
        }

        if (other.CompareTag("Player"))
        {
            AudioMngr.Instance.Stop("Correr");
            GameManager.Instance.capturedBy = (GameManager.EnemyType)type; 
            Debug.Log("Atrapo Al Jugador");
            GameManager.Instance.ScreamerAnim();
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Deteccion"))
        {
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
        agent.SetDestination(positionsToMove[coord].position);
        anim.SetBool("IsWalking", true);

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

    public void ChasePlayer()
    {
        if (player != null)
        {
            detectedPlayer = true;
            transform.LookAt(player);
            agent.SetDestination(player.position);
        }
    }

    public void ChaseSound()
    {
        if (soundEmmiter != null)
        {
            detectedPlayer = false;
            transform.LookAt(soundEmmiter.position);
            agent.SetDestination(soundEmmiter.position);
        }
    }

    public void Sonidos()
    {
        switch (type)
        {
            case EnemyType.Xperimento:
                {
                    if (detectedPlayer == true)
                    {
                        AudioMngr.Instance.Play("XperimentoDetect");
                    }
                    break;
                }
            case EnemyType.Guillotina:
                {
                    if (detectedPlayer == true)
                    {
                        AudioMngr.Instance.Play("FantasmaDetect");
                    }
                    break;
                }

        }
    }

    private IEnumerator MantenerPosicion()
    {

        if (anim != null)
        {
            anim.SetBool("IsWalking", false);
            
        }
        agent.isStopped = true;

        yield return new WaitForSeconds(2);
        
        agent.isStopped = false;
        if (anim != null)
        {
            anim.SetBool("IsWalking", true);
        }

    }

    public enum EnemyType
    {
        Xperimento, Guillotina, None
    }

}