using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeBlock : MonoBehaviour
{
    Vector3 IntPos;
    bool canMove = false;
    [SerializeField] float TimeToFall;
    [SerializeField] float TimeToUp;
    // Start is called before the first frame update
    void Start()
    {
       IntPos = transform.position;
    }
    private void Update()
    {
        if (canMove)
        {
            if(transform.position != IntPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, IntPos, Time.deltaTime);
            }
            else
            {
                canMove = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("FallDown");
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("BackToPostion");
        }

    }

    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(TimeToFall);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
    IEnumerator BackToPostion()
    {
        yield return new WaitForSeconds(TimeToUp);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        canMove = true;
       
    }
}
