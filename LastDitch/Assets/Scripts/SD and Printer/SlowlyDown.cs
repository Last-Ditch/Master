using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyDown : MonoBehaviour
{
    //197.4
    public Animator anim;
    public GameObject model;
    public bool completedSlicr;
    public bool canGo = false;
    public bool isPrinting;
    bool stopPrinting;
    public AudioSource speaker;

    void Update()
    {
        if (transform.localPosition.y >= 0 && canGo)
        {
            speaker.enabled = true;
            transform.Translate(0, -0.001f, 0);
        }
        if(transform.localPosition.y <= 0 && !stopPrinting)
        {
            GameObject.FindGameObjectWithTag("Speaker").GetComponent<Audio>().AudioButton(12);
            anim.SetTrigger("StopPrinting");
            Debug.Log("EP");
            model.tag = "Interactable";
            speaker.enabled = false;
            GameObject.FindGameObjectWithTag("Manager").GetComponent<ExtractInfo>().donePrinting = true;
            stopPrinting = true;
        }
    }

    public void Printing()
    {
        if (completedSlicr)
        {
            StartCoroutine(animPlay());
        }
    }


    public void StopPrinting()
    {
        anim.SetTrigger("StopPrinting");
        canGo = false;
    }


    IEnumerator animPlay()
    {
        anim.SetTrigger("IntoPosition");
        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("StartPrinting");
        canGo = true;
        isPrinting = true;
        Debug.Log("SP");
    }
}
