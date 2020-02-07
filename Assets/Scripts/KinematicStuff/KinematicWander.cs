using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicWander : MonoBehaviour
{
    float maxSpeed = 10f; //speed of enemy
    float maxRotation = 10f;
    public Transform enemy; //seeker

    //class to hold velocity and orientation
    class KinematicSteeringOutput
    {
        public Vector3 velocityTrans;
        public Vector3 velocityAng;
    }

    //update loop to update position and orientation from other functions
    void Update()
    {

            KinematicSteeringOutput blackMagic = getSteering();
            
            enemy.transform.position += blackMagic.velocityTrans * Time.deltaTime;
            enemy.transform.eulerAngles += blackMagic.velocityAng; 
        
            
    }

    //creates object with velocity and orientation, then canlculates and returns new orientation and velocity
    KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();


        result.velocityTrans = maxSpeed * new Vector3(Mathf.Cos(enemy.eulerAngles.y), 0, Mathf.Sin(enemy.eulerAngles.y));

        result.velocityAng = new Vector3(0, randomBinomial() * maxRotation, 0);

        return result;
    }
    
    float randomBinomial()
    {
        return Random.Range(0f, 1f) - Random.Range(0f, 1f);
    }

   

}
