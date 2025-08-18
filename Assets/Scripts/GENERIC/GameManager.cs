using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public float fullBattery;
    public bool resetTime = false;

    public EnemyType capturedBy;


    public void OnSceneLoaded()
    {
        ScreamerAnim();
    }
    private void Awake()
    {
        if (Instance == null)
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
    public void ScreamerAnim()
    {
        switch (capturedBy)
        {
            case EnemyType.Guillotina:
                AudioMngr.Instance.Stop("Fantasma2");
                SceneManager.LoadScene("EscenaMuerte");
                break;
            case EnemyType.Xperimento:
                SceneManager.LoadScene("XPerimentoJumpscare");
                break;
            case EnemyType.None:
                break;
        }
    }
    public enum EnemyType
    {
        Xperimento, Guillotina, None
    }
}