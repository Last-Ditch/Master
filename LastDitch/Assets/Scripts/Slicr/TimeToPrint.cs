using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeToPrint : MonoBehaviour
{

    public Text ttp;

    void Start()
    {
        
    }

    
    public void Change(string i)
    {
        ttp.text = "Time to Print: " + i;
    }
	
}
