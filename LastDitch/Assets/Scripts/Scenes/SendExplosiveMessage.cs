using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendExplosiveMessage : MonoBehaviour
{
    Audio audioS;
    
    void Start()
    {
        audioS = GameObject.FindGameObjectWithTag("Speaker").GetComponent<Audio>();
    }

    public void Send()
    {
        //play the spools audioclip
        audioS.ExplosiveSpools();
    }
	
}
