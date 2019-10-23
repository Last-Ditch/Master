using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyDown : MonoBehaviour
{
    //197.4
    public Animator anim;
    public GameObject model;
    bool canGo = false;
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
        StartCoroutine(animPlay());
    }

    IEnumerator animPlay()
    {
        anim.SetTrigger("IntoPosition");
        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("StartPrinting");
        canGo = true;
        Debug.Log("SP");
    }
}
