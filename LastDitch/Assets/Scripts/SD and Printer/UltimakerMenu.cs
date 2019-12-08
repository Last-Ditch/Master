using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimakerMenu : MonoBehaviour
{
    //for moving around the menu on the ultimaker

    public GameObject[] menus;
    public SlowlyDown revealScript;
    public Button resumeButton;
    public Button printButton;
    public GameObject printArea;
    public PrinterSpoolTracker spoolTrackerScript;
    public WipeDownAndGlue wipeScript;



    int currentMenu;
    public bool placedSpool, placedCorrectSpool, filamentInserted;


    public void ChangeMenu(int i)
    {
        if (currentMenu != i)
        {
            Hide(currentMenu);
        }
        currentMenu = i;
        menus[i].SetActive(true);
    }



    public void Hide(int i)
    {
        menus[i].SetActive(false);
    }


    public void StartPrinting()
    {
        if(printAreaFull())
        {
            ChangeMenu(4);
            return;
        }

        if (!revealScript.isPrinting && revealScript.completedSlicr)
        {
            if (filamentInserted && placedCorrectSpool)
            {
                ChangeMenu(2);
                resumeButton.interactable = true;
                printButton.interactable = false;
                wipeScript.canWipe = true;
                //revealScript.Printing();
            }
        }
        else
        {
            ChangeMenu(3);
            return;
        }

        if (!filamentInserted)
        {
            ChangeMenu(5);
            return;
        }

    }

    public void StopPrinting()
    {
        revealScript.StopPrinting();
        ChangeMenu(0);
    }

    public void ResumePrinting()
    {
        if(revealScript.isPrinting)
        {
            revealScript.Printing();
        }
        ChangeMenu(2);
    }

    public void LowerBuildPlate()
    {
        //need more work to do this
    }


    public void Reset()
    {
        resumeButton.interactable = false;
        printButton.interactable = true;
    }

    public void ChangeFilament(int i)
    {
        
        Debug.Log(i);
        if(spoolTrackerScript.currentMat == 0)
        {
            ChangeMenu(5);
            return;
        }
        if(i != spoolTrackerScript.chosenMat)
        {
            ChangeMenu(7);
            return;
        }
        if(i == spoolTrackerScript.chosenMat)
        {
            if(i != spoolTrackerScript.currentMat)
            {
                ChangeMenu(6);
                return;
            }
            ChangeMenu(8);
            GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().insertFilament = true;
            filamentInserted = true;
        }
    }


    bool printAreaFull()
    {
        Transform[] children = printArea.transform.GetComponentsInChildren<Transform>();
        foreach (Transform g in children)
        {
            if (g.gameObject.tag == "Interactable")
            {
                return true;
            }
        }
        return false;
    }
}
