using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilamentLocationDetection : MonoBehaviour
{
    FilamentPickup fPickupScript;

    
    void Start()
    {
        fPickupScript = GameObject.FindGameObjectWithTag("Player").GetComponent<FilamentPickup>();
    }

  

    private void OnTriggerStay(Collider other)
    {

        if(other.gameObject.tag =="Player")
        {

            fPickupScript.canPickup = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fPickupScript.canPickup = false;
        }
    }

}
