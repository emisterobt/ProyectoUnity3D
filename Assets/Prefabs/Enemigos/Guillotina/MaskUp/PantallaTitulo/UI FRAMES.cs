using UnityEngine;
using UnityEngine.UI;

public class UI_FRAMES : MonoBehaviour
{
    public Sprite[] frames;           // Aquí van tus 27 frames como Sprites
    public float frameRate = 10f;     // Velocidad en FPS
    private Image image;
    private int currentFrame;
    private float timer;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (frames.Length == 0 || image == null) return;

        timer += Time.deltaTime;
        if (timer >= 1f / frameRate)
        {
            currentFrame = (currentFrame + 1) % frames.Length;
            image.sprite = frames[currentFrame];
            timer = 0f;
        }
    }
}
