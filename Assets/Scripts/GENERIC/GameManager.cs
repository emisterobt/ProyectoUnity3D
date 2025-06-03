using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public float fullBattery;
    public bool resetTime = false;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddEnergy(float amount)
    {
        fullBattery += amount;
        if (fullBattery > 3)
        {
            fullBattery = 3;
        }
        resetTime = true;
    }

}
