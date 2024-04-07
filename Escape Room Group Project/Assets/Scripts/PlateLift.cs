using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateLift : MonoBehaviour
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
            if (onPlate == null)
            {
                onPlate = other.gameObject;
                animator.SetBool("PlatePressed", true);
                LiftPressuer.Liftup = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == onPlate)
        {
            animator.SetBool("PlatePressed", false);
            LiftPressuer.Liftup = false;
            onPlate = null;
        }
    }

}
