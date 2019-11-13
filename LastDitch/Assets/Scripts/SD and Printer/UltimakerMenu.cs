using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimakerMenu : MonoBehaviour
{
    [SerializeField] GameObject[] menus;
    [SerializeField] SlowlyDown revealScript;
    [SerializeField] Button resumeButton;
    [SerializeField] Button printButton;
    [SerializeField] GameObject printArea;
    //mainMenu, filamentMenu, printingMenu;

    //startPrint, resumeprint, filamentButton, lowerBuildPlate;


    int currentMenu;
    public bool placedSpool, placedCorrectSpool;


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
            if (placedCorrectSpool)
            {
                ChangeMenu(2);
                resumeButton.interactable = true;
                printButton.interactable = false;
                revealScript.Printing();
            }
        }
        else
        {
            ChangeMenu(3);
            return;
        }

        if (!placedSpool)
        {
            ChangeMenu(5);
            return;
        }

        if (!placedCorrectSpool)
        {
            ChangeMenu(6);
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
