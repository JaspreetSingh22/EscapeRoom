using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();    
    }
    public void onPlay()
    {
        Time.timeScale = 1.0f;
        animator.SetTrigger("Move");
    }
    public void onHelp()
    {
        SceneManager.LoadScene("Help");
    }
    public void OnBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void AnimationDone()
    {
        Destroy(gameObject);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
