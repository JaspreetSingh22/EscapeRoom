using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfPlate : MonoBehaviour
{
    GameObject onPlate;
    Animator animator;
    public GameObject Bookshelf;
    Animator bookshelfANI;
    private void Start()
    {
        animator = GetComponent<Animator>();
        bookshelfANI = Bookshelf.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (onPlate == null)
            {
                onPlate = other.gameObject;
                animator.SetBool("PlatePressed", true);
                bookshelfANI.SetTrigger("Flip");
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
