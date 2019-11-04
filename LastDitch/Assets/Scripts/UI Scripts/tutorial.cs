using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{

    private void Start()
    {
        gameObject.GetComponent<Image>().enabled = true;

        StartCoroutine(kill());
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(25);

        Destroy(gameObject);
    }


}