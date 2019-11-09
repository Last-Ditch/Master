using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamage : MonoBehaviour
{

    [SerializeField] GameObject damageeffect;
    

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(12312313);
        GameObject g = Instantiate(damageeffect, new Vector3(collision.transform.position.x, collision.transform.position.y, -15.55f), Quaternion.LookRotation(Vector3.back,Vector3.up));
        if (collision.gameObject.tag == "Interactable")
        {

               
            
        }
    }

}
