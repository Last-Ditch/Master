using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMove : MonoBehaviour
{
    public GameObject center;
    public static float speed;
    public bool hourHand;
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
