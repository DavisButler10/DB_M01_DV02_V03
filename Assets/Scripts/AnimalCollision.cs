using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollision : MonoBehaviour
{
    public GameObject chicken;
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Chicken")
        {
            
            
        }
    }

    
}
