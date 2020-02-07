using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee
{
    public Kinematic target;
    public Kinematic character;

    public float maxAcceleration = 2f;


    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        result.linearVelocity = character.transform.position - target.transform.position;

        result.linearVelocity.Normalize();
        result.linearVelocity *= maxAcceleration;

        result.angularVelocity = 0;
        return result;
    }
}