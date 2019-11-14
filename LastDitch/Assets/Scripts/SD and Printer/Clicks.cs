using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicks : MonoBehaviour
{
    Clicks otherClicks;
    public AudioClip[] audioClips;
    AudioSource speaker;


    void Start()
    {
        speaker = GetComponent<AudioSource>();
        otherClicks = GameObject.FindGameObjectWithTag("Manager").GetComponent<Clicks>();
    }


    void Update()
    {

    }

    public void AudioButton(int i)
    {

        speaker.PlayOneShot(audioClips[i]);
    }

    public void SendClick()
    {
        otherClicks.AudioButton(1);
    }

}
