using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegresarMenu : MonoBehaviour
{
    [SerializeField]
    private float animDuration;
    void Start()
    {
        switch (GameManager.Instance.capturedBy)
        {
            case GameManager.EnemyType.Guillotina:
                animDuration = 7f;
                StartCoroutine(TimeToScream());
                break;
            case GameManager.EnemyType.Xperimento:
                //AudioMngr.Instance.Play("ScreamerXperimento");
                animDuration = 1f;
                break;
        }
        ReturnToMenu();
    }

    public void ReturnToMenu()
    {
        StartCoroutine(TimerVolver());
    }

    public IEnumerator TimerVolver()
    {
        yield return new WaitForSeconds(animDuration);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public IEnumerator TimeToScream()
    {
        yield return new WaitForSeconds(2);
        AudioMngr.Instance.Play("FantasmaDetect");
    }
}
