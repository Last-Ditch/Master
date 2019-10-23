using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClick : MonoBehaviour
{
    AudioSource speaker;
    public AudioClip click;
    void Start()
    {
        speaker = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Sound()
    {
        speaker.PlayOneShot(click);
    }
}
