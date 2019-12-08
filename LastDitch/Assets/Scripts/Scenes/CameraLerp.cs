using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraLerp : MonoBehaviour
{
    public Transform original;
    public Transform screen;
    public static bool inMenu;
    public GameObject player;

    //place to set the player when coming out of the "cura"
    private Vector3 outCamPos = new Vector3(-34.5f,14.9f,36.5f);
    private Vector3 outPos = new Vector3(-34.5f, 7.9f, 36.5f);
    public float x;

    //is the camera moving
    public bool movingCam;
    public bool nearLaptop;
    
    //the UI
    public GameObject hub;                          //Dylan

    float timer = 2f;

    void Update()
    {

        if (Input.GetButtonDown("Jump") && nearLaptop)
        {
            hub.SetActive(false);
            inMenu = !inMenu;
            if(inMenu)
            {
                timer = 2.5f;
            }
            movingCam = true;
        }
        if (inMenu && movingCam)
        {
            CameraIn();
        }

        if (!inMenu && movingCam)
        {
            CameraOut();
        }

    }


    public void CameraOut()
    {
        hub.SetActive(true);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.transform.position = outPos;
        transform.position = Vector3.Slerp(transform.position, outCamPos, Time.deltaTime * 2f);


        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            movingCam = false;
            timer = 2f;
            pause_menu.canPause = true;
            player.GetComponent<player_controller>().enabled = true;
            player.GetComponentInChildren<player_look>().enabled = true;
        }
    }

    public void CameraIn()
    {
        //moves camera in and disables controls
        transform.position = Vector3.Slerp(transform.position, screen.position, Time.deltaTime * 2f);
        transform.rotation = Quaternion.Slerp(transform.rotation, screen.rotation, Time.time * 0.5f);
        pause_menu.canPause = false;
        player.GetComponent<player_controller>().enabled = false;
        player.GetComponentInChildren<player_look>().enabled = false;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            movingCam = false;
            timer = 2f;
            GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().enteredSlicr = true;
            SceneManager.LoadScene(2);
        }
    }

}
