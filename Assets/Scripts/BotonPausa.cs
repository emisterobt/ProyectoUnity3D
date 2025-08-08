using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonPausa : MonoBehaviour
{
    public TextMeshProUGUI boton;

    private bool isPaused;

    private void Start()
    {
        boton.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            boton.enabled = true;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            boton.enabled = false;
            isPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void RegresarAMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}
