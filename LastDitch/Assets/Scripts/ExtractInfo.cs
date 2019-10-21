using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractInfo : MonoBehaviour
{
    public ProgressTracker progressScript;
    public GameObject model;
    public Material PLA, ABS, TPU, PTE;
    public MeshRenderer[] children;
    public SDPickup SDCardScript;
    public SlowlyDown revealScript;
    public GameObject Pyr1, Pyr2, Pyr3;

    private void Start()
    {
        progressScript = GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>();
        revealScript.enabled = false;
    }


    private void Update()
    {
        if (progressScript.sliced && progressScript.sdIn)
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

                children = model.GetComponentsInChildren<MeshRenderer>();
                switch (progressScript.MaterialC)
                {
                    case 4:     
                        foreach(MeshRenderer i in children)
                        {
                            if(i.GetComponent<MeshRenderer>())
                            {
                                i.GetComponent<MeshRenderer>().material = PTE;
                            }
                        }
                        break;
                    case 3:
                        foreach (MeshRenderer i in children)
                        {
                            if (i.GetComponent<MeshRenderer>())
                            {
                                i.GetComponent<MeshRenderer>().material = TPU;
                            }
                        }
                        break;
                    case 2:
                        foreach (MeshRenderer i in children)
                        {
                            if (i.GetComponent<MeshRenderer>())
                            {
                                i.GetComponent<MeshRenderer>().material = ABS;
                            }
                        };
                        break;
                    case 1:
                        foreach (MeshRenderer i in children)
                        {
                            if (i.GetComponent<MeshRenderer>())
                            {
                                i.GetComponent<MeshRenderer>().material = PLA;
                            }
                        };
                        break;
                    default:
                        foreach (MeshRenderer i in children)
                        {
                            if (i.GetComponent<MeshRenderer>())
                            {
                                i.GetComponent<MeshRenderer>().material = PLA;
                            }
                        }
                        break;
                }
                
                revealScript.enabled = true;
            }
        }
    }


}
