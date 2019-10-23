using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ProgressTracker : MonoBehaviour
{
    public bool sliced, sdIn, supportsAdded;
    public bool MatPicked, LHPicked, InfillPicked;
    public int MaterialC, LayerHeightC, InfillC, ModelPicked;

    private void Start()
    {
        ModelPicked = 1;
    }


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Progress");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }


    public void Material(int i)
    {
        MatPicked = true;
        MaterialC = i;
    }

    public void LayerHeight(int i)
    {
        LHPicked = true;
        LayerHeightC = i;

    }

    public void Infill(int i)
    {
        InfillPicked = true;
        InfillC = i;
    }

    public void Support()
    {
        supportsAdded = !supportsAdded;
    }
}