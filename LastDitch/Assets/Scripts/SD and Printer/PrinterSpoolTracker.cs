using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterSpoolTracker : MonoBehaviour
{
    public bool full;

    public int currentMat, prevMat, chosenMat;

    ProgressTracker progresstrackerScript;
    public UltimakerMenu umenuScript;
    
    void Start()
    {
        progresstrackerScript = GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>();
    }

    //for finding out if the right filament waas chosen
    void Update()
    {
        chosenMat = progresstrackerScript.MaterialC;

        if (currentMat == chosenMat)
        {
            umenuScript.placedCorrectSpool = true;
            umenuScript.placedSpool = true;
        }
        if(currentMat == 0)
        {
            umenuScript.filamentInserted = false;
            umenuScript.placedCorrectSpool = false;
            umenuScript.placedSpool = false;
        }
        if(currentMat != 0 && currentMat != chosenMat)
        {
            umenuScript.placedCorrectSpool = false;
            umenuScript.placedSpool = true;
        }
    }
	
}
