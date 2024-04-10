using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public Text CountdownText;
    [SerializeField] float MaxTime;
    public GameManager GameManager;
    float currentTime;

    private void Start()
    {
        currentTime = MaxTime;
        UpdateUI();
        InvokeRepeating("UpdateTimer", 1f, 1f);

    }
    void UpdateTimer()
    { 

        if (GameManager.GameStart)
        {
            CountdownText.gameObject.SetActive(true);
            if (currentTime > 0)
            {
                currentTime -= 1f;
                UpdateUI();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("GameOver");
                CancelInvoke("UpdateTimer");
            }
        }
    }
    void UpdateUI()
    {
        int min = Mathf.FloorToInt(currentTime / 60);
        int sec = Mathf.FloorToInt(currentTime % 60);
        CountdownText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

}
