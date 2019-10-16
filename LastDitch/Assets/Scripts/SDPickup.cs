using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDPickup : MonoBehaviour
{

    GameObject sdSlot;
    public bool haveCard = false;
    public bool readytoPrint;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && sdSlot!=null)
        {
            if (sdSlot.gameObject.GetComponent<MeshRenderer>().enabled)
            {
                sdSlot.gameObject.GetComponent<MeshRenderer>().enabled = false;
                haveCard = true;
                return;
            }
            if (!sdSlot.gameObject.GetComponent<MeshRenderer>().enabled && haveCard)
            {
                sdSlot.gameObject.GetComponent<MeshRenderer>().enabled = true;
                haveCard = false;
                if(sdSlot.gameObject.transform.parent.tag == "Ultimaker")
                {
                    GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().sdIn = true;
                }
                return;
            }
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
            readytoPrint = true;
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
            readytoPrint = false;
            sdSlot = null;
        }
    }
}
