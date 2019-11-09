﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyDown : MonoBehaviour
{

    //7.999962
    [SerializeField] GameObject[] Pyramids;
    [SerializeField] GameObject[] Balls;

    //197.4
    public Animator anim;
    public GameObject model;
    public bool completedSlicr;
    public bool canGo = false;
    bool rising;
    bool hasRisen;
    public bool isPrinting;
    public bool stopPrinting;
    public AudioSource speaker;
    public UltimakerMenu menuScript;
    public bool sdd;
    public ExtractInfo infoScript;
    public float animStopNo;


    public void Reset()
    {
        canGo = false;
        rising = false;
        hasRisen = false;
        isPrinting = false;
        stopPrinting = false;
        transform.localPosition = new Vector3(0, 1, 0);
        menuScript.ChangeMenu(0);
        menuScript.Reset();
    }


    void FixedUpdate()
    {
        
        if (rising && !hasRisen)
        {
            
            transform.Translate(0, 0.02f, 0);
            if (transform.localPosition.y >= 197.4)
            {
                StartCoroutine(animPlay());
                rising = false;
                hasRisen = true;
                infoScript.MakeModel();
            }
        }

        


        if (transform.localPosition.y >= 0 && canGo )
        {
            model.SetActive(true);
            speaker.enabled = true;
            transform.Translate(0, -0.01f, 0);
        }

        if (transform.localPosition.y <= animStopNo && !rising)
        {
            anim.SetTrigger("StopPrinting");
        }

            if (transform.localPosition.y <= 0 && !stopPrinting)
        {
            GameObject.FindGameObjectWithTag("Speaker").GetComponent<Audio>().AudioButton(12);
            
            Debug.Log("EP");
            model.tag = "Interactable";
            speaker.enabled = false;
            //GameObject.FindGameObjectWithTag("Manager").GetComponent<ExtractInfo>().donePrinting = true;
            stopPrinting = true;
            Reset();
        }
    }

    public void Printing()
    {
        rising = true;
        if(hasRisen)
        {
            canGo = true;
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
