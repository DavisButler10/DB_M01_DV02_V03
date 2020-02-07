using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive
{
    public Kinematic character;
    public Kinematic target;

    float maxAcceleration = 10f;
    float maxSpeed = 10f;

    float myRadius = 0.4f;

    float slowRadius = 0.4f;

    float timeToTarget = 0.1f;

    protected virtual Vector3 getTargetPosition()
    {
        return target.transform.position;
    }

    public virtual SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        
        Vector3 direction = getTargetPosition() - character.transform.position;
        float distance = direction.magnitude;

        float targetSpeed = 0f;
        if (distance > slowRadius)
        {
            targetSpeed = maxSpeed;
        }
        else 
        {
            targetSpeed = maxSpeed * (distance - myRadius) / myRadius;
        }

        Vector3 targetVelocity = direction;
        targetVelocity.Normalize();
        targetVelocity *= targetSpeed;

        result.linearVelocity = targetVelocity - character.linearVelocity;
        result.linearVelocity /= timeToTarget;

        if (result.linearVelocity.magnitude > maxAcceleration)
        {
            result.linearVelocity.Normalize();
            result.linearVelocity *= maxAcceleration;
        }

        return result;
    }
}
