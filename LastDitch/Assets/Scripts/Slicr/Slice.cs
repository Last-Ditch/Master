using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class Slice : MonoBehaviour
{
    public ImporterPanels ImporterPanelsScript;
    public bool supportsAdded;
    public GameObject exportPanel;
    public Slider progressbar;
    public ProgressTracker progressScript;
    public GameObject notDone;
    public GameObject Mat;
    public GameObject LH;
    public GameObject ID;
    public GameObject SA;
    public GameObject MP;

    private void Start()
    {
        progressScript = GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>();
    }


    public void Sliced()
    {
        Debug.Log(ImporterPanelsScript.Model);
        if(!progressScript.MatPicked || !progressScript.LHPicked || !progressScript.InfillPicked || !progressScript.modelPicked || (ImporterPanelsScript.Model == 2 && !supportsAdded) || (ImporterPanelsScript.Model == 3 && !supportsAdded) || (ImporterPanelsScript.Model == 4 && !supportsAdded))
        {
            notDone.SetActive(true);
            if(!progressScript.modelPicked)
            {
                MP.SetActive(true);
            }
            if(!progressScript.MatPicked)
            {
                Mat.SetActive(true);
            }
            if(!progressScript.LHPicked)
            {
                LH.SetActive(true);
            }
            if(!progressScript.InfillPicked)
            {
                ID.SetActive(true);
            }
            if ((ImporterPanelsScript.Model == 2 && !supportsAdded) || (ImporterPanelsScript.Model == 3 && !supportsAdded) || (ImporterPanelsScript.Model == 4 && !supportsAdded))
            {
                SA.SetActive(true);
            }
            return;
        }
        exportPanel.SetActive(true);
        progressScript.sliced = true;
        StartCoroutine(ExportingFile());
    }


    IEnumerator ExportingFile()
    {
        yield return new WaitForSeconds(.5f);
        progressbar.value +=25;
        if (progressbar.value == 100)
        {
            GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().sliced = true;
            SceneManager.LoadScene(1);
        }
        else
        {
            StartCoroutine(ExportingFile());
        }
    }


    public void TurnOff()
    {
        Mat.SetActive(false);
        LH.SetActive(false);
        ID.SetActive(false);
        notDone.SetActive(false);
    }

    public void Supports()
    {
        supportsAdded = !supportsAdded;
    }
}
