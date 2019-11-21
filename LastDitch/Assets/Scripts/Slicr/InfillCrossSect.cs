using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfillCrossSect : MonoBehaviour
{
    public GameObject[] Models;

    public Material PLA, ABS, TPU, PTE;

    public GameObject currentModel, currentObj;
    MeshRenderer[] children;
    Transform[] supprtChildren;
    GameObject defaultObj;

    int currentMat, modelNo;
    bool materialPicked, supportsAdded;
    public TransferProgress transferScript;


    public void ChangeInfill(int i)
    {
        if (currentObj == null) { return; }

        currentObj.SetActive(false);
        currentObj = currentModel.transform.GetChild(i + modelNo).gameObject;
        currentObj.SetActive(true);
        if (materialPicked)
        {
            ChangeMaterial(currentMat);
        }

    }

    void Import()
    {
        if (currentModel != null)
        {
            currentModel.SetActive(false);
            currentObj.SetActive(false);
        }
        currentModel = Models[modelNo];
        currentModel.SetActive(true);

    }

    public void SetModel(int i)
    {
        modelNo = i;
        Import();
    }

    public void ChangeMaterial(int i)
    {
        if (currentObj == null) { return; }
        currentMat = i;
        materialPicked = true;
        children = currentObj.GetComponentsInChildren<MeshRenderer>();
        switch (i)
        {
            case 4:
                foreach (MeshRenderer m in children)
                {
                    if (m.GetComponent<MeshRenderer>())
                    {
                        m.GetComponent<MeshRenderer>().material = PTE;
                    }
                }
                break;
            case 3:
                foreach (MeshRenderer m in children)
                {
                    if (m.GetComponent<MeshRenderer>())
                    {
                        m.GetComponent<MeshRenderer>().material = TPU;
                    }
                }
                break;
            case 2:
                foreach (MeshRenderer m in children)
                {
                    if (m.GetComponent<MeshRenderer>())
                    {
                        m.GetComponent<MeshRenderer>().material = ABS;
                    }
                };
                break;
            case 1:
                foreach (MeshRenderer m in children)
                {
                    if (m.GetComponent<MeshRenderer>())
                    {
                        m.GetComponent<MeshRenderer>().material = PLA;
                    }
                };
                break;
            default:
                foreach (MeshRenderer m in children)
                {
                    if (m.GetComponent<MeshRenderer>())
                    {
                        m.GetComponent<MeshRenderer>().material = PLA;
                    }
                }
                break;
        }
    }



}
