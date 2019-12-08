using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakawayStructure : MonoBehaviour
{
    Transform[] structureParts;

    void Start()
    {
        //grab all bits of the model
        structureParts = GetComponentsInChildren<Transform>();
    }


    public void PickedUp()
    {
        foreach(Transform t in structureParts)
        {
            if(t.tag == "Support")
            {
                //if its a support, unparent it and let it fall away
                t.transform.parent = null;
                t.GetComponent<Rigidbody>().isKinematic = false;
                t.GetComponent<Rigidbody>().useGravity = true;
                t.GetComponent<Collider>().enabled = true;
            }
        }

    }
}
