using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraLerpUltimaker : MonoBehaviour
{
    public Transform original;
    public Transform screen;
    public bool inMenu;
    public GameObject player;
    public float x;
    public bool movingCam;
    public bool nearUltimaker;
    public GameObject ultimakerMenu;
    float timer = 2f;

    void Update()
    {

        if(Input.GetButtonDown("Jump") && nearUltimaker)
        {
            inMenu = !inMenu;

            timer = 2.5f;

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
        Cursor.lockState = CursorLockMode.Locked;
        transform.position = Vector3.Slerp(transform.position, original.position, Time.deltaTime * 2f);
        transform.rotation = Quaternion.Slerp(transform.rotation, original.rotation, Time.time * 0.5f);
        
        Cursor.visible = false;


        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            movingCam = false;
            timer = 2f;
            player.GetComponent<player_controller>().enabled = true;
            player.GetComponentInChildren<player_look>().enabled = true;
        }
    }

    public void CameraIn()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        transform.position = Vector3.Slerp(transform.position, screen.position, Time.deltaTime * 2f);
        transform.rotation = Quaternion.Slerp(transform.rotation, screen.rotation, Time.time * 0.5f);
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
        }
    }

}
