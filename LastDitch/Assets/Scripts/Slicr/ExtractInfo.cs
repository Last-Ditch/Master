using System.Collections;
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
        //revealScript.enabled = false;
    }


    private void Update()
    {
        if (progressScript.sliced && progressScript.sdIn && !donePrinting)
        {
            revealScript.completedSlicr = true;

            if (canPrint)
            {
                
                
                //revealScript.enabled = true;
                //revealScript.model = model;
                //revealScript.Printing();
                canPrint = false;
            }
        }

    }

    public void MakeModel()
    {
        if (progressScript.ModelPicked == 1)
        {
            switch (progressScript.LayerHeightC)
            {
                case 3:
                    model = Instantiate(Pyr3, transform, false);
                    revealScript.animStopNo = 19;
                    //model.SetActive(true);
                    break;
                case 2:
                    model = Instantiate(Pyr2, transform, false);
                    revealScript.animStopNo = 30;
                    //model.SetActive(true);
                    break;
                case 1:
                    model = Instantiate(Pyr1, transform, false);
                    revealScript.animStopNo = 32;
                    //model.SetActive(true);
                    break;
                default:
                    model = Instantiate(Pyr1, transform, false);
                    revealScript.animStopNo = 32;
                    //model.SetActive(true);
                    break;
            }
            SetInfill();

            MaterialChange();
            
        }
        if (progressScript.ModelPicked == 2)
        {
            switch (progressScript.LayerHeightC)
            {
                case 3:
                    model = Instantiate(Ball3, transform, false);
                    //model.SetActive(true);
                    break;
                case 2:
                    model = Instantiate(Ball2, transform, false);
                    //model.SetActive(true);
                    break;
                case 1:
                    model = Instantiate(Ball1, transform, false);
                    //model.SetActive(true);
                    break;
                default:
                    model = Instantiate(Ball1, transform, false);
                    //model.SetActive(true);
                    break;
            }
            SetInfill();

            MaterialChange();

            if (progressScript.supportsAdded)
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
            revealScript.animStopNo = 88;

        }
        revealScript.model = model;
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
                        if (i.gameObject.tag != "Support")
                        {
                            i.GetComponent<Collider>().material = PhysPTE;
                        }
                    }
                }
                model.GetComponent<Collider>().material = PhysPTE;
                break;
            case 3:
                foreach (Transform i in children)
                {
                    if (i.GetComponent<MeshRenderer>())
                    {
                        i.GetComponent<MeshRenderer>().material = TPU;
                        if (i.gameObject.tag != "Support")
                        {
                            i.GetComponent<Collider>().material = PhysTPU;
                        }
                    }
                }
                model.GetComponent<Collider>().material = PhysTPU;
                break;
            case 2:
                foreach (Transform i in children)
                {
                    if (i.GetComponent<MeshRenderer>())
                    {
                        i.GetComponent<MeshRenderer>().material = ABS;
                        if (i.gameObject.tag != "Support")
                        {
                            i.GetComponent<Collider>().material = PhysABS;
                        }
                    }
                }
                model.GetComponent<Collider>().material = PhysABS;
                break;
            case 1:
                foreach (Transform i in children)
                {
                    if (i.GetComponent<MeshRenderer>())
                    {
                        i.GetComponent<MeshRenderer>().material = PLA;
                        if (i.gameObject.tag != "Support")
                        {
                            i.GetComponent<Collider>().material = PhysPLA;
                        }
                    }
                }
                model.GetComponent<Collider>().material = PhysPLA;
                break;
            default:
                foreach (Transform i in children)
                {
                    if (i.GetComponent<MeshRenderer>())
                    {
                        i.GetComponent<MeshRenderer>().material = PLA;
                        if (i.gameObject.tag != "Support")
                        {
                            i.GetComponent<Collider>().material = PhysPLA;
                        }
                    }
                }
                model.GetComponent<Collider>().material = PhysPLA;
                break;

        }
    }

    void SetInfill()
    {
        switch (progressScript.InfillC)
        {
            case 5:
                model.GetComponent<Destruction>().health = 50;
                break;
            case 4:
                model.GetComponent<Destruction>().health = 40;
                break;
            case 3:
                model.GetComponent<Destruction>().health = 30;
                break;
            case 2:
                model.GetComponent<Destruction>().health = 20;
                break;
            case 1:
                model.GetComponent<Destruction>().health = 10;
                break;
            default:
                model.GetComponent<Destruction>().health = 10;
                break;
        }
    }
}
