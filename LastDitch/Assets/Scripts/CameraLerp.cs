using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    public Transform original;
    public Transform screen;
    bool inMenu;
    public GameObject player;
    private Vector3 outCamPos = new Vector3(-34.5f,14.9f,36.5f);
    private Vector3 outPos = new Vector3(-34.5f, 7.9f, 36.5f);
    public float x;
    bool movingCam;
    public bool nearLaptop;

    float timer = 2f;
    void Start()
    {
        inMenu = false;
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && nearLaptop)
        {
            Debug.Log("Jump");
            inMenu = !inMenu;
            movingCam = true;
        }
        if (inMenu && movingCam)
        {
            transform.position = Vector3.Slerp(transform.position, screen.position, Time.deltaTime * 2f);
            transform.rotation = Quaternion.Slerp(transform.rotation, screen.rotation, Time.time * 0.5f);
            GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        }

        if (!inMenu && movingCam)
        {
            player.transform.position = outPos;
            transform.position = Vector3.Slerp(transform.position, outCamPos, Time.deltaTime * 2f);
            GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;

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

    void LerpCamera(Transform current, Transform toGo)
    {
        
    }



}
