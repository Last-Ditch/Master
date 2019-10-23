using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakawayStructure : MonoBehaviour
{
    Transform[] structureParts;

    void Start()
    {
        structureParts = GetComponentsInChildren<Transform>();
    }



    void Update()
    {
        
    }

    

    public void PickedUp()
    {
        foreach(Transform t in structureParts)
        {
            if(t.tag == "Support")
            {
                t.transform.parent = null;
                t.GetComponent<Rigidbody>().isKinematic = false;
                t.GetComponent<Rigidbody>().useGravity = true;
                t.GetComponent<Collider>().enabled = true;
            }
        }

    }
}
