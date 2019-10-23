using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{

    public float life_time = 5;

    // Update is called once per frame
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
