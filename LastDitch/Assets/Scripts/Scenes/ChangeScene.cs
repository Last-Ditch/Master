using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{


    public void ChangeScenes(int index)
    {
        if(index == 0)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            AudioListener.pause = false;
            Audio.counter = 0;
        }
        SceneManager.LoadScene(index);
    }
}
