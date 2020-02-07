using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAI : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animCat;
    public Animator animDog;
    public Animator animPengu;
    //public Animator animPengu2;
    public Animator animLion;
    public Animator animChicken;

    public float forwardForce = 500f;
    public float sidewaysForce = 500f;

    void Start()
    {
        animCat.SetInteger("Walk", 1);
        animDog.SetInteger("Walk", 1);
        animPengu.SetInteger("Walk", 1);
        animLion.SetInteger("Walk", 1);
        animChicken.SetInteger("Walk", 1);
        //animPengu2.SetInteger("Walk", 1);
    }
    

    void FixedUpdate()
    {
        //GameObject[] lions = GameObject.FindGameObjectsWithTag("Lion");
        //Animator[] lionAnim = new Animator[lions.Length];
        //for (int i = 0; i < lions.Length; i++)
        //{
        //    lionAnim[i] = lions[i].GetComponent<Animator>();
        //    lionAnim.
        //}

        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
