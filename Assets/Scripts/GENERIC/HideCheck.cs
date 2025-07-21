using UnityEngine;

public class HideCheck : MonoBehaviour
{
    [SerializeField]
    private FlashLightToggle flToggle;
    private PlayerMove playerMove;
    [SerializeField]
    private Transform player;


    [SerializeField]
    private bool canHide;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMove = player.GetComponent<PlayerMove>();
        flToggle = FindFirstObjectByType<FlashLightToggle>();
    }

    private void Update()
    {
        if (flToggle.isOn)
        {
            canHide = false;
        }
        else
        {
            canHide = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && !canHide)
        {
            playerMove.isHiding = false;
        }
        else if (other.CompareTag("Player") && canHide)
        {
            playerMove.isHiding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMove.isHiding = false;
        }
    }
}
