using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Selection : MonoBehaviour
{
    //tracks progress through the "cura" program
    public Material PLA, ABS, TPU, PTE;
    public GameObject[] models, infill;
    public GameObject currentModel, currentObj, currentInfillModel, currentInfillObj;
    MeshRenderer[] children, infillChildren;
    Transform[] supprtChildren;
    GameObject defaultObj;

    Toggle supportUI;
    int currentMat, currentInfillMod;
    bool materialPicked, supportsAdded;
    public TransferProgress transferScript;


    //dont judge me for this
    int[] infillJump = {0,4,8};

    private void Start()
    {
        supportUI = GameObject.FindGameObjectWithTag("SupportUI").GetComponent<Toggle>();

    }


    public void Import(int i)
    {
        if (currentModel != null)
        {
            currentModel.SetActive(false);
            currentObj.SetActive(false);
            currentInfillModel.SetActive(false);
            currentInfillObj.SetActive(false);
        }


        currentModel = models[i];
        currentModel.SetActive(true);
        currentObj = currentModel.transform.GetChild(0).gameObject;
        currentObj.SetActive(true);

        currentInfillModel = infill[i];
        currentInfillModel.SetActive(true);
        currentInfillObj = currentInfillModel.transform.GetChild(0).gameObject;
        currentInfillObj.SetActive(true);

    }

    public void LayerHeight(int i)
    {
        if (currentObj == null) { return; }

        currentObj.SetActive(false);
        supportUI.isOn = false;

        currentObj = currentModel.transform.GetChild(i).gameObject;
        currentObj.SetActive(true);

        currentInfillMod = infillJump[i-1];

        currentInfillObj.SetActive(false);
        currentInfillObj = currentInfillModel.transform.GetChild(currentInfillMod).gameObject;
        currentInfillObj.SetActive(true);



        if (materialPicked)
        {
            Material(currentMat);
        }


    }

    public void Material(int i)
    {
        if(currentObj == null) { return; }
        currentMat = i;
        materialPicked = true;
        children = currentObj.GetComponentsInChildren<MeshRenderer>();
        infillChildren = currentInfillObj.GetComponentsInChildren<MeshRenderer>();
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
                foreach (MeshRenderer m in infillChildren)
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
                foreach (MeshRenderer m in infillChildren)
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
                }
                foreach (MeshRenderer m in infillChildren)
                {
                    if (m.GetComponent<MeshRenderer>())
                    {
                        m.GetComponent<MeshRenderer>().material = ABS;
                    }
                }
                break;
            case 1:
                foreach (MeshRenderer m in children)
                {
                    if (m.GetComponent<MeshRenderer>())
                    {
                        m.GetComponent<MeshRenderer>().material = PLA;
                    }
                }
                foreach (MeshRenderer m in infillChildren)
                {
                    if (m.GetComponent<MeshRenderer>())
                    {
                        m.GetComponent<MeshRenderer>().material = PLA;
                    }
                }
                break;
            default:
                foreach (MeshRenderer m in children)
                {
                    if (m.GetComponent<MeshRenderer>())
                    {
                        m.GetComponent<MeshRenderer>().material = PLA;
                    }
                }
                foreach (MeshRenderer m in infillChildren)
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
        if (currentObj == null) { return; }

        currentInfillObj.SetActive(false);
        currentInfillObj = currentInfillModel.transform.GetChild(currentInfillMod + i).gameObject;
        currentInfillObj.SetActive(true);



        if (materialPicked)
        {
            Material(currentMat);
        }

    }

    public void Supports()
    {
        supportsAdded = !supportsAdded;
        transferScript.Supports();
        if (supportsAdded)
        {
            supprtChildren = currentObj.GetComponentsInChildren<Transform>();
            if (supprtChildren != null)
            {
                foreach (Transform g in supprtChildren)
                {
                    if (g.gameObject.tag == "Support")
                    {
                        g.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
            }
        }
        else
        {
            supprtChildren = currentObj.GetComponentsInChildren<Transform>(); 
            if (supprtChildren != null)
            {
                foreach (Transform g in supprtChildren)
                {
                    if (g.gameObject.tag == "Support")
                    {
                        g.GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }
        }
    }
}
