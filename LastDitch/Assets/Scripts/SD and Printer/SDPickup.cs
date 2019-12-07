using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDPickup : MonoBehaviour
{
    Animator anim;
    AudioSource speaker;
    public AudioClip click;
    GameObject sdSlot;
    public bool haveCard = false;
    public bool readytoPrint;
    public GameObject sd_ui;

    private void Start()
    {
        speaker = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1) && sdSlot!=null)
        {
            
            if (sdSlot.gameObject.GetComponent<MeshRenderer>().enabled)
            {
                GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().sdPickedUp = true;
                //speaker.PlayOneShot(click);
                anim = sdSlot.GetComponent<Animator>();
                anim.SetTrigger("SDOut");
                haveCard = true;
                if(sdSlot.gameObject.transform.parent.tag == "Ultimaker")
                {
                    GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().sdIn = false;
                }
                return;
            }
            if (!sdSlot.gameObject.GetComponent<MeshRenderer>().enabled && haveCard)
            {
                //speaker.PlayOneShot(click);
                anim = sdSlot.GetComponent<Animator>();
                anim.SetTrigger("SDIn");
                haveCard = false;
                if(sdSlot.gameObject.transform.parent.tag == "Ultimaker")
                {
                    GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().sdIn = true;
                }
                return;
            }
        }
        StartCoroutine(sd_ui_trigger());
    

    }

   IEnumerator sd_ui_trigger()
    {
        if(haveCard == true)
        {
            yield return new WaitForSeconds(0.5f);
            sd_ui.SetActive(true);
        }

        if (haveCard == false)
        {
            yield return new WaitForSeconds(0.5f);
            sd_ui.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SD card Laptop")
        {
            sdSlot = other.gameObject;
        }
        if (other.gameObject.tag == "SD card Printer")
        {
            sdSlot = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SD card Laptop")
        {
            sdSlot = null;
        }
        if (other.gameObject.tag == "SD card Printer")
        {
            sdSlot = null;
        }
    }
}
