using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUps : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Other")
        {

            if (other.GetComponent<PopUpObject>())
            {
                other.gameObject.GetComponent<PopUpObject>().lookedAT = true;
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
