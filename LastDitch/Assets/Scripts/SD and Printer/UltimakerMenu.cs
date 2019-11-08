﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimakerMenu : MonoBehaviour
{
    [SerializeField] GameObject[] menus;
    [SerializeField] SlowlyDown revealScript;
    [SerializeField] Button resumeButton;
    [SerializeField] Button printButton;
    //mainMenu, filamentMenu, printingMenu;

    //startPrint, resumeprint, filamentButton, lowerBuildPlate;


    int currentMenu;



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
        if (!revealScript.isPrinting && revealScript.completedSlicr)
        {
            ChangeMenu(2);
            resumeButton.interactable = true;
            printButton.interactable = false;
            revealScript.Printing();
        }
        else
        {
            ChangeMenu(3);
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

}