using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{

    public bool paused = false;
    public static bool canPause = true;
    public GameObject pause_menu_ui;

    public GameObject game_ui;


    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            if (!paused)
            {
                pause();
            }
        }

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Time.timeScale = 1f;
            paused = false;
            resume();
        }
    }

    void pause()
    {
        Cursor.visible = true;
        game_ui.SetActive(false);
        pause_menu_ui.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        Cursor.lockState = CursorLockMode.None;
        AudioListener.pause = true;
    }

    public void resume()
    {
        game_ui.SetActive(true);
        pause_menu_ui.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioListener.pause = false;

    }


    public void quit()
    {
        Application.Quit();
    }
}
