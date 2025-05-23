using UnityEngine;

public class FlashLightBattery : MonoBehaviour
{
    [SerializeField]
    private Light flashLight;

    private Transform fLight;
    private FlashLightToggle onOff;

    [SerializeField]
    private float timer;
    [SerializeField]
    private float time;
    [SerializeField]
    private float batteryLevel;
    [SerializeField]
    private float lightIntensity;

    [SerializeField]
    private float luzIntensidad;

    void Start()
    {
        flashLight = GetComponent<Light>();
        fLight = transform.parent;
        onOff = fLight.GetComponent<FlashLightToggle>();

        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (batteryLevel > 3)
        {
            batteryLevel = 3;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            AddEnergy(3);
        }

        if(batteryLevel == 0)
        {
            onOff.isOn = false;
        }

        if (onOff.isOn)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            batteryLevel -= 1;
            timer = time += 5;
        }

        switch (batteryLevel)
        {
            case 0:
                lightIntensity = 0;
                break;
            case 1:
                lightIntensity = (luzIntensidad * 0.25f);
                break;
            case 2:
                lightIntensity = (luzIntensidad * 0.5f);
                break;
            case 3:
                lightIntensity = luzIntensidad;
                break;
            default:
                Debug.Log("La variable no debe estar en este numero");
                break;
        }

        flashLight.intensity = lightIntensity;

    }

    public void AddEnergy(float chargeAmount)
    {
        if (batteryLevel < 3)
        {
            batteryLevel += chargeAmount;
            time = 10;
            timer = time;
            onOff.isOn = true;
        }
    }
}
