using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyDown : MonoBehaviour
{

    //7.999962
    [SerializeField] GameObject[] Pyramids;
    [SerializeField] GameObject[] Balls;
    public FilamentPickup fPickupScript;
    //197.4
    public Animator anim;
    public GameObject model;
    public bool completedSlicr;
    public bool canGo = false;
    bool rising;
    bool hasRisen;
    public bool isPrinting;
    public bool donePrinting;
    public bool stopPrinting;
    public AudioSource speaker;
    public UltimakerMenu menuScript;
    public bool sdd;
    public ExtractInfo infoScript;
    public float animStopNo;
    public GameObject instructions;

    public void Reset()
    {
        canGo = false;
        rising = false;
        hasRisen = false;
        isPrinting = false;
        donePrinting = false;
        stopPrinting = false;
        transform.localPosition = new Vector3(0, 1, 0);
        menuScript.ChangeMenu(0);
        menuScript.Reset();
    }


    void FixedUpdate()
    {
        
        if (rising && !hasRisen)
        {
            
            fPickupScript.enabled = false;
            transform.Translate(0, 0.01f, 0);
            if (transform.localPosition.y >= 197.4)
            {
                ClockMove.speed = 500;
                StartCoroutine(animPlay());
                rising = false;
                hasRisen = true;
                infoScript.MakeModel();
            }
        }

        


        if (transform.localPosition.y >= 0 && canGo )
        {
            
            fPickupScript.enabled = false;
            model.SetActive(true);
            
            if(!donePrinting)
            {
                speaker.enabled = true;
                transform.Translate(0, -0.005f, 0);
            }
            else
            {
                speaker.enabled = false;
                transform.Translate(0, -0.01f, 0);
            }
        }

        if (transform.localPosition.y <= animStopNo && !rising)
        {
            
            anim.SetTrigger("StopPrinting");
            donePrinting = true;
        }

        if (transform.localPosition.y <= 0 && !stopPrinting)
        {
            fPickupScript.enabled = true;
            GameObject.FindGameObjectWithTag("Speaker").GetComponent<Audio>().AudioButton(12);
            ClockMove.speed = 1;
            Debug.Log("EP");
            instructions.SetActive(true);
            model.tag = "Interactable";
            speaker.enabled = false;
            //GameObject.FindGameObjectWithTag("Manager").GetComponent<ExtractInfo>().donePrinting = true;
            stopPrinting = true;
            Reset();
        }
    }

    public void Printing()
    {
        GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().objectPrinting = true;
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
