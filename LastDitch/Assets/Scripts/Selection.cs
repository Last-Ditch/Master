using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    [SerializeField] Material PLA, ABS, TPU, PTE;
    [SerializeField] GameObject[] models;
    [SerializeField] GameObject currentModel, currentObj;
    MeshRenderer[] children;
    GameObject defaultObj;

    int currentMat;
    bool materialPicked;



    public void Import(int i)
    {
        if (currentModel != null)
        {
            currentModel.SetActive(false);
        }
        currentModel = models[i];
        currentModel.SetActive(true);
        currentObj = currentModel.transform.GetChild(0).gameObject;
        currentObj.SetActive(true);
    }

    public void LayerHeight(int i)
    {
        switch (i)
        {
            case 3:
                currentObj.SetActive(false);
                currentObj = currentModel.transform.GetChild(3).gameObject;
                currentObj.SetActive(true);
                if(materialPicked)
                {
                    Material(currentMat);
                }
                break;
            case 2:
                currentObj.SetActive(false);
                currentObj = currentModel.transform.GetChild(2).gameObject;
                currentObj.SetActive(true);
                if (materialPicked)
                {
                    Material(currentMat);
                }
                break;
            case 1:
                currentObj.SetActive(false);
                currentObj = currentModel.transform.GetChild(1).gameObject;
                currentObj.SetActive(true);
                if (materialPicked)
                {
                    Material(currentMat);
                }
                break;
            default:
                currentObj.SetActive(false);
                currentObj = currentModel.transform.GetChild(0).gameObject;
                currentObj.SetActive(true);
                if (materialPicked)
                {
                    Material(currentMat);
                }
                break;
        }
    }

    public void Material(int i)
    {
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

    public void Density(int i)
    {

    }


}
