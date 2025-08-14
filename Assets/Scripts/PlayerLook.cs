using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Transform padre;
    private float moX;
    private float moY;
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    private PlayerMove pM;

    private float rotX = 0;

    [Header("Blob Movement")]
    [SerializeField] private float walkingSpeed = 1f;

    [SerializeField, Range(0, 0.1f)] private float walkingAmplitude = 0.015f; // Que tanto se mueve hacia los lados al caminar
    [SerializeField, Range(0, 0.1f)] private float runningAmplitude = 0.015f; // Que tanto se mueve hacia los lados al correr
    [SerializeField, Range(0, 15)] private float walkingFrequency = 10.0f; // La frecuencia con la que se mueve al caminar
    [SerializeField, Range(10, 20)] private float runningFrequency = 18f; // La frecuencia con la que se mueve al correr
    [SerializeField] private float resetPosSpeed = 3.0f; // Cuando dejas de moverte que regrese al centro

    private Vector3 startPos;

    private Animator animator;


    private void OnEnable()
    {
        animator = padre.GetComponent<Animator>();
        Destroy(animator );
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        padre = transform.parent;
        pM = padre.GetComponent<PlayerMove>();
        startPos = transform.localPosition;
    }

    private void Update()
    {
        RotateCamera();
        BlobMove();
        ResetPosition();
    }

    private void RotateCamera()
    {
        moX = Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        padre.Rotate(0, moX, 0);

        moY = Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
        rotX -= moY;
        rotX = Mathf.Clamp(rotX, -90, 90);
        transform.localRotation = Quaternion.Euler(rotX, 0, 0);
    }
    private void BlobMove()
    {
        if (pM.movX == 0 && pM.movZ == 0) return;

        bool isMovingBackwardOrSideways = (pM.movX > 0 || pM.movZ < 0);
        bool isMovingForward = !isMovingBackwardOrSideways;

        if (isMovingBackwardOrSideways)
        {
            transform.localPosition += FootStepMotion();
        }
        else if (isMovingForward && pM.isSprinting)
        {
            transform.localPosition += RunningFootStepMotion();
        }
        else
        {
            transform.localPosition += FootStepMotion();
        }
    }


    private void ResetPosition()
    {
        if (!pM.isCrouching)
        {
            if (transform.localPosition == startPos) return; // Si la camara ya esta en la pos inicial, no hace nada
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, resetPosSpeed * Time.deltaTime);
        }

    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y = Mathf.Sin(Time.time * walkingFrequency) * walkingAmplitude * walkingSpeed;
        pos.x = Mathf.Cos(Time.time * walkingFrequency / 2) * walkingAmplitude * 2 * walkingSpeed;
        return pos;
    }


    private Vector3 RunningFootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y = Mathf.Sin(Time.time * runningFrequency) * runningAmplitude * walkingSpeed;
        pos.x = Mathf.Cos(Time.time * runningFrequency / 2) * runningAmplitude * 2 * walkingSpeed;
        return pos;
    }
}
