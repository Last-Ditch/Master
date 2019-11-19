using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ProgressTracker : MonoBehaviour
{
    public bool sliced, sdIn, supportsAdded;
    public bool MatPicked, LHPicked, InfillPicked, modelPicked, TpuPicked, enteredSlicr,
        sdPickedUp, filamentPickedUp, filamenttBackofPrinter, enterUltimakerMenu, insertFilament, objectPrinting;
    public int MaterialC, LayerHeightC, InfillC, ModelPicked;


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Progress");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        PlayerPrefs.SetInt("Disabled", 1);
    }

    public void Material(int i)
    {
        MatPicked = true;
        MaterialC = i;
        if(i == 3)
        {
            TpuPicked = true;
        }
        else
        {
            TpuPicked = false;
        }
    }

    public void LayerHeight(int i)
    {
        LHPicked = true;
        LayerHeightC = i;

    }

    public void Infill(int i)
    {
        InfillPicked = true;
        InfillC = i;
    }

    public void ModelChosen(int i)
    {
        modelPicked = true;
        ModelPicked = i;
    }

    public void Reset()
    {
        MatPicked = false;
        LHPicked = false;
        InfillPicked = false;
    }
}