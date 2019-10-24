﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractInfo : MonoBehaviour
{
    
    public ProgressTracker progressScript;
    public GameObject model;
    public Material PLA, ABS, TPU, PTE;
    public Transform[] children;
    public Transform[] supprtChildren;
    public SDPickup SDCardScript;
    public SlowlyDown revealScript;
    public GameObject Pyr1, Pyr2, Pyr3,
                      Ball1, Ball2, Ball3;
    bool canPrint = true;
    public bool donePrinting;
    public PhysicMaterial PhysPLA, PhysABS, PhysTPU, PhysPTE;


    private void Start()
    {
        progressScript = GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>();
        revealScript.enabled = false;
    }


    private void Update()
    {
        if (progressScript.sliced && progressScript.sdIn && !donePrinting)
        {
            if (progressScript.ModelPicked == 1)
            {
                switch (progressScript.LayerHeightC)
                {
                    case 3:
                        model = Pyr3;
                        model.SetActive(true);
                        break;
                    case 2:
                        model = Pyr2;
                        model.SetActive(true);
                        break;
                    case 1:
                        model = Pyr1;
                        model.SetActive(true);
                        break;
                    default:
                        model = Pyr1;
                        model.SetActive(true);
                        break;
                }
                switch (progressScript.InfillC)
                {
                    case 5:

                        break;
                    case 4:

                        break;
                    case 3:

                        break;
                    case 2:

                        break;
                    case 1:

                        break;
                    default:

                        break;
                }

                MaterialChange();

                if (canPrint)
                {

                    revealScript.enabled = true;
                    revealScript.model = model;
                    revealScript.Printing();
                    canPrint = false;
                }

            }
            if (progressScript.ModelPicked == 2)
            {
                switch (progressScript.LayerHeightC)
                {
                    case 3:
                        model = Ball3;
                        model.SetActive(true);
                        break;
                    case 2:
                        model = Ball2;
                        model.SetActive(true);
                        break;
                    case 1:
                        model = Ball1;
                        model.SetActive(true);
                        break;
                    default:
                        model = Ball1;
                        model.SetActive(true);
                        break;
                }
                switch (progressScript.InfillC)
                {
                    case 5:

                        break;
                    case 4:

                        break;
                    case 3:

                        break;
                    case 2:

                        break;
                    case 1:

                        break;
                    default:

                        break;
                }

                MaterialChange();

                if(progressScript.supportsAdded)
                {
                    supprtChildren = model.GetComponentsInChildren<Transform>();
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
                if (canPrint)
                {

                    revealScript.enabled = true;
                    revealScript.model = model;
                    revealScript.Printing();
                    canPrint = false;
                }
            }
        }

    }

    void MaterialChange()
    {
        children = model.GetComponentsInChildren<Transform>();
        switch (progressScript.MaterialC)
        {
            case 4:
                foreach (Transform i in children)
                {
                    if (i.GetComponent<MeshRenderer>())
                    {
                        i.GetComponent<MeshRenderer>().material = PTE;
                        i.GetComponent<Collider>().material = PhysPTE;
                    }
                }
                break;
            case 3:
                foreach (Transform i in children)
                {
                    if (i.GetComponent<MeshRenderer>())
                    {
                        i.GetComponent<MeshRenderer>().material = TPU;
                        i.GetComponent<Collider>().material = PhysTPU;
                    }
                }
                break;
            case 2:
                foreach (Transform i in children)
                {
                    if (i.GetComponent<MeshRenderer>())
                    {
                        i.GetComponent<MeshRenderer>().material = ABS;
                        i.GetComponent<Collider>().material = PhysABS;
                    }
                };
                break;
            case 1:
                foreach (Transform i in children)
                {
                    if (i.GetComponent<MeshRenderer>())
                    {
                        i.GetComponent<MeshRenderer>().material = PLA;
                        i.GetComponent<Collider>().material = PhysPLA;
                    }
                };
                break;
            default:
                foreach (Transform i in children)
                {
                    if (i.GetComponent<MeshRenderer>())
                    {
                        i.GetComponent<MeshRenderer>().material = PLA;
                        i.GetComponent<Collider>().material = PhysPLA;
                    }
                }
                break;

        }
    }
}
