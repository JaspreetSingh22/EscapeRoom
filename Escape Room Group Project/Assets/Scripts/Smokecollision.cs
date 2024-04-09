using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smokecollision : MonoBehaviour
{
    public GameObject FadeEffect;
    Animator animator;
    public GameObject Player01;
    public GameObject Player02;
    public Transform Point_01;
    public Transform Point_02;

    
    [SerializeField] float FadeTime;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            
            animator = FadeEffect.GetComponent<Animator>();
            FadeEffect.SetActive(true);
            StartCoroutine("startTimer");
            Debug.Log("Damage FromSmoke");
        }
    }
   
    IEnumerator startTimer()
    {
        
       
        yield return new WaitForSeconds(FadeTime);
        Player01.GetComponent<CharacterController>().enabled = false;
        Player02.GetComponent<CharacterController>().enabled = false;
        Player01.transform.position = Point_01.position;
        Player02.transform.position = Point_02.position;
        Player01.GetComponent<CharacterController>().enabled = true;
        Player02.GetComponent<CharacterController>().enabled = true;
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        FadeEffect.SetActive(false);
    }
}
