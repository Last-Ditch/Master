using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScenes(int index)
    {
        if(index == 0)
        {
            Audio.counter = 0;
        }
        SceneManager.LoadScene(index);
    }
}
