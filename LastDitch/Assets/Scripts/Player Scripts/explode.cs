using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public GameObject destroyed_model;

    private void OnCollisionEnter(Collision other)
    {
       
        if(other.gameObject.tag == "Wall")
        {
            Instantiate(destroyed_model, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


}
