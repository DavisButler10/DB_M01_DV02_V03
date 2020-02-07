using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : Arrive
{
    public Kinematic[] path;

    int pathIndex;

    float radius = 0.5f;

    public override SteeringOutput getSteering()
    {
        if(target == null)
        {
            pathIndex = 0;
            target = path[pathIndex];
        }

        float distanceToTarget = (target.transform.position - character.transform.position).magnitude;
        if(distanceToTarget < radius)
        {
            pathIndex++;
            if(pathIndex > path.Length - 1)
            {
                pathIndex = 0;
            }
            target = path[pathIndex];
        }
        //Debug.Log(target);
        return base.getSteering();
    }
}
