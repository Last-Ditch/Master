using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillProgress : MonoBehaviour
{

    //reset game if the player goes to the main menu

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Progress"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Progress"));
        }

        if (GameObject.FindGameObjectWithTag("UI"))
        {
            tutorial.playedAlready = false;
        }
        Audio.counter = 0;
    }
}
