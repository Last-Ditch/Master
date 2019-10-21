using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChoice : MonoBehaviour
{
    public GameObject defaultObj, currentObj;
    public GameObject Obj1, Obj2, Obj3;

    void Start()
    {
        currentObj = defaultObj;
        currentObj.SetActive(true);
    }


    void Update()
    {
        
    }

    public void SetObj(int i)
    {
        switch (i)
        {
            case 3:
                currentObj.SetActive(false);
                currentObj = Obj3;
                currentObj.SetActive(true);
                break;
            case 2:
                currentObj.SetActive(false);
                currentObj = Obj2;
                currentObj.SetActive(true);
                break;
            case 1:
                currentObj.SetActive(false);
                currentObj = Obj1;
                currentObj.SetActive(true);
                break;
            default:
                currentObj.SetActive(false);
                currentObj = defaultObj;
                currentObj.SetActive(true);
                break;
        }
    }


}
