using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    
    public void onPlay()
    {
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }
}
