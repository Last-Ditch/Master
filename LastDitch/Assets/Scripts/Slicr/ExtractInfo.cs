using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractInfo : MonoBehaviour
{
    //pulls all the info off the progress tracker and sets everything up to be printed

    public Audio audioSCript;
    public ProgressTracker progressScript;
    public GameObject model, holdModel;
    public Material PLA, ABS, TPU, PTE;
    public Transform[] children;
    public Transform[] supprtChildren;
    public SDPickup SDCardScript;
    public SlowlyDown revealScript;
    public GameObject Pyr1, Pyr2, Pyr3,
                      Ball1, Ball2, Ball3,
                      Pawn1, Pawn2, Pawn3,
                      Arch1, Arch2, Arch3,
                      nozzle1,nozzle2,nozzle3;
    bool canPrint = true;
    public bool donePrinting;
    public PhysicMaterial PhysPLA, PhysABS, PhysTPU, PhysPTE;

    public GameObject[] blockedMod;

    private void Start()
    {
        progressScript = GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>();
        //revealScript.enabled = false;
    }


    private void Update()
    {
        if(progressScript.sliced)
        {
            audioSCript.doneSlicr = true;
        }

        if (progressScript.sliced && progressScript.sdIn && !donePrinting)
        {
            revealScript.completedSlicr = true;
            
            if (canPrint)
            {
                canPrint = false;
            }
        }

    }

    public void MakeModel()
    {
        //chooses which model the player picked tio be spawned
        if (progressScript.ModelPicked == 1)
        {
            switch (progressScript.LayerHeightC)
            {
                case 3:
                    model = Instantiate(Pyr3, transform, false);

                    //anim stop num is when the printer has finished the actual printing and just needs to reach the bottom
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

        if (progressScript.ModelPicked == 3)
        {
            switch (progressScript.LayerHeightC)
            {
                case 3:
                    model = Instantiate(Pawn3, transform, false);
                    //model.SetActive(true);
                    break;
                case 2:
                    model = Instantiate(Pawn2, transform, false);
                    //model.SetActive(true);
                    break;
                case 1:
                    model = Instantiate(Pawn1, transform, false);
                    //model.SetActive(true);
                    break;
                default:
                    model = Instantiate(Pawn1, transform, false);
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

            if(progressScript.blocked)
            {
                holdModel = model;
                revealScript.holdModel = holdModel;
                model.SetActive(false);
                model = blockedMod[progressScript.LayerHeightC - 1];
                model.SetActive(true);
            }
            MaterialChange();
        }

        if (progressScript.ModelPicked == 4)
        {
            switch (progressScript.LayerHeightC)
            {
                case 3:
                    model = Instantiate(Arch3, transform, false);
                    //model.SetActive(true);
                    break;
                case 2:
                    model = Instantiate(Arch2, transform, false);
                    //model.SetActive(true);
                    break;
                case 1:
                    model = Instantiate(Arch1, transform, false);
                    //model.SetActive(true);
                    break;
                default:
                    model = Instantiate(Arch1, transform, false);
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
                        //adds material and physics materials
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
