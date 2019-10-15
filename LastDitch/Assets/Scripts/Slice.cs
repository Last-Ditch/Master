using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class Slice : MonoBehaviour
{

    public GameObject exportPanel;
    public Slider progressbar;

    bool exporting;

    private void Update()
    {
        if(exporting)
        {
            


        }
    }



    public void Sliced()
    {
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
}
