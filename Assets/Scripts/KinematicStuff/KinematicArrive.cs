using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicArrive : MonoBehaviour
{
    float maxSpeed = 5f; //speed of enemy
    public Transform player; //target
    public Transform enemy; //seeker
    public float radius;
    public float timeToTarget = 2f;
    private GameObject[] list;
    int i = 0;

    //class to hold velocity and orientation
    class KinematicSteeringOutput
    {
        public Vector3 velocityTrans;
        public Vector3 velocityAng;
    }

    //update loop to update position and orientation from other functions
    void FixedUpdate()
    {
        if (i % 1000 == 0)
        {
            do {
                list = GameObject.FindGameObjectsWithTag("Enemy");
                player = list[Random.Range(0, list.Length)].transform;
            } while (player.name == this.name);

        }
        KinematicSteeringOutput blackMagic = getSteering();
        enemy.transform.position += blackMagic.velocityTrans * Time.deltaTime; //updates translational pos
        enemy.transform.eulerAngles = blackMagic.velocityAng; //updates rotational pos
        i++;
    }

    //creates object with velocity and orientation, then canlculates and returns new orientation and velocity
    KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();
        float angleDeg;

        result.velocityTrans = player.position - enemy.position; //calc dif in position

        if(result.velocityTrans.magnitude < radius)
        {
            angleDeg = newOrientation(enemy.transform.eulerAngles.y, result.velocityTrans); //call orientation to get orientation
            angleDeg *= Mathf.Rad2Deg; //turn rad to deg 
            result.velocityAng = new Vector3(0, angleDeg, 0);

            result.velocityTrans = Vector3.zero;

            return result;
        }

        result.velocityTrans /= timeToTarget;

        if(result.velocityTrans.magnitude > maxSpeed)
        {
            result.velocityTrans.Normalize(); //normalize previous difference
            result.velocityTrans *= maxSpeed; //multiply speed by vector velocity
        }

        angleDeg = newOrientation(enemy.transform.eulerAngles.y, result.velocityTrans); //call orientation to get orientation
        angleDeg *= Mathf.Rad2Deg; //turn rad to deg

        result.velocityAng = new Vector3(0, angleDeg, 0); //set orientation to vector3

        return result;
    }


    //checks for velocity and returns orientation otherwise
    float newOrientation(float current, Vector3 velocity)
    {
        if (velocity != Vector3.zero)
        {
            return (Mathf.Atan2(velocity.x, velocity.z));
        }
        else
        {
            return current;
        }
    }
}
