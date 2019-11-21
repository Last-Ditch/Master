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
    public GameObject model, holdModel;
    public bool completedSlicr;
    public bool canGo = false;
    bool rising;
    bool hasRisen;
    bool restartAnim;
    public bool lowerbuildPlate;
    public bool isPrinting;
    public bool donePrinting;
    public bool stopPrinting;
    public AudioSource speaker;
    public UltimakerMenu menuScript;
    public bool sdd;
    public ExtractInfo infoScript;
    public float animStopNo;
    public GameObject instructions;
    public GameObject instructionsSpace;

    ProgressTracker progressScript;
    private void Start()
    {
        progressScript = GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>();
    }


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
        if(lowerbuildPlate)
        {
            speaker.enabled = false;
            if (transform.localPosition.y >= 1.1f)
            {
                transform.Translate(0, -0.01f, 0);
            }
            else
            {
                anim.SetTrigger("CleanNozzle");
                anim.SetBool("PausePrinting", false);
                anim.SetBool("StopPrinting", false);
            }

            return;
        }
        if (transform.localPosition.y <= 140 && !rising && progressScript.blocked && canGo && progressScript.ModelPicked == 3)
        {
            Debug.Log(transform.position.y);
            anim.SetBool("PausePrinting", true);
            GameObject.FindGameObjectWithTag("Speaker").GetComponent<Audio>().Nozzle();
            ClockMove.speed = 1;
            return;
        }

        if (rising && !hasRisen)
        {

            fPickupScript.enabled = false;
            transform.Translate(0, 0.01f, 0);
            if (transform.localPosition.y >= 197.4)
            {

                StartCoroutine(animPlay());
                rising = false;
                hasRisen = true;
                infoScript.MakeModel();
            }
        }




        if (restartAnim)
        {
            if (transform.localPosition.y <= 140)
            {
                anim.SetBool("StopPrinting", false);
                transform.Translate(0, 0.01f, 0);
            }
            else
            {
                
                restartAnim = false;
                model.SetActive(false);
                model = holdModel;
                model.SetActive(true);
                canGo = true;
            }

            return;
        }




        if (transform.localPosition.y >= 0 && canGo )
        {
            
            fPickupScript.enabled = false;
            model.SetActive(true);
            
            if(!donePrinting)
            {
                speaker.enabled = true;
                speaker.playOnAwake = true;
                transform.Translate(0, -0.005f, 0);
            }
            else
            {
                speaker.enabled = false;
                transform.Translate(0, -0.01f, 0);
            }
        }



        if (transform.localPosition.y <= animStopNo && !rising && !donePrinting)
        {
            Debug.Log("StopPrinting");
            anim.SetBool("StopPrinting", true);
            donePrinting = true;
        }

        if (transform.localPosition.y <= 0 && !stopPrinting)
        {
            fPickupScript.enabled = true;
            GameObject.FindGameObjectWithTag("Speaker").GetComponent<Audio>().EndPrint();
            ClockMove.speed = 1;
            Debug.Log("EP");
            instructionsSpace.SetActive(false);
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
        anim.SetBool("StopPrinting", false);
        ClockMove.speed = 500;
        canGo = true;
        donePrinting = false;
        isPrinting = true;
        Debug.Log("SP");
    }


    public void LBP()
    {
        lowerbuildPlate = true;
    }

    public void Resume()
    {
        lowerbuildPlate = false;
        restartAnim = true;
        progressScript.blocked = false;
    }
}
