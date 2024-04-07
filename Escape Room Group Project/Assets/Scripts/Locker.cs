using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Locker : MonoBehaviour
{
    bool canInteract = false;

    [SerializeField] GameObject Ehud;
    [SerializeField] GameObject Keypad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             if(Ehud!= null)
            {
                Ehud.SetActive(true);
            }
           
            canInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(Ehud!= null)
            {
                Ehud.SetActive(false);
            }
            
            canInteract = false;
            if(Keypad!= null)
            {
            Keypad.SetActive(false);
            }
             
            Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void Interact()
    {
        if(canInteract)
        {
             if(Ehud!= null)
            {
                Ehud.SetActive(false);
            }
            if(Keypad!= null)
            {
            Keypad.SetActive(true);
            }
            
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        
    }
    public void TimeToClean()
    {
        Destroy(Ehud);
    }
}
