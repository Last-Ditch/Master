using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlowlyDown : MonoBehaviour
{
    //moves the build plate down when printing and spawns in the model

    public GameObject warningText;


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
    public AudioClip liftClip;
    public AudioSource liftSource;
    public float volume;
    public UltimakerMenu menuScript;
    public bool sdd;
    public ExtractInfo infoScript;
    public float animStopNo;
    public GameObject instructions;
    public GameObject instructionsSpace;
    public Button MenuButton;
    private bool Moving;
    private bool isPlaying;

    ProgressTracker progressScript;
    private void Start()
    {
        warningText.SetActive(false);

        progressScript = GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>();
        liftSource = GetComponent<AudioSource>();
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
        //Audio Trigger
        if (Moving == true && isPlaying == false)
        {
            liftSource.PlayOneShot(liftClip, volume);
            isPlaying = true;
        }
        else if(Moving == false)
        {
            isPlaying = false;
        }

        //for the clearing nozzle animation
        if(lowerbuildPlate)
        {
            speaker.enabled = false;
            if (transform.localPosition.y >= 1.1f)
            {
                Moving = true;
                transform.Translate(0, -0.01f, 0);
               
            }
            else
            {
                Moving = false;
                anim.SetTrigger("CleanNozzle");
                anim.SetBool("PausePrinting", false);
                anim.SetBool("StopPrinting", false);
                MenuButton.interactable = false;
            }

            return;
        }
        if (transform.localPosition.y <= 140 && !rising && progressScript.blocked && canGo && progressScript.ModelPicked == 3)
        {
            MenuButton.interactable = true;
            anim.SetBool("PausePrinting", true);
            GameObject.FindGameObjectWithTag("Speaker").GetComponent<Audio>().Nozzle();
            ClockMove.speed = 1;
            return;
        }

        if (rising && !hasRisen)
        {
            Moving = true;
            fPickupScript.enabled = false;
            transform.Translate(0, 0.01f, 0);
            if (transform.localPosition.y >= 197.4)
            {

                StartCoroutine(animPlay());
                rising = false;
                Moving = false;
                hasRisen = true;
                infoScript.MakeModel();
            }
        }




        if (restartAnim)
        {
            if (transform.localPosition.y <= 140)
            {
                anim.SetBool("StopPrinting", false);
                Moving = true;
                transform.Translate(0, 0.01f, 0);
               
            }
            else
            {
                
                restartAnim = false;
                Moving = false;
                model.SetActive(false);
                model = holdModel;
                model.SetActive(true);
                canGo = true;
            }

            return;
        }




        if (transform.localPosition.y >= 0 && canGo )
        {
            warningText.SetActive(true);
            fPickupScript.enabled = false;
            model.SetActive(true);
            
            if(!donePrinting)
            {
                speaker.enabled = true;
                speaker.playOnAwake = true;
                Moving = true;
                transform.Translate(0, -0.005f, 0);
               
            }
            else
            {
                speaker.enabled = false;
                Moving = true;
                transform.Translate(0, -0.01f, 0);
            }
            Moving = false;
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
            //Debug.Log("EP");
            instructionsSpace.SetActive(false);
            instructions.SetActive(true);
            model.tag = "Interactable";
            speaker.enabled = false;
            stopPrinting = true;
            warningText.SetActive(false);

            Reset();
        }
    }




    public void Printing()
    {
        GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().objectPrinting = true;
        rising = true;
        Moving = true;
        if(hasRisen)
        {
            canGo = true;
            Moving = false;
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
        //Debug.Log("SP");
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
