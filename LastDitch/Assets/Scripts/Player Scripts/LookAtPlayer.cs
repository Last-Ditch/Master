using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject child;
    public bool LAenabled;
    public bool QuickFix;

    void Start()
    {
    }

    
    void Update()
    {
        if(LAenabled)
        {
            child.SetActive(true);
            
            if(QuickFix)
            {
                
            }
            else
            {
                transform.LookAt(Player.transform.position);
            }
            
        }
        else
        {
            child.SetActive(false);
        }
    }
	
}
