using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegresarMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ReturnToMenu();
    }

    public void ReturnToMenu()
    {
        StartCoroutine(TimerVolver());
    }

    public IEnumerator TimerVolver()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
