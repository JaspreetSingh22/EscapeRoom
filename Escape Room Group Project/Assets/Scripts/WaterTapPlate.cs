using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTapPlate : MonoBehaviour
{
    GameObject onPlate;
    Animator animator;
    public Sink sink;
   
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
                sink.canTapON = true;

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == onPlate)
        {
            animator.SetBool("PlatePressed", false);
            sink.canTapON = false;
            onPlate = null;
        }
    }

}
