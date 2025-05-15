using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;

    private float movX;
    private float movZ;

    [SerializeField]
    private float movSpeed;

    private Vector3 velY;

    [SerializeField]
    private float gravity = -9.81f;

    private bool isGrounded;

    [SerializeField]
    private Transform grndChck;
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask whatIsGround;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        grndChck = transform.GetChild(0);
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(grndChck.position, radius, whatIsGround);

        velY.y += gravity * Time.deltaTime;
        controller.Move(velY * Time.deltaTime);

        if(isGrounded && velY.y <= 0)
        {
            velY.y = 0;
        }

        movX = Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;
        movZ = Input.GetAxis("Vertical") * movSpeed * Time.deltaTime;

        Vector3 movimiento = transform.right*movX + transform.forward*movZ;
        controller.Move(movimiento);

    }
}
