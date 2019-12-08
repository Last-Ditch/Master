﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    Transform[] parts;
    public float health;
    public bool canBeDamaged;

    void Start()
    {
        //grab all layers of the model
        parts = GetComponentsInChildren<Transform>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        //if it hits a wall, deal damage
        if (collision.gameObject.tag == "Wall")
        {
            if(health > 0 & canBeDamaged)
            {
                canBeDamaged = false;
                health -= 10;
            }

            if (health <= 0)
            {
                foreach (Transform t in parts)
                {
                    if (t.gameObject.tag == "part")
                    {
                        //if object health reaches 0, unparent all parts and start destroy countdown
                        t.transform.parent = null;
                        t.GetComponent<Rigidbody>().isKinematic = false;
                        t.GetComponent<Rigidbody>().useGravity = true;
                        t.GetComponent<Collider>().enabled = true;
                        ObjectPickup.pickup = false;
                    }
                }
                StartCoroutine(Countdown());
            }
        }
    }



    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5);

        foreach (Transform t in parts)
        {
            Destroy(t.gameObject);
        }

    }
}
