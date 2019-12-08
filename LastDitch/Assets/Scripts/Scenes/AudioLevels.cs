using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioLevels : MonoBehaviour
{

    //toggle the voiceover

    public void SetSpeechEnable()
    {
        if(PlayerPrefs.GetInt("Disabled") == 1)
        {
            PlayerPrefs.SetInt("Disabled", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Disabled", 1);
        }
    }

}
