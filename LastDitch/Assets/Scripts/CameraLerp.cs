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

    void Start()
    {
        inMenu = false;
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
            inMenu = !inMenu;
            if (!inMenu)
            {
                //player.transform.LookAt(transform);
                player.transform.position = outPos;
                transform.position = outCamPos;
                
                //transform.position = Vector3.Slerp(transform.position, outPos, Time.deltaTime * 2f);
                //transform.rotation = Quaternion.Slerp(transform.rotation, toGo.rotation, Time.time * 0.5f);
                GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            }
        }
        if (inMenu)
        {
            transform.position = Vector3.Slerp(transform.position, screen.position, Time.deltaTime * 2f);
            transform.rotation = Quaternion.Slerp(transform.rotation, screen.rotation, Time.time * 0.5f);
            GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        }
        //Debug.Log(GetComponentInParent<Transform>().position + "   p");
        Debug.Log(transform.position);
        //x = original.transform.position.x;
    }

    void LerpCamera(Transform current, Transform toGo)
    {
        
    }


   

}
