using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{

    public GameObject model, canPickup;
    public GameObject hand;
    public GameObject head;
    public static bool pickup;
    Rigidbody rb;



    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            //if the player can pickup and is not currently holding anything
            if (canPickup != null && !pickup)
            {
                //set model as picked up and remove any supports
                model = canPickup;
                model.GetComponent<BreakawayStructure>().PickedUp();

                //remove any forces on the object 
                rb = model.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.useGravity = false;
                model.GetComponent<Collider>().enabled = false;

                //set the model in the players hand
                model.transform.parent = null;
                pickup = true;
                model.transform.position = hand.transform.position;
                model.transform.parent = head.transform;

            }
        }

        if (model != null && pickup)
        {
            model.transform.position = hand.transform.position;
        }

        if(!model.gameObject && pickup)
        {
            pickup = false;
        }

        if (Input.GetMouseButtonDown(1) && pickup)
        {
            
            Throw();
        }
    }


    void Throw()
    {
        pickup = false;
        model.GetComponent<Destruction>().canBeDamaged = true;
        model.GetComponent<Collider>().enabled = true;
        model.transform.parent = null;
        model.GetComponent<Rigidbody>().AddForce(hand.transform.forward * 500);
        model.GetComponent<Rigidbody>().useGravity = true;

    }




    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            canPickup = other.gameObject;          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            canPickup = null;
        }
    }

}
