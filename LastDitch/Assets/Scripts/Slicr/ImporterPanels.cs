using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImporterPanels : MonoBehaviour
{
    public int Model;
    public GameObject ImportPanel;
    Selection selectionScript;
    public TransferProgress transferScript;

    void Start()
    {
        selectionScript = GetComponent<Selection>();
        
    }

    public void ImportClicked()
    {
        ImportPanel.SetActive(true);
    }

    public void ImportBackClicked()
    {
        ImportPanel.SetActive(false);
    }

    public void ImportModelClicked(int i)
    {
        Model = i;
        transferScript.ModelChosen(i);
        selectionScript.Import(i);
        ImportPanel.SetActive(false);
    }
}
