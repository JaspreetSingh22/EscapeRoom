using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player_01;
    public GameObject Player_02;
    public float AniTime = 2f;
    float currentTime;
    public GameObject SplitScreen;
    bool animating = true;
    GameObject bootMan;

    // Start is called before the first frame update
    void Start()
    {
        //inital varible assigning.
        {
            currentTime = 0;
            
            bootMan = GameObject.Find("BootManager");
        }  
    }

    // Update is called once per frame
    void Update()
    {
        //seprates the object and move them apart for AniTime once done will call a function addProperty.
        if(animating)
        {
            if (currentTime <= AniTime)
            {
                Player_01.transform.Translate(Vector3.left * 1 * Time.deltaTime);
                Player_02.transform.Translate(Vector3.right * 1 * Time.deltaTime);
            }
            else
            {
                addproperty();
                animating = false;
               
            }
            currentTime += Time.deltaTime;
        }
    }

    //Will addproperties like rigidbody and set the split screen active.
    void addproperty()
    {
        Player_01.GetComponent<CharacterController>().enabled = true;
        Player_02.GetComponent<CharacterController>().enabled = true;
        SplitScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       
        Destroy(bootMan);
    }
}
