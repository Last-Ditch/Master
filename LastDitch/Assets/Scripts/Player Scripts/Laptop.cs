using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{

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
