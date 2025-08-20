using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            AudioMngr.Instance.Play("Victoria");
            SceneManager.LoadScene("PantallaVictoria");
        }
    }
}
