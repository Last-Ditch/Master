using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicks : MonoBehaviour
{

    //play UI clicks

    Clicks otherClicks;
    public AudioClip[] audioClips;
    AudioSource speaker;


    void Start()
    {
        speaker = GetComponent<AudioSource>();
        otherClicks = GameObject.FindGameObjectWithTag("Manager").GetComponent<Clicks>();
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
