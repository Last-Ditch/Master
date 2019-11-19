using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeDownAndGlue : MonoBehaviour
{
    ProgressTracker progressScript;
    SlowlyDown slowlyScript;
    Animator anim;

    void Start()
    {
        progressScript = GetComponent<ProgressTracker>();
        anim = GetComponent<Animator>();
    }


    public void WipeDown()
    {
        GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().objectReadytoPrint = true;
        anim.SetTrigger("Wipe");
        if(progressScript.TpuPicked)
        {
            anim.SetBool("TPU", true);
        }
        else
        {
            anim.SetBool("TPU", false);
        }
    }

    public void SendPrintMesssage()
    {
        slowlyScript.Printing();
    }

}
