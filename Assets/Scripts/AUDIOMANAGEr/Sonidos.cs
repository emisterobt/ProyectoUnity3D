using UnityEngine;

[System.Serializable]
public class Sonidos
{
    public string nombreAudio;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volumen;

    public bool loop;

    [HideInInspector]
    public AudioSource audioSource;
}

