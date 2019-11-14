using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioLevels : MonoBehaviour
{

    public Toggle speechToggle;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Disabled") == 1)
        {
            //speechToggle.isOn = true;
        }
        else
        {
            //speechToggle.isOn = false;
        }
    }

    public void SetSpeechEnable()
    {
        Debug.Log(22222);
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
