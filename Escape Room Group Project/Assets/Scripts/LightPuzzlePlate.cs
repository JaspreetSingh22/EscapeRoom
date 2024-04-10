using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzlePlate : MonoBehaviour
{
    GameObject onPlate;
    Animator animator;
    public LightPuzzleMnaager LPM;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (onPlate == null)
            {
                onPlate = other.gameObject;
                animator.SetBool("PlatePressed", true);
                LPM.CheckLight(1);
               
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == onPlate)
        {
            animator.SetBool("PlatePressed", false);
            LPM.CheckLight(-1);
            onPlate = null;
        }
    }

}
