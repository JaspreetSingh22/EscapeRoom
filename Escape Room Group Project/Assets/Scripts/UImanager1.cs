using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager1 : MonoBehaviour
{
   
    public void OnSceneChange(string sceneName)
    {
        if(sceneName == "Boot")
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }   
    }
}
