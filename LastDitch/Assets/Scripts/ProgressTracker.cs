using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ProgressTracker : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Progress");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
       if(sliced && sdIn)
        {
            GameObject.FindGameObjectWithTag("Print").GetComponent<MeshRenderer>().enabled = true;
        }
    }


    public bool sliced, sdIn;

}