using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{

    private void Start()
    {
        gameObject.GetComponent<Image>().enabled = true;

        StartCoroutine(kill());
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(25);

        Destroy(gameObject);
    }

    void OnEnable() { SceneManager.sceneUnloaded += SceneUnloadedMethod; }
    void OnDisable() { SceneManager.sceneUnloaded -= SceneUnloadedMethod; }

    int lastSceneIndex = -1;

    // looks a bit funky but the method signature must match the scenemanager delegate signature
    void SceneUnloadedMethod(Scene sceneNumber)
    {
        int sceneIndex = sceneNumber.buildIndex;
        // only want to update last scene unloaded if were not just reloading the current scene
        if (lastSceneIndex != sceneIndex)
        {
            lastSceneIndex = sceneIndex;
            Debug.Log("unloaded scene is : " + lastSceneIndex);
        }
    }
    public int GetLastSceneNumber()
    {
        return lastSceneIndex;
    }
}