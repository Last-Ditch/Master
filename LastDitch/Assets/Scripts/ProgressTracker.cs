using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ProgressTracker : MonoBehaviour
{
    public bool sliced, sdIn;
    public bool MatPicked, LHPicked, InfillPicked;
    public int MaterialC, LayerHeightC, InfillC;
    public Material PLA, ABS, TPU, PTE;

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
        if (sliced && sdIn)
        {
            switch (MaterialC)
            {
                case 4:
                    GameObject.FindGameObjectWithTag("Print").GetComponent<MeshRenderer>().material = PTE;
                    break;
                case 3:
                    GameObject.FindGameObjectWithTag("Print").GetComponent<MeshRenderer>().material = TPU;
                    break;
                case 2:
                    GameObject.FindGameObjectWithTag("Print").GetComponent<MeshRenderer>().material = ABS;
                    break;
                case 1:
                    GameObject.FindGameObjectWithTag("Print").GetComponent<MeshRenderer>().material = PLA;
                    break;
                default:
                    GameObject.FindGameObjectWithTag("Print").GetComponent<MeshRenderer>().material = PLA;
                    break;
            }
            GameObject.FindGameObjectWithTag("Print").GetComponent<MeshRenderer>().enabled = true;
        }
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

}