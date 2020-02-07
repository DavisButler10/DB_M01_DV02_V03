using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum steeringBehaviors
{
    Seek, Flee, Arrive, Align, Face, LookWhereGoing , SeekLWYG, PathFollow, Pursue, Seperation, None
}

public class Kinematic : MonoBehaviour
{

    public Vector3 linearVelocity;
    public float angularVelocity; 
    public Kinematic target;
    public Kinematic[] pathArray;
    public Kinematic[] objectArray;
    PathFollow follow = new PathFollow();
    
    LookWhereGoing face1 = new LookWhereGoing();



    public steeringBehaviors choiceOfBehavior;

    
    void Update()
    {
        switch (choiceOfBehavior)
        {
            case steeringBehaviors.None:
                ResetOrientation();
                break;
            default:
                MainSteeringBehaviors();
                break;
        }
    }


    void MainSteeringBehaviors()
    {
        ResetOrientation();

        switch (choiceOfBehavior)
        {
            case steeringBehaviors.Seek:
                Seek seek = new Seek();
                seek.character = this;
                seek.target = target;
                SteeringOutput seeking = seek.getSteering();
                if (seeking != null)
                {
                    linearVelocity += seeking.linearVelocity * Time.deltaTime;
                    angularVelocity += seeking.angularVelocity * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Flee:
                Flee flee = new Flee();
                flee.character = this;
                flee.target = target;
                SteeringOutput fleeing = flee.getSteering();
                if (fleeing != null)
                {
                    linearVelocity += fleeing.linearVelocity * Time.deltaTime;
                    angularVelocity += fleeing.angularVelocity * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Align:
                Align align = new Align();
                align.character = this;
                align.target = target;
                SteeringOutput aligning = align.getSteering();
                if (aligning != null)
                {
                    linearVelocity += aligning.linearVelocity * Time.deltaTime;
                    angularVelocity += aligning.angularVelocity * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Face:
                Face face = new Face();
                face.character = this;
                face.target = target;
                SteeringOutput facing = face.getSteering();
                if (facing != null)
                {
                    linearVelocity += facing.linearVelocity * Time.deltaTime;
                    angularVelocity += facing.angularVelocity * Time.deltaTime;
                }
                break;
            case steeringBehaviors.LookWhereGoing:
                LookWhereGoing look = new LookWhereGoing();
                look.character = this;
                look.target = target;
                SteeringOutput looking = look.getSteering();
                if (looking != null)
                {
                    linearVelocity += looking.linearVelocity * Time.deltaTime;
                    angularVelocity += looking.angularVelocity * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Arrive:
                Arrive arrive = new Arrive();
                arrive.character = this;
                arrive.target = target;
                SteeringOutput arriving = arrive.getSteering();
                if (arriving != null)
                {
                    linearVelocity += arriving.linearVelocity * Time.deltaTime;
                    angularVelocity += arriving.angularVelocity * Time.deltaTime;
                }
                break;
            case steeringBehaviors.SeekLWYG:
                LookWhereGoing lwyg = new LookWhereGoing();
                Seek seek1 = new Seek();
                seek1.character = this;
                seek1.target = target;
                lwyg.character = this;
                lwyg.target = target;
                SteeringOutput seeker = seek1.getSteering();
                SteeringOutput lwyger = lwyg.getSteering();
                if (seeker != null && lwyger != null)
                {
                    linearVelocity += seeker.linearVelocity * Time.deltaTime;
                    angularVelocity += lwyger.angularVelocity * Time.deltaTime;
                }
                break;
            case steeringBehaviors.PathFollow:

                follow.character = this;
                face1.character = this;

                follow.path = pathArray;
                face1.target = target;


                SteeringOutput following = follow.getSteering();
                SteeringOutput facer1 = face1.getSteering();
                
                if (following != null)
                {
                    linearVelocity += following.linearVelocity * Time.deltaTime;
                    //angularVelocity += facer1.angularVelocity * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Pursue:
                Pursue pursue = new Pursue();
                pursue.character = this;
                face1.character = this;
                pursue.target = target;
                face1.target = target;
                //Debug.Log(target);
                SteeringOutput pursuing = pursue.getSteering();
                SteeringOutput facer2 = face1.getSteering();
                if (pursuing != null)
                {
                    linearVelocity += pursuing.linearVelocity * Time.deltaTime;
                    //angularVelocity += pursuing.angularVelocity * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Seperation:
                Seperation seperation = new Seperation();
                LookWhereGoing face4 = new LookWhereGoing();
                seperation.character = this;
                face4.character = this;

                seperation.targets = objectArray;
                face4.target = target;
                Debug.Log(target);
                SteeringOutput seperationing = seperation.getSteering();
                SteeringOutput facer3 = face4.getSteering();
                //SteeringOutput facing2 = face2.getSteering();
                if (seperationing != null)
                {
                    linearVelocity += seperationing.linearVelocity * Time.deltaTime;
                    angularVelocity += seperationing.angularVelocity * Time.deltaTime;
                }
                break;

        }

    }

    void ResetOrientation()
    {
        transform.position += linearVelocity * Time.deltaTime;
        Vector3 angularVelocityIncrement = new Vector3(0, angularVelocity * Time.deltaTime, 0);
        if (!float.IsNaN(angularVelocityIncrement.y))
        {
            transform.eulerAngles += angularVelocityIncrement;
        }
        
    }

}