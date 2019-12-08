using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    public bool doneSlicr;
    public AudioClip[] audioClips;
    AudioSource speaker;
    bool explosive, touchy,end, nozzle;
    public static int counter = 0;
    

    void Start()
    {
        speaker = GetComponent<AudioSource>();

    }

    
    void Update()
    {
        //tell if the speech has been toggled off
        speaker.volume = PlayerPrefs.GetInt("Disabled");
        

        //cycle through audio clips
        if(!speaker.isPlaying && counter < 4 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            //Debug.Log(counter);
            speaker.PlayOneShot(audioClips[counter]);
            counter++;
            return;
        }

        //if go to "cura" before cycle is finished, jump forward
        if(SceneManager.GetActiveScene().buildIndex == 2 && counter < 4)
        {
            counter = 4;
        }
        //pause the cycle until we get to the "cura" scene 
        if (SceneManager.GetActiveScene().buildIndex == 2 && !speaker.isPlaying && counter < 6  )
        {
            speaker.PlayOneShot(audioClips[counter]);
            counter++;

        }

        //continue on when the player gets back
        if (SceneManager.GetActiveScene().buildIndex == 1 && counter < 7 && doneSlicr   )
        {
            AudioButton(6);
            counter = 7;
        }


        if (!speaker.isPlaying && counter < 8 && SceneManager.GetActiveScene().buildIndex == 1 && doneSlicr)
        {
            speaker.PlayOneShot(audioClips[counter]);
            counter++;
        }
    }
	
    //play a one-off
    public void AudioButton(int i)
    {
        speaker.Stop();
        speaker.PlayOneShot(audioClips[i]);
    }


    //some audio clips that we only want played once

    public void ExplosiveSpools()
    {
        if (!explosive && !speaker.isPlaying)
        {
            AudioButton(8);
            explosive = true;
        }
    }

    public void CantTouchThis()
    {
        if (!touchy && !speaker.isPlaying)
        {
            AudioButton(14);
            touchy = true;
        }
    }

    public void EndPrint()
    {
        if (!end)
        {
            AudioButton(12);
            end = true;
        }
    }

    public void Nozzle()
    {
        if (!nozzle)
        {
            AudioButton(13);
            nozzle = true;
        }
    }
}
