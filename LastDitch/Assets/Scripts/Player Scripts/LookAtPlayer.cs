using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    //Prompts turn to face player if enabled


    public GameObject Player;
    public GameObject child;
    public bool LAenabled; //Look at enabled
    public bool QuickFix; //Stops the prompt turning to face the player, for if prompts clip throuh walls


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
