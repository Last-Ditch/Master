using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForSupports : MonoBehaviour
{
    ImporterPanels ImporterPanelsScript;
    
    void Start()
    {
        ImporterPanelsScript = GetComponent<ImporterPanels>();
    }

    
    void Update()
    {
        if(ImporterPanelsScript.Model == 2)
        {

        }
    }




}
