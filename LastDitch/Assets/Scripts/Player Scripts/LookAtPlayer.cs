using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject child;
    public bool LAenabled;

    void Start()
    {
    }

    
    void Update()
    {
        if(LAenabled)
        {
            child.SetActive(true);
            transform.LookAt(Player.transform.position);
        }
        else
        {
            child.SetActive(false);
        }
    }
	
}
