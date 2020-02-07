using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seperation : Seek
{
    public Kinematic[] targets;

    float threshold = 8f;
    float maxThreshold = 10f;

    float decayCoefficient = 20f;

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        for (int i = 0; i < targets.Length; i++)
        {
            Vector3 direction = character.transform.position - targets[i].transform.position;
            float distance = direction.magnitude;
            float strength;
            Debug.Log(distance);
            if (distance < threshold)
            {
                strength = Mathf.Min(decayCoefficient / (distance * distance), maxAcceleration);
                
                direction.Normalize();
                result.linearVelocity += strength * direction;
                Debug.Log("Strength:" + strength);

            }
            else if(distance > maxThreshold)
            {
                strength = Mathf.Max(decayCoefficient / (distance * distance), maxAcceleration);

                direction.Normalize();
                result.linearVelocity -= strength * direction;
                Debug.Log("Strength:" + strength);
            }
            
        }

        return result;
    }
}
