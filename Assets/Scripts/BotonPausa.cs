using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.STP;

public class BotonPausa : MonoBehaviour
{
    public TextMeshProUGUI botonRegresar;
    public TextMeshProUGUI botonConfiguracion;

    public GameObject configs;

    private bool isPaused;

    private void Start()
    {
        botonRegresar.enabled = false;
        botonConfiguracion.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            botonRegresar.enabled = true;
            botonConfiguracion.enabled = true;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            botonRegresar.enabled = false;
            botonConfiguracion.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            isPaused = false;
        }
    }

    public void RegresarAMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Configuracion()
    {
        configs.SetActive(true);
        Debug.Log("Configuracion");
    }
    public void CerrarConfig()
    {
        configs.SetActive(false);
    }

}
