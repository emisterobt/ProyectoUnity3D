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
                animDuration = 9f;
                break;
            case GameManager.EnemyType.Xperimento:
                animDuration = .6f;
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
        SceneManager.LoadScene("MenuPrincipal");
    }
}
