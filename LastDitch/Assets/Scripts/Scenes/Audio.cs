using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{

    public AudioClip[] audioClips;
    AudioSource speaker;

    static int counter = 0;


    void Start()
    {
        speaker = GetComponent<AudioSource>();

    }

    
    void Update()
    {
        if(!speaker.isPlaying && counter < 4 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            speaker.PlayOneShot(audioClips[counter]);
            counter++;
            
        }

        if (!speaker.isPlaying && counter < 6 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            
            speaker.PlayOneShot(audioClips[counter]);
            counter++;
        }

        Debug.Log(counter);
    }
	
    public void AudioButton(int i)
    {
        speaker.Stop();
        speaker.PlayOneShot(audioClips[i]);
    }

}
