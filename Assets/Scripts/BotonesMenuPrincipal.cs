using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenuPrincipal : MonoBehaviour
{

    public void IniciarJuego()
    {
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
