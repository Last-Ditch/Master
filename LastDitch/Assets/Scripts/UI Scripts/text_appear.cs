using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class text_appear : MonoBehaviour
{
    public GameObject info_text;


    public void Start()
    {
        info_text.SetActive(false);
    }


    public void OnMouseEnter()
    {
        info_text.SetActive(true);

    }

    public void OnMouseExit()
    {
        info_text.SetActive(false);

    }
}
