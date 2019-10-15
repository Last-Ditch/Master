using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ProgressTracker : MonoBehaviour
{
    public bool sliced, sdIn;
    public bool MatPicked, MatPLA, MatABS, MatTPU, MatPTE, LHPicked, LH1, LH2, LH3, InfillPicked, IP1, IP2, IP3, IP4, IP5;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Progress");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
       if(sliced && sdIn)
        {
            GameObject.FindGameObjectWithTag("Print").GetComponent<MeshRenderer>().enabled = true;
        }
    }


    public void Material(int i)
    {
        MatPicked = true;
        if (i == 1)
        {
            MatPLA = true;
            MatABS = false;
            MatTPU = false;
            MatPTE = false;
        }
        if (i == 2)
        {
            MatPLA = false;
            MatABS = true;
            MatTPU = false;
            MatPTE = false;
        }
        if (i == 3)
        {
            MatPLA = false;
            MatABS = false;
            MatTPU = true;
            MatPTE = false;
        }
        if (i == 4)
        {
            MatPLA = false;
            MatABS = false;
            MatTPU = false;
            MatPTE = true;
        }
    }

    public void LayerHeight(int i)
    {
        LHPicked = true;
        if (i == 1)
        {
            LH1 = true;
            LH2 = false;
            LH3 = false;
        }
        if (i == 2)
        {
            LH1 = false;
            LH2 = true;
            LH3 = false;
        }
        if (i == 3)
        {
            LH1 = false;
            LH2 = false;
            LH3 = true;
        }

    }

    public void Infill(int i)
    {
        InfillPicked = true;
        if (i == 1)
        {
            IP1 = true;
            IP2 = false;
            IP3 = false;
            IP4 = false;
            IP5 = false;
        }
        if (i == 2)
        {
            IP1 = false;
            IP2 = true;
            IP3 = false;
            IP4 = false;
            IP5 = false;
        }
        if (i == 3)
        {
            IP1 = false;
            IP2 = false;
            IP3 = true;
            IP4 = false;
            IP5 = false;
        }
        if (i == 4)
        {
            IP1 = false;
            IP2 = false;
            IP3 = false;
            IP4 = true;
            IP5 = false;
        }
        if (i == 5)
        {
            IP1 = false;
            IP2 = false;
            IP3 = false;
            IP4 = false;
            IP5 = true;
        }
    }

}