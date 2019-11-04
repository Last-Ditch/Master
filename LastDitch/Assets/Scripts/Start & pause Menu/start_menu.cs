using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_menu : MonoBehaviour
{

    public void play_game()
    {
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Application.Quit();
    }

}
