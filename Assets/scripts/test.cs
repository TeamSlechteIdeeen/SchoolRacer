using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
    private Vector3 velocity;

    public float forwardSpeed = 3.0f;
    public float backwardSpeed = 2.0f;
    public bool ready;

    public Rigidbody rb;
    /*public AudioSource EngineSound;

    public enum EngineAudioOptions // Options for the engine audio
    {
        Simple, // Simple style audio
        FourChannel // four Channel audio
    }*/

    //public EngineAudioOptions engineSoundStyle = EngineAudioOptions.FourChannel;// Set the default audio options to be four channel
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //EngineSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
     
    void OnGUI()
    {
        while (GUI.RepeatButton(new Rect(1400, 600, 180, 220), "Forward") == true && ready == true)
        {
            var locVel = transform.InverseTransformDirection(rb.velocity);
            locVel.z = forwardSpeed;
            rb.velocity = transform.TransformDirection(locVel);

            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * forwardSpeed);
            //EngineSound.Play();
            //EngineSound.pitch += 0.5f * Time.deltaTime;

        }
       
        while (GUI.RepeatButton(new Rect(10, 600, 180, 220), "Backward") == true && ready == true)
        {
            var locVel = transform.InverseTransformDirection(rb.velocity);
            locVel.z = backwardSpeed;
            rb.velocity = transform.TransformDirection(locVel);

            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * backwardSpeed);
        }
    }

    void Update()
    {
        if(ready == true)
        {
            float v = Input.GetAxis("Vertical");
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * backwardSpeed * v * 5 * -1);
        }
    }
}


