using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftPressuer : MonoBehaviour
{
    public bool Liftup = false;
    [SerializeField] GameObject floor;
    [SerializeField] Transform point01;
    [SerializeField] Transform point02;
    [SerializeField] float liftSpeed;

    private void Update()
    {
        if (Liftup)
        {
            if(floor.transform.position != point02.position)
            {
                floor.transform.position = Vector3.MoveTowards(floor.transform.position, point02.position, liftSpeed* Time.deltaTime);
            }   
        }
        else
        {
            if (floor.transform.position != point01.position)
            {
                floor.transform.position = Vector3.MoveTowards(floor.transform.position, point01.position, liftSpeed* Time.deltaTime);
            }
        }
    }

}
