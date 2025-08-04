using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;

    public bool isHiding;

    public float movX;
    public float movZ;

    [SerializeField]
    private float actualMovSpeed;
    [SerializeField]
    private float sprintMovSpeed;
    [SerializeField]
    private float crouchMovSpeed;
    [SerializeField]
    private float walkMovSpeed;

    private Vector3 velY;

    [SerializeField]
    private float gravity = -9.81f;

    public bool isGrounded;

    [SerializeField]
    private Transform grndChck;
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask whatIsGround;

    public bool isCrouching = false;

    public float crouchPlayerHeight;
    public float basePlayerHeight;

    public bool isSprinting;
    public bool canRun;

    public float camBase;
    public float camCrouch;
    public Camera cameraPlayer;

    public float charConCenterBase;
    public float charConCenterCrouch;

    public SphereCollider soundArea;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        grndChck = transform.GetChild(0);
    }

    private void Start()
    {
        basePlayerHeight = controller.height;
        canRun = true;
    }

    void Update()
    {
        if (Camera.main != null)
        {
            

            isGrounded = Physics.CheckSphere(grndChck.position, radius, whatIsGround);

            velY.y += gravity * Time.deltaTime;
            controller.Move(velY * Time.deltaTime);

            if (isGrounded && velY.y <= 0)
            {
                velY.y = 0;
            }

            movX = Input.GetAxis("Horizontal") * ActualSpeed() * Time.deltaTime;
            movZ = Input.GetAxis("Vertical") * ActualSpeed() * Time.deltaTime;

            Vector3 movimiento = transform.right * movX + transform.forward * movZ;
            controller.Move(movimiento);

            if (Input.GetKeyDown(KeyCode.C))
            {
                Crouch();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Sprint();
            }

            soundArea.radius = isSprinting ? 6 : isCrouching ? 0.5f : 2;

        }


    }

    private float ActualSpeed()
    {
        return isSprinting ? sprintMovSpeed : isCrouching ? crouchMovSpeed : walkMovSpeed;
    }

    private void Crouch()
    {
        isCrouching = !isCrouching;

        if (isCrouching)
        {
            controller.height = crouchPlayerHeight;
            isSprinting = false;
            controller.center = new Vector3(0, charConCenterCrouch, 0);
            cameraPlayer.transform.localPosition = new Vector3(0, camCrouch, 0);
            

        }
        else
        {
            controller.height = basePlayerHeight;
            controller.center = new Vector3(0, charConCenterBase, 0);
            cameraPlayer.transform.localPosition = new Vector3(0, camBase, 0);
            

        }

    }

    private void Sprint()
    {
        if (!isCrouching && canRun)
        {
            isSprinting = !isSprinting;
            
        }
        else if (!canRun)
        {
            isSprinting = false;
            
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(grndChck.position, radius);
        Gizmos.color = Color.yellow;
    }
}
