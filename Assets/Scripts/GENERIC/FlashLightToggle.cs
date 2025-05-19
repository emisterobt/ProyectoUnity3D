using UnityEngine;

public class FlashLightToggle : MonoBehaviour
{
    private Light flashLight;
    [SerializeField]
    public bool isOn;
    
    void Start()
    {
        flashLight = transform.GetChild(0).GetComponent<Light>();
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
            }

            if (!isOn)
            {
                flashLight.enabled = false;
            }
    }
}
