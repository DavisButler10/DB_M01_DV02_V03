using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{
    public SteeringOutput getSteering()
    {
        Vector3 direction = target.transform.position - character.transform.position;
        if(direction.magnitude == 0)
        {
            return null;
        }
        base.target = target;

        float targetAngle = Mathf.Atan2(direction.x, direction.z); 
        targetAngle *= Mathf.Rad2Deg;
        base.target.transform.eulerAngles = new Vector3(0, targetAngle, 0);

        return base.getSteering();
    }
}
