using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonPausa : MonoBehaviour
{
    public GameObject botonRegresar;      
    public GameObject botonConfiguracion; 

    public GameObject configs;

    private bool isPaused;

    private void Start()
    {
        botonRegresar.SetActive(false);
        botonConfiguracion.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            botonRegresar.SetActive(true);
            botonConfiguracion.SetActive(true);
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            botonRegresar.SetActive(false);
            botonConfiguracion.SetActive(false);
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
