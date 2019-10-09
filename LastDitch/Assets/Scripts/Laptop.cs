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

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
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
