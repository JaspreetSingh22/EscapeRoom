using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzleMnaager : MonoBehaviour
{
    public float PlatesPressed = 0;
    public Renderer LightRen;

    private void Start()
    {
        LightRen = GetComponentInChildren<Renderer>();
    }
    
    public void CheckLight(float value)
    {
        PlatesPressed += value;
        if(PlatesPressed == 2)
        {
            LightRen.material.EnableKeyword("_EMISSION");
        }
        else
        {
            LightRen.material.DisableKeyword("_EMISSION");
        }
    }
}
