using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUps : MonoBehaviour
{
    FilamentPickup Fp;
    SDPickup Sd;
    PopUpObject popUpOther;

    private void Start()
    {
        Fp = GetComponent<FilamentPickup>();
        Sd = GetComponent<SDPickup>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Other")
        {            
            if (other.GetComponent<PopUpObject>())
            {
                popUpOther = other.gameObject.GetComponent<PopUpObject>();

                if (popUpOther.filamentTable)
                {
                    if(!Fp.haveFilament)
                    {
                        popUpOther.lookedAT = true;
                    }
                }
                if (popUpOther.filamentUltimaker)
                {
                    if (Fp.haveFilament)
                    {
                        popUpOther.lookedAT = true;
                    }
                }
                if (popUpOther.SD_Laptop)
                {
                    if (!Sd.haveCard)
                    {
                        popUpOther.lookedAT = true;
                    }
                }
                if (popUpOther.SD_Ultimaker)
                {
                    if (Sd.haveCard)
                    {
                        popUpOther.lookedAT = true;
                    }
                }

            }

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Other")
        {

            if (other.GetComponent<PopUpObject>())
            {
                other.gameObject.GetComponent<PopUpObject>().lookedAT = false;
            }

        }
    }
}
