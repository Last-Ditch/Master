using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimakerMenu : MonoBehaviour
{
    [SerializeField] GameObject[] menus;

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

    }

    public void ResumePrinting()
    {

    }

    public void LowerBuildPlate()
    {

    }

}
