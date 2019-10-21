using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImporterPanels : MonoBehaviour
{

    public GameObject ImportPanel;
    Selection selectionScript;

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
        selectionScript.Import(i);
        ImportPanel.SetActive(false);
    }
}
