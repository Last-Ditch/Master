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

    private void OnTriggerEnter(Collider other)
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


     void OnMouseOver()
    {
        if (is_near == true)
        {

            text.SetActive(true);
        }
    }

     void OnMouseExit()
    {
        text.SetActive(false);
    }

}
