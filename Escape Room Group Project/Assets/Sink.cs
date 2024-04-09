using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public Transform Splash;
    public Transform WaterLayer;
    public Transform LevelPoint;
    public bool canTapON = false;
    public GameObject WaterEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canTapON)
        {
            if(WaterLayer.position.y < LevelPoint.position.y)
            {
                WaterEffect.SetActive(true);
                WaterLayer.transform.Translate(Vector3.up * Time.deltaTime * 0.05f);
                Splash.transform.Translate(Vector3.forward * Time.deltaTime * 0.05f);
            }
            else
            {
                canTapON = false;
                WaterEffect.SetActive(false);
            }
        }
        else
        {
            WaterEffect.SetActive(false);
        }
    }
}
