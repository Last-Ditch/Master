using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraLerp : MonoBehaviour
{
    public Transform original;
    public Transform screen;
    bool inMenu;
    public GameObject player;
    private Vector3 outCamPos = new Vector3(-34.5f,14.9f,36.5f);
    private Vector3 outPos = new Vector3(-34.5f, 7.9f, 36.5f);
    public float x;
    public bool movingCam;
    public bool nearLaptop;
    public GameObject hub;                          //Dylan

    float timer = 2f;

    void Update()
    {
        if(PlayerPrefs.GetInt("inMenu") == 1)
        {
            inMenu = true;
            
        }
        else
        {
            inMenu = false;
        }

        if(Input.GetButtonDown("Jump") && nearLaptop)
        {
            hub.SetActive(false);

            //Debug.Log("Jump");
            inMenu = !inMenu;
            if(inMenu)
            {
                PlayerPrefs.SetInt("inMenu", 1);
                timer = 2.5f;
            }
            else
            {
                PlayerPrefs.SetInt("inMenu", 0);
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
            //GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            player.GetComponent<player_controller>().enabled = true;
            player.GetComponentInChildren<player_look>().enabled = true;
        }
    }

    public void CameraIn()
    {
        transform.position = Vector3.Slerp(transform.position, screen.position, Time.deltaTime * 2f);
        transform.rotation = Quaternion.Slerp(transform.rotation, screen.rotation, Time.time * 0.5f);
        //GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
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
