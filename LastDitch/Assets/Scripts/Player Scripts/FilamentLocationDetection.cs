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
        //PFeet = Player feet, if the player is standing in the right position then let them pick up filaments
        if(other.gameObject.tag =="PFeet")
        {

            fPickupScript.canPickup = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PFeet")
        {
            fPickupScript.canPickup = false;
        }
    }

}
