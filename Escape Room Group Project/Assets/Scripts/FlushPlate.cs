using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlushPlate : MonoBehaviour
{
    GameObject onPlate;
    Animator animator;
    public GameObject Code;

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
                Code.SetActive(true);

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == onPlate)
        {
            animator.SetBool("PlatePressed", false);
            
            onPlate = null;
        }
    }

}
