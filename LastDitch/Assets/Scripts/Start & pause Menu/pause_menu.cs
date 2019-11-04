using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_menu : MonoBehaviour
{

    public static bool paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    void pause()
    {

    }

    void resume()
    {

    }

}
