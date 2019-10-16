using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyDown : MonoBehaviour
{
    public GameObject model;
    //197.4

    // Start is called before the first frame update
    void Start()
    {
        model = GameObject.FindGameObjectWithTag("Pyr3");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y >= 0)
        {
            transform.Translate(0, -0.001f, 0);
        }
    }
}
