using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamage : MonoBehaviour
{

    public GameObject damageeffect;
    public AudioClip boom;
    AudioSource speaker;
    private void Start()
    {
        speaker = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag == "Interactable")
        {
            //puts in a quad with a hole effect for the target
            GameObject g = Instantiate(damageeffect, new Vector3(collision.transform.position.x, collision.transform.position.y, -15.38f), Quaternion.LookRotation(Vector3.back, Vector3.up));
            speaker.PlayOneShot(boom);
        }
    }

}
