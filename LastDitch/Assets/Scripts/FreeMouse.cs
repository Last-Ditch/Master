using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool cursorLocked;

    // Update is called once per frame
    void Update()
    {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        
    }
}

