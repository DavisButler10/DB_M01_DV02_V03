using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align : MonoBehaviour
{
    public Kinematic character;
    public Kinematic target;

    float maxAngularAcceleration = 100f;
    float maxRotation = 45f;

    float slowRadius = 10f;

    float timeToTarget = 0.1f;


    protected virtual float getAngle()
    {
        return target.transform.eulerAngles.y;
    }

    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();


        float rotation = Mathf.DeltaAngle(character.transform.eulerAngles.y, getAngle());
        float rotationSize = Mathf.Abs(rotation);


        float myRotation = 0.0f;
        if (rotationSize > slowRadius)
        {
            myRotation = maxRotation;
        }
        else
        {
            myRotation = maxRotation * rotationSize / slowRadius;
        }


        myRotation *= rotation / rotationSize;


        result.angularVelocity = myRotation - character.angularVelocity;
        result.angularVelocity /= timeToTarget;

        result.linearVelocity = Vector3.zero;
        return result;
    }
}
