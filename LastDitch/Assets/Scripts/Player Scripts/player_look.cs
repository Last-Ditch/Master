using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_look : MonoBehaviour
{

    public float mouse_sensitivity = 150;                                               //mouse sensitivity
    private float x_axis_clamp = 0;                                                    //vaule to stop mouse roating too far on the Y axis
    private Transform player;                                                         //what ever object you want the camera's rotation to be based off i.e the player

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;                                  //locks the mouse to the center of the screen

        player = GameObject.FindGameObjectWithTag("Player").transform;            //sets the player transform to an object with the tag Player
}                                                         //calls all functions before application begins

void Update()
    {
        cam_rotate();                                                             //runs camera rotation function
    }                                                                   //calls function every frame

    void cam_rotate()
    {
        float mouse_X = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;        //gives the x posistion and rotation a value
        float mouse_Y = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;       //gives the y posistion and rotation a value

        x_axis_clamp += mouse_Y;                                                            //sets the axis clamp to be the vaule of the mouses Y value

        if (x_axis_clamp > 90f)
        {
            x_axis_clamp = 90f;
            mouse_Y = 0f;
            clamp_x_axis(270f);
        }
        else if (x_axis_clamp < -90f)
        {
            x_axis_clamp = -90f;
            mouse_Y = 0f;
            clamp_x_axis(90f);
        }

        transform.Rotate(Vector3.left* mouse_Y);
        player.Rotate(Vector3.up * mouse_X);

    }                                                          //all things to do with roatating the camera

    void clamp_x_axis(float value)
    {
        Vector3 euler_rotation = transform.eulerAngles;
        euler_rotation.x = value;
        transform.eulerAngles = euler_rotation;
    }

}
