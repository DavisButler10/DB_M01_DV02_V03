using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWhereGoing : Align
{
    public SteeringOutput getSteering()
    {
        Vector3 velocity = character.linearVelocity;
        if (velocity.magnitude == 0)
        { 
            return null;
        }

        float targetAngle = Mathf.Atan2(velocity.x, velocity.z);
        targetAngle *= Mathf.Rad2Deg;
        character.transform.eulerAngles = new Vector3(0, targetAngle, 0);

        return base.getSteering();
    }
}
