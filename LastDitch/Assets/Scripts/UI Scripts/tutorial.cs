using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    public GameObject wasd;
    public GameObject pause_button;

    public static tutorial instance = null;

    private void Start()
    {
       
        if (!instance)
        {
            instance = this;
            wasd.SetActive(true);
            pause_button.SetActive(true);
            StartCoroutine(kill());
        }
        else
        {
            Destroy(wasd);
            Destroy(pause_button);
            return;
        }



        DontDestroyOnLoad(this.gameObject);
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(25);

        Destroy(wasd);
        Destroy(pause_button);
    }

   

    int lastSceneIndex = -1;

    

    public int scene_number;

    public void load_scene(int scene_number)
    {
        lastSceneIndex = SceneManager.GetActiveScene().buildIndex;

    }
    
}