using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject bulletPrefab;
    float secondsSinceLastShot;

    public float secondsBewteenShots;
    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastShot = secondsBewteenShots;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        Rigidbody ourRigidBody = GetComponent<Rigidbody>();

        secondsSinceLastShot += Time.deltaTime;
        
    }
    // Method to be called when the trigger is entered
        public void TriggerEntered()
        {
            if (secondsSinceLastShot >= secondsBewteenShots)
            {
                Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
                secondsSinceLastShot = 0;
            }
        }
}
