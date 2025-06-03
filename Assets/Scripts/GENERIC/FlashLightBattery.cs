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
        GameManager.Instance.fullBattery = batteryLevel;

        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        batteryLevel = GameManager.Instance.fullBattery;

        if (GameManager.Instance.fullBattery > 3)
        {
            GameManager.Instance.fullBattery = 3;
        }

        if (GameManager.Instance.resetTime)
        {
            time = 10;
            timer = 10;
            GameManager.Instance.resetTime = false;
        }

        if(GameManager.Instance.fullBattery == 0)
        {
            onOff.isOn = false;
        }

        if (onOff.isOn)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            GameManager.Instance.fullBattery -= 1;
            timer = time += 5;
        }

        switch (GameManager.Instance.fullBattery)
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


}
