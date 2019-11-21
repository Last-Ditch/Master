using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    public GameObject wasd;
    public GameObject pause_button;
    public static bool playedAlready;


    private void Start()
    {
        StartCoroutine(kill());
    }


    private void Update()
    {
       
        if (!playedAlready)
        {
            wasd.SetActive(true);
            pause_button.SetActive(true);
            
        }
        else
        {
            wasd.SetActive(false);
            pause_button.SetActive(false);

        }
  
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(10);
        Debug.Log(3333333);
        playedAlready = true;
    }

   

    int lastSceneIndex = -1;

    

    public int scene_number;

     void load_scene(int scene_number)
    {
        lastSceneIndex = SceneManager.GetActiveScene().buildIndex;

    }
    
}