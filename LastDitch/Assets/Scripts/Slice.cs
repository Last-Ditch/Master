using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class Slice : MonoBehaviour
{

    public GameObject exportPanel;
    public Slider progressbar;
    public ProgressTracker progressScript;
    public GameObject notDone;
    public GameObject Mat;
    public GameObject LH;
    public GameObject ID;

    private void Start()
    {
        progressScript = GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>();
    }


    public void Sliced()
    {
        if(!progressScript.MatPicked || !progressScript.LHPicked || !progressScript.InfillPicked)
        {
            notDone.SetActive(true);
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
            return;
        }
        exportPanel.SetActive(true);
        StartCoroutine(ExportingFile());
    }


    IEnumerator ExportingFile()
    {
        yield return new WaitForSeconds(.5f);
        Debug.Log(progressbar.value);
        progressbar.value +=10;
        if (progressbar.value == 100)
        {
            GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().sliced = true;
            SceneManager.LoadScene(0);
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

}
