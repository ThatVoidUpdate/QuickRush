using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
    public Sprite[] AnimationFrames;
    public float SecondsPerFrame;

    private SpriteRenderer renderer;

    private float CurrentTime;
    private int CurrentFrame;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
        if (CurrentTime > SecondsPerFrame)
        {
            CurrentFrame = (CurrentFrame + 1) % AnimationFrames.Length;
            renderer.sprite = AnimationFrames[CurrentFrame];
            CurrentTime -= SecondsPerFrame;
        }
    }
}
