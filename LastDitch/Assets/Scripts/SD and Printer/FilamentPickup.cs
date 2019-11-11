using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilamentPickup : MonoBehaviour
{

    public GameObject filament;
    public GameObject hand;
    public GameObject head;
    bool pickup;
    Rigidbody rb;




    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (filament != null)
            {
                filament.GetComponent<Collider>().enabled = false;
                filament.transform.parent = null;
                pickup = true;
                filament.transform.position = hand.transform.position;
                filament.transform.parent = head.transform;
            }
        }

        if (filament != null && pickup)
        {
            filament.transform.position = hand.transform.position;
        }

        if (Input.GetMouseButtonDown(1) && filament != null)
        {
            Place();
        }
    }


    void Place()
    {

    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Filament")
        {
            filament = other.gameObject;

        }
        if(other.gameObject.tag == "Ultimaker Back")
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Filament")
        {
            filament = null;
        }

        if (other.gameObject.tag == "Ultimaker Back")
        {

        }
    }
}
