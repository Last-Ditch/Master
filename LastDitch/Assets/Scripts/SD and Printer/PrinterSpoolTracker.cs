using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterSpoolTracker : MonoBehaviour
{
    public bool full;

    public int currentMat, prevMat;

    ProgressTracker progresstrackerScript;
    public UltimakerMenu umenuScript;
    
    void Start()
    {
        progresstrackerScript = GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>();
    }

    
    void Update()
    {
        if(currentMat == progresstrackerScript.MaterialC)
        {
            umenuScript.placedCorrectSpool = true;
            umenuScript.placedSpool = true;
        }
        if(currentMat == 0)
        {
            umenuScript.placedCorrectSpool = false;
            umenuScript.placedSpool = false;
        }
        if(currentMat != 0 && currentMat != progresstrackerScript.MaterialC)
        {
            umenuScript.placedCorrectSpool = false;
            umenuScript.placedSpool = true;
        }
    }
	
}
