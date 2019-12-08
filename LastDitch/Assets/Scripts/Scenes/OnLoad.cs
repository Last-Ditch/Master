using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoad : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject screenCamera;
    public GameObject player;

    private Vector3 outPos = new Vector3(-34.5f, 7.9f, 36.5f);

    public CameraLerp cameraScript;



    //if the player was in "cura", then put them near the laptop to transition out

    void Awake()
    {

        if (CameraLerp.inMenu)
        {
            //set camera at screen pos
            player.transform.position = outPos;
            player.transform.rotation = Quaternion.Euler(0,-22f,0);
            mainCamera.transform.position = screenCamera.transform.position;
            mainCamera.transform.rotation = screenCamera.transform.rotation;
            player.GetComponent<player_controller>().enabled = false;
            player.GetComponentInChildren<player_look>().enabled = false;

            CameraLerp.inMenu = false;
            cameraScript.movingCam = true;
            player.GetComponent<player_controller>().enabled = true;
            player.GetComponentInChildren<player_look>().enabled = true;
        }

        
    }
}
