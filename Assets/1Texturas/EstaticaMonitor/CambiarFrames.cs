using UnityEngine;

public class FrameAnimator : MonoBehaviour
{
    public Texture[] frames;        
    public float frameRate = 10f;     
    private Renderer rend;
    private int currentFrame;
    private float timer;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (frames.Length == 0) return;

        timer += Time.deltaTime;
        if (timer >= 1f / frameRate)
        {
            currentFrame = (currentFrame + 1) % frames.Length;
            rend.material.mainTexture = frames[currentFrame];
            timer = 0f;
        }
    }
}
