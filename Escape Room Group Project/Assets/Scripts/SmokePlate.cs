using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokePlate : MonoBehaviour
{
    GameObject onPlate;
    Animator animator;
    public GameObject SmokeEffect;
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
                SmokeEffect.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == onPlate)
        {
            animator.SetBool("PlatePressed", false);
            SmokeEffect?.SetActive(true);
            onPlate = null;
        }
    }

}
