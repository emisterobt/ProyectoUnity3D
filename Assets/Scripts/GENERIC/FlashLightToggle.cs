using UnityEngine;

public class FlashLightToggle : MonoBehaviour
{
    private Light flashLight;
    [SerializeField]
    public bool isOn;

    public bool isColliding;

    private BoxCollider lampCollider;

    public GameObject luzApoyo;

    
    void Start()
    {
        flashLight = transform.GetChild(0).GetComponent<Light>();
        lampCollider = transform.GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;

        }
            if (isOn)
            {
                flashLight.enabled = true;
                luzApoyo.SetActive(true);
            }

            if (!isOn)
            {
                flashLight.enabled = false;
                luzApoyo.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Walls") && isOn)
        {
            isOn = false;
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.CompareTag("Walls") && isColliding)
        {
            isColliding = false;
            isOn = true;
        }
    }

}
