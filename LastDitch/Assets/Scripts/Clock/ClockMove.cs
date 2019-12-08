using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMove : MonoBehaviour
{
    public GameObject center;
    public static float speed;

    //set in inspector so one script can do both hands
    public bool hourHand;

    //make hands go spinny
    void Update()
    {
        if(!hourHand)
        {
            transform.RotateAround(center.transform.position, Vector3.right, speed * 0.05f * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(center.transform.position, Vector3.right, speed * Time.deltaTime);
        }
        
    }

}
