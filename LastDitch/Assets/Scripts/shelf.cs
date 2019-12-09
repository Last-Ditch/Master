using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shelf : MonoBehaviour
{
   
    public GameObject player;

    public GameObject[] waypoints;

    private int curr_pos = 0;

    public GameObject model;

  

    private void Update()
    {
        if (curr_pos > waypoints.Length)
        {
            curr_pos = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetMouseButtonDown(1))
        {
            model = player.transform.GetChild(3).GetChild(1).gameObject;
            model.transform.parent = null;
            Debug.Log("working");
            model.transform.position = waypoints[0 + curr_pos].transform.position;
            ObjectPickup.pickup = false;
            model.transform.rotation = Quaternion.Euler(-90,0,0);
            curr_pos++;
            model.gameObject.tag = "Finish";


        }
    }
    
    
    
}
