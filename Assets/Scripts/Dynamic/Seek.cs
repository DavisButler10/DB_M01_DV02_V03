using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek
{
    public Kinematic target;
    public Kinematic character;

    public float maxAcceleration = 1f;

    protected virtual Vector3 getTargetPosition()
    {
        return target.transform.position;
    }

    public virtual SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        result.linearVelocity = getTargetPosition() - character.transform.position;
        result.linearVelocity.Normalize();
        result.linearVelocity *= maxAcceleration;

        result.angularVelocity = 0;
        
        return result;
    }
}