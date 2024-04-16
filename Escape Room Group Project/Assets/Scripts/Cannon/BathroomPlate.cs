using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomPlate : MonoBehaviour
{
    GameObject onPlate;
    Animator animator;
    public LiftPressuer LiftPressuer;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            print("hit");
            if (onPlate == null)
            {
                onPlate = other.gameObject;
                animator.SetBool("PlatePressed", true);
                LiftPressuer.Liftup = true;
            }
        }
    }
}
