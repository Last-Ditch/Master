using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour
{
    public void Sliced()
    {

        GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>().sliced = true;
    }
}
