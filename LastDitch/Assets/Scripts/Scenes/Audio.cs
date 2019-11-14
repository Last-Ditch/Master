using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{

    public AudioClip[] audioClips;
    AudioSource speaker;
    bool explosive;
    public static int counter = 0;
    

    void Start()
    {
        speaker = GetComponent<AudioSource>();

    }

    
    void Update()
    {
        speaker.volume = PlayerPrefs.GetInt("Disabled");
        Debug.Log(counter);


        if(!speaker.isPlaying && counter < 4 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            speaker.PlayOneShot(audioClips[counter]);
            counter++;
            return;
        }

        if(SceneManager.GetActiveScene().buildIndex == 2 && counter < 4)
        {
            counter = 4;
        }

        if (!speaker.isPlaying && counter < 6 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            
            speaker.PlayOneShot(audioClips[counter]);
            counter++;

        }

        if(!speaker.isPlaying && counter < 8 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            speaker.PlayOneShot(audioClips[counter]);
            counter++;
        }

        //Debug.Log(counter);
    }
	
    public void AudioButton(int i)
    {
        speaker.Stop();
        speaker.PlayOneShot(audioClips[i]);
    }

    public void ExplosiveSpools()
    {
        if(!explosive && !speaker.isPlaying)
        {
            AudioButton(8);
            explosive = true;
        }
    }
}
