using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smokecollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Damage FromSmoke");
        }
    }
}
