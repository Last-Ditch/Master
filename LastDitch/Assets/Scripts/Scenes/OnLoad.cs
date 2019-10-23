using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoad : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject screenCamera;
    public GameObject player;

    private Vector3 outPos = new Vector3(-34.5f, 7.9f, 36.5f);

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController script;
    public CameraLerp cameraScript;

    void Start()
    {
        //PlayerPrefs.SetInt("inMenu", 1);

        if (PlayerPrefs.GetInt("inMenu") == 1)
        {
            //set camera at screen pos
            player.transform.position = outPos;
            player.transform.rotation = Quaternion.Euler(0,-22f,0);
            mainCamera.transform.position = screenCamera.transform.position;
            mainCamera.transform.rotation = screenCamera.transform.rotation;
            script.enabled = false;

            PlayerPrefs.SetInt("inMenu", 0);
            cameraScript.movingCam = true;
        }

        
    }
}
