using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenuPrincipal : MonoBehaviour
{
    public GameObject configs;
    public void IniciarJuego()
    {
        if(Inventario2.Instance == null)
        {
            Debug.Log("Nada que hacer");
        }
        else if (Inventario2.Instance != null)
        {
            Inventario2.Instance.ClearInventory();
        }

        SceneManager.LoadScene("Juego");
    }

    public void Creditos()
    {


        Debug.Log("Creditos");
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
    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

}
