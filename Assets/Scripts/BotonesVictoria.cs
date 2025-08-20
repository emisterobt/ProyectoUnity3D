using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesVictoria : MonoBehaviour
{
    private void Start()
    {
        AudioMngr.Instance.Play("Victoria");
    }
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}
