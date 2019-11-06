using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimaker : MonoBehaviour
{

    CameraLerpUltimaker script;

    void Start()
    {
        script = GetComponentInChildren<CameraLerpUltimaker>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ultimaker")
        {
            script.nearUltimaker = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ultimaker")
        {
            script.nearUltimaker = false;
        }
    }
}
