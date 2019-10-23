using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{

    public float throw_force = 1200f;
    Vector3 object_position;
    float distance;

    public bool can_hold = true;
    public bool thrown = false;
    public GameObject item;
    public GameObject temp_parent;
    public bool is_held = false;

    private void Start()
    {
        temp_parent = GameObject.FindGameObjectWithTag("Hand");
    }

    // Update is called once per frame
    void Update()
    {
        

        if(is_held == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(temp_parent.transform);

            if (Input.GetKeyDown(KeyCode.E))
            {
                item.GetComponent<Rigidbody>().AddForce(temp_parent.transform.forward * throw_force);
                is_held = false;
                thrown = true;
                
            }
        }
        else
        {
            object_position = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = object_position;
        }
    }


    void OnMouseDown()
    {
        is_held = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        thrown = false;

        
    }

     void OnMouseUp()
    {
        is_held = false;
    }

     
}
