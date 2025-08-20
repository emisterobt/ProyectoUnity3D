using UnityEngine;

public class CheatCode : MonoBehaviour
{
    public static CheatCode Instance;

    [SerializeField]
    private bool isCheatingAllowed;

    
    public bool isImmortal;
    public bool infiniteLight;
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
    void Start()
    {
        isImmortal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCheatingAllowed)
        {
            return;
        }
        else if (isCheatingAllowed)
        {
            if (Input.GetKeyUp(KeyCode.I))
            {
                isImmortal = !isImmortal;
            }

            if (Input.GetKeyUp(KeyCode.L))
            {
                infiniteLight = !infiniteLight;
            }
        }
    }
}
