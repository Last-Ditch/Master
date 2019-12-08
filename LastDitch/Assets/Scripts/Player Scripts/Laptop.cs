using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    //checks to see if the player is near the laptop so they can transition to other scene


    CameraLerp script;

    void Start()
    {
        script = GetComponentInChildren<CameraLerp>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Laptop")
        {
            script.nearLaptop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Laptop")
        {
            script.nearLaptop = false;
        }
    }
}
