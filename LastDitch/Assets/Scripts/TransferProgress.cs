using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferProgress : MonoBehaviour
{
    public ProgressTracker progressScript;

    private void Start()
    {
        progressScript = GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>();
    }


    public void Material(int i)
    {
        progressScript.Material(i);
    }

    public void LayerHeight(int i)
    {
        progressScript.LayerHeight(i);

    }

    public void Infill(int i)
    {
        progressScript.Infill(i);
    }

    public void Support()
    {
        progressScript.supportsAdded = !progressScript.supportsAdded;
    }
}
