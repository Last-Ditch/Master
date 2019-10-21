using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyDown : MonoBehaviour
{
    //197.4


    bool canGo = false;

    public AudioSource speaker;

    private void OnEnable()
    {
        StartCoroutine(animPlay());
    }

    void Update()
    {
        if (transform.localPosition.y >= 0 && canGo)
        {
            speaker.enabled = true;
            transform.Translate(0, -0.001f, 0);
        }
        else
        {
            speaker.enabled = false;
        }
    }



    IEnumerator animPlay()
    {
        yield return new WaitForSeconds(8f);
        canGo = true;
    }
}
