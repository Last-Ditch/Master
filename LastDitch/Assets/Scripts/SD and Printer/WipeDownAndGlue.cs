using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeDownAndGlue : MonoBehaviour
{
    //for playing the animations at the start of printing

    ProgressTracker progressScript;
    public SlowlyDown slowlyScript;
    Animator anim;
    public bool canWipe;

    void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canWipe && Input.GetButtonDown("Jump"))
        {
            canWipe = false;
            StartCoroutine(delay());
        }
    }


    void WipeDown()
    {
        progressScript = GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>();
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
        GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().bedGlued = true;
    }

    public void Resume()
    {
        slowlyScript.Resume();
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        WipeDown();
    }
}
