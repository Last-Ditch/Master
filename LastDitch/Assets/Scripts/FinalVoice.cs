using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalVoice : MonoBehaviour
{
    Audio audioS;

    void Start()
    {
        audioS = GameObject.FindGameObjectWithTag("Speaker").GetComponent<Audio>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Interactable")
        {

            audioS.CantTouchThis();
        }
    }

}