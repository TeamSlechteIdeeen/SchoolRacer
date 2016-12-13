using UnityEngine;
using System.Collections;

public class UnityUIController : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject glass;
    private bool walkUp;
    //private bool walkLeft;
    //private bool walkRight;
    private bool walkDown;

    private Vector3 velocity;

    public float forwardSpeed = 3.0f;
    public float backwardSpeed = 2.0f;
    public bool ready;
    public bool pause = false;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {

        //if (walkUp == true && ready == true) waarom dit zo staat weet ik niet maar het werkt dus STFU
        if (walkUp == true && ready == true && pause == false && glass.GetComponent<DestroyGlass>().GlassLock == false)
        {
            
            if (pause == false)
            {
                Debug.Log("button forward true");
                float v = 28;
                var locVel = transform.InverseTransformDirection(rb.velocity);
                //locVel.z = forwardSpeed;
                locVel.z = forwardSpeed * 0.12f * v;
                rb.velocity = transform.TransformDirection(locVel);
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * backwardSpeed * v * 1f);
                rb.AddForce(transform.forward * forwardSpeed * 22f * v);
            }
        }
        else if (walkDown == true && ready == true && pause == false && glass.GetComponent<DestroyGlass>().GlassLock == false)
        {
            if (pause == false)
            {
                float v = -25;
                var locVel = transform.InverseTransformDirection(rb.velocity);
                //locVel.z = forwardSpeed;
                locVel.z = forwardSpeed * 0.12f * v;
                rb.velocity = transform.TransformDirection(locVel);
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * backwardSpeed * v * 1f);
                rb.AddForce(transform.forward * forwardSpeed * 220f * v);
                
            }
        }
        if (ready == true && pause == false && glass.GetComponent<DestroyGlass>().GlassLock == false)
        {
            float v = Input.GetAxis("Vertical");
            var locVel = transform.InverseTransformDirection(rb.velocity);
            //locVel.z = forwardSpeed;
            locVel.z = forwardSpeed * 0.12f * v;
            rb.velocity = transform.TransformDirection(locVel);
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * backwardSpeed * v * 1f);
            rb.AddForce(transform.forward * forwardSpeed * 22f * v);
        }
    }
    public void PlayerWalkUp(int value)
    {
        if (value == 1)
        {
            walkUp = true;
        }
        else
        {
            walkUp = false;
        }

    }

    /*public void PlayerWalkLeft(int value)
    {
        if (value == 1)
        {
            walkLeft = true;
        }
        else
        {
            walkLeft = false;
        }

    }

    public void PlayerWalkRight(int value)
    {
        if (value == 1)
        {
            walkRight = true;
        }
        else
        {
            walkRight = false;
        }

    }*/

    public void PlayerWalkDown(int value)
    {
        if (value == 1)
        {
            walkDown = true;
        }
        else
        {
            walkDown = false;
        }

    }
}