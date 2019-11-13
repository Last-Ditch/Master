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

    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag =="Player")
        {
            Debug.Log(234234234234234);
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
