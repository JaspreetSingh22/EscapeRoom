using Unity.VisualScripting;
using UnityEngine;

public class DoorPressuerPlate : MonoBehaviour
{
    GameObject onPlate;
    Animator animator;
    public Animator doorANI;
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
                doorANI.SetBool("DoorOpen", true) ;
                Debug.Log("Plate pressed");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == onPlate)
        {
            animator.SetBool("PlatePressed", false);
            Debug.Log("Plate relased");
            doorANI.SetBool("DoorOpen", false);
            onPlate = null;
        }
    }
}
