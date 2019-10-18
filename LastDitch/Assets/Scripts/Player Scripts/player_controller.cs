using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    private CharacterController char_control;
    public float walk_speed, run_speed;
    private float move_speed;
    private float accel;
    private float slope_force = 3f;
    private float slope_ray_lenght = 1.5f;

    private bool is_jumping;
    [SerializeField] public AnimationCurve jump_fall_curve;
    public float jump_multiplier = 10;

    private void Awake()
    {
        char_control = GetComponent<CharacterController>();
    }

     void Update()
    {
        player_move();

        
    }


    void player_move()
    {
        float vert = Input.GetAxis("Vertical");

        float horiz = Input.GetAxis("Horizontal");


        Vector3 move_forward = transform.forward * vert;
        Vector3 move_right = transform.right * horiz;

        char_control.SimpleMove(Vector3.ClampMagnitude( move_forward + move_right, 1f) * move_speed);


        if(vert != 0 || horiz != 0 && on_slope())
        {
            char_control.Move(Vector3.down * char_control.height / 2 * slope_force * Time.deltaTime);
        }

        movement_speed();

        jump_input();
    }

    void movement_speed()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            move_speed = Mathf.Lerp(move_speed, run_speed, Time.deltaTime * accel);
        }
        else
        {
            move_speed = Mathf.Lerp(walk_speed, walk_speed, Time.deltaTime * accel);
        }
    }

    private bool on_slope()
    {
        if (is_jumping)
        {
            return false;
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, char_control.height / 2 * slope_ray_lenght))
            if (hit.normal != Vector3.up)
                return true;

        return false;
    }

    void jump_input()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !is_jumping)
        {
            is_jumping = true;

            StartCoroutine(jumping());
        }
    }

    IEnumerator jumping()
    {
        float air_time = 0f;

        do
        {
            float jump_force = jump_fall_curve.Evaluate(air_time);

            char_control.Move(Vector3.up * jump_force * jump_multiplier * Time.deltaTime);

            air_time += Time.deltaTime;

            yield return null;
        }
        while (!char_control.isGrounded && char_control.collisionFlags != CollisionFlags.Above);

        is_jumping = false;
        
    }

}
