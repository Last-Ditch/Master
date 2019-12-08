using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    //destroy gameobject after time


    public float life_time = 5;

    
    void Start()
    {
        StartCoroutine(kill());
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(life_time);

        Destroy(gameObject);
    }
}
