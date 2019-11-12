using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilamentChoice : MonoBehaviour
{
    public int matNo;
    MeshRenderer mRenderer;
    public bool lookedAT;
    LookAtPlayer lookScript;

    void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        lookScript = GetComponentInChildren<LookAtPlayer>();
    }


    void Update()
    {
        if(mRenderer.enabled && lookedAT)
        {
            lookScript.LAenabled = true;
        }
        else
        {
            lookScript.LAenabled = false;
        }

    }
}
