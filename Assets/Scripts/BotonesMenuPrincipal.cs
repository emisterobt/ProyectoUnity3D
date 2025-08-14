using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenuPrincipal : MonoBehaviour
{

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
        Debug.Log("Configuracion");
    }

    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

}
