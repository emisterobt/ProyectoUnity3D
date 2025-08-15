using UnityEngine;
using UnityEngine.UI;

public class Configuraciones : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    void Start()
    {
        slider.value = AudioMngr.Instance.configVolume;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CambiarVolumen()
    {
        AudioMngr.Instance.configVolume = slider.value;
        Debug.Log("Volumenes = " + (int)(slider.value * 100));
        AudioMngr.Instance.ActualizarVolumen();
    }
}
