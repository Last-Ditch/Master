using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpObject : MonoBehaviour
{
    public bool filamentTable, filamentUltimaker, SD_Laptop, SD_Ultimaker;

    public bool lookedAT;
    LookAtPlayer lookScript;

    void Start()
    {

        lookScript = GetComponentInChildren<LookAtPlayer>();
    }


    void Update()
    {
        if (lookedAT)
        {
            lookScript.LAenabled = true;
        }
        else
        {
            lookScript.LAenabled = false;
        }

    }
}
