using UnityEngine;

public class AudioMngr : MonoBehaviour
{
    public static AudioMngr Instance;

    [Range(0f, 1f)]
    public float configVolume;

    public Sonidos[] sonidos;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        foreach (Sonidos s in sonidos)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.loop = s.loop;
            s.audioSource.volume = s.volumen;
        }
    }

    private void Start()
    {
        Play("Ambient");
    }

    public void Play(string nombre)
    {
        foreach (Sonidos s in sonidos)
        {
            if (s.nombreAudio == nombre)
            {
                s.audioSource.Play();
                Debug.Log($"Reproduciendo {nombre}");
                return;
            }
        }
    }

    public void Stop(string nombre)
    {
        foreach (Sonidos s in sonidos)
        {
            if (s.nombreAudio == nombre)
            {
                s.audioSource.Stop();
                return;
            }
        }
    }

    public void ActualizarVolumen()
    {
        foreach (Sonidos s in sonidos)
        {
            s.audioSource.volume = configVolume;
        }
    }



}
