using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<CanvasGroup>().alpha -= 0.01f;
        if(GetComponent<CanvasGroup>().alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
