using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float bulletSpeed;

    public float SecondsUntilDestroyed;
    public AudioSource PlaySound;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        ourRigidBody.velocity = transform.forward * bulletSpeed;
        PlaySound.Play();
        Destroy(gameObject,SecondsUntilDestroyed);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    SecondsUntilDestroyed -= Time.deltaTime;

    //    if (SecondsUntilDestroyed < 20)
    //    {
            
    //    }
    //    if(SecondsUntilDestroyed< 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

   
}
