using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilamentPickup : MonoBehaviour
{
    public Material PLA, ABS, TPU, PTE;
    Animator anim;
    AudioSource speaker;
    public AudioClip click;
    public GameObject filamentSpool;
    public bool haveFilament = false;
    public int currentSpoolNum;
    public bool readytoPrint;
    public GameObject sd_ui;

    private void Start()
    {
        speaker = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && filamentSpool!=null)
        {
            
            if (filamentSpool.gameObject.GetComponent<MeshRenderer>().enabled)
            {
                
                //speaker.PlayOneShot(click);
                anim = filamentSpool.GetComponent<Animator>();
                anim.SetTrigger("Pickup");
                filamentSpool.GetComponent<MeshRenderer>().enabled = false;
                if(filamentSpool.gameObject.tag != "Ultimaker Back") { currentSpoolNum = filamentSpool.GetComponent<FilamentChoice>().matNo; }
                
                haveFilament = true;



                if (filamentSpool.gameObject.transform.parent.tag == "Ultimaker")
                {
                    //GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().sdIn = false;
                }
                return;
            }
            if (!filamentSpool.gameObject.GetComponent<MeshRenderer>().enabled && haveFilament)
            {
                //speaker.PlayOneShot(click);
                anim = filamentSpool.GetComponent<Animator>();
                anim.SetTrigger("Putdown");
                filamentSpool.GetComponent<MeshRenderer>().enabled = true;
                
                if (filamentSpool.gameObject.tag == "Ultimaker Back")
                {
                    Debug.Log(23423423423);
                    switch (currentSpoolNum)
                    {
                        case 4:
                            filamentSpool.GetComponent<MeshRenderer>().material = PLA;
                            break;

                        case 3:
                            filamentSpool.GetComponent<MeshRenderer>().material = ABS;
                            break;

                        case 2:
                            filamentSpool.GetComponent<MeshRenderer>().material = TPU;
                            break;

                        case 1:
                            filamentSpool.GetComponent<MeshRenderer>().material = PTE;
                            break;

                        default:

                            break;
                    }
                }
                haveFilament = false;



                if (filamentSpool.gameObject.transform.parent.tag == "Ultimaker")
                {
                    //GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().sdIn = true;
                }
                return;
            }
        }
        StartCoroutine(sd_ui_trigger());
    

    }

   IEnumerator sd_ui_trigger()
    {
        if(haveFilament == true)
        {
            yield return new WaitForSeconds(0.5f);
            sd_ui.SetActive(true);
        }

        if (haveFilament == false)
        {
            yield return new WaitForSeconds(0.5f);
            sd_ui.SetActive(false);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Filament")
        {
            filamentSpool = other.gameObject;
            if(filamentSpool.GetComponent<FilamentChoice>())
            {
                filamentSpool.gameObject.GetComponent<FilamentChoice>().lookedAT = true;
            }
            
        }
        if (other.gameObject.tag == "Ultimaker Back")
        {
            filamentSpool = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Filament")
        {
            if (other.GetComponent<FilamentChoice>())
            {
                other.gameObject.GetComponent<FilamentChoice>().lookedAT = false;
            }
            filamentSpool = null;
        }
        if (other.gameObject.tag == "Ultimaker Back")
        {
            filamentSpool = null;
        }
    }
}
