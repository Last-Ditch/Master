using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactiveateSpool : MonoBehaviour
{

    public GameObject spool;   
    


    public void Activate()
    {
        spool.SetActive(true);
    }

    public void Deactiveate()
    {
        spool.SetActive(false);
    }
	
}
