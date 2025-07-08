using UnityEngine;
using System.Collections;

public class RandomizarMonitor : MonoBehaviour
{
    public float toggleInterval = 5f;
    public float activationProbability = 0.2f;
    public GameObject screen;
    public Light screenLight;
    public float onIntensity = 0.1f;
    public float offIntensity = 0f;

    void Start()
    {
        toggleInterval = 5f;
        StartCoroutine(ToggleObjects());
    }

    IEnumerator ToggleObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(toggleInterval);
            bool shouldActivate = Random.value <= activationProbability;

            if (screen != null)
                screen.SetActive(shouldActivate);

            if (screenLight != null)
                screenLight.intensity = shouldActivate ? onIntensity : offIntensity;
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}
