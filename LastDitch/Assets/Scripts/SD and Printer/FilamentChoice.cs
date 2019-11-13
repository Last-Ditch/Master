using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilamentChoice : MonoBehaviour
{
    public int matNo;
    public MeshRenderer mRenderer;
    public bool lookedAT;
    LookAtPlayer lookScript;

    void Start()
    {
        
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
