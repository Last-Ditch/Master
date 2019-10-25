using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_triggers : MonoBehaviour
{
    public GameObject text;
    public bool is_near;

    private void Start()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            is_near = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
             is_near = false;
        }
    }


     void Update()
    {
        if (is_near == true)
        {

            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
    }



}
