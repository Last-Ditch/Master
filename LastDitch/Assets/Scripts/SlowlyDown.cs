using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyDown : MonoBehaviour
{
    //197.4


    public AudioSource speaker;

    void Update()
    {
        if (transform.localPosition.y >= 0)
        {
            speaker.enabled = true;
            transform.Translate(0, -0.001f, 0);
        }
        else
        {
            speaker.enabled = false;
        }
    }
}
