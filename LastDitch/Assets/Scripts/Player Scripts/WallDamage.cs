using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamage : MonoBehaviour
{

    [SerializeField] GameObject damageeffect;
    [SerializeField] AudioClip boom;
    AudioSource speaker;
    private void Start()
    {
        speaker = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        
        if (collision.gameObject.tag == "Interactable")
        {

            GameObject g = Instantiate(damageeffect, new Vector3(collision.transform.position.x, collision.transform.position.y, -15.55f), Quaternion.LookRotation(Vector3.back, Vector3.up));
            speaker.PlayOneShot(boom);
        }
    }

}
