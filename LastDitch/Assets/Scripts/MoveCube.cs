using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public GameObject target;
    public Transform paper;
    float distance = 2.0f;
    float xSpeed = 2.0f;
    float ySpeed = 4.0f;
    float smoothTime = 5f;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;
    float scrollFactor = 0;
    Quaternion Rot;
    Vector3 Scale;
    void Start()
    {
        Scale = new Vector3(1, 1, 1);

        paper = target.transform.GetChild(0);
        Vector3 angles = target.transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
    }
    void Update()
    {


        target.transform.eulerAngles = new Vector3(Rot.x, Rot.y, Rot.z);
        target.transform.localScale = new Vector3(Scale.x, Scale.y, Scale.z);
        paper.gameObject.SetActive(true);

        if (Input.GetMouseButton(2))
        {
            float DragX = (Input.GetAxis("Mouse X"));
            float DragY = (Input.GetAxis("Mouse Y"));
            target.transform.position = new Vector3(target.transform.position.x - DragX * 10, target.transform.position.y + DragY * 10, target.transform.position.z);
        }

        if (Input.GetMouseButton(1) && !Input.GetMouseButton(2))
        {
            velocityX -= xSpeed * Input.GetAxis("Mouse X") * distance * 0.06f;
            velocityY -= ySpeed * Input.GetAxis("Mouse Y") * -0.06f;
        }
        rotationYAxis += velocityX;
        rotationXAxis -= velocityY;
        Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
        Quaternion rotation = toRotation;
        target.transform.rotation = rotation;
        velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
        velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);

        float scrollFactor = Input.GetAxis("Mouse ScrollWheel");

        if (scrollFactor != 0)
        {
            target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z + (scrollFactor * 1000));
        }




        Rot = Quaternion.Euler(new Vector3(target.transform.localRotation.x, target.transform.localRotation.y, target.transform.localRotation.z));
        Scale = new Vector3(target.transform.localScale.x, target.transform.localScale.y, target.transform.localScale.z);
    }


    public void Reset()
    {
        target.transform.rotation = Quaternion.identity;
        distance = 2.0f;
        xSpeed = 2.0f;
        ySpeed = 4.0f;
        smoothTime = 2f;
        rotationYAxis = 0.0f;
        rotationXAxis = 0.0f;
        velocityX = 0.0f;
        velocityY = 0.0f;
    }
}
