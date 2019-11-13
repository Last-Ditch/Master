using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilamentChangeChildren : MonoBehaviour
{
    MeshRenderer[] children;
    MeshRenderer mine;

    void Start()
    {
        mine = GetComponent<MeshRenderer>();
        children = GetComponentsInChildren<MeshRenderer>();
    }

    
    void Update()
    {
        if(mine.material != children[1].material)
        {
            foreach(MeshRenderer m in children)
            {
                m.material = mine.material;
            }
        }
    }
	
}
