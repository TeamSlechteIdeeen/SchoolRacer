using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPint : MonoBehaviour {
    public GameObject FullPint;
    public GameObject HalfFullPint;
    public GameObject EmptyPint;
    public Renderer EmptyPintRenderer;
    public Transform koos;
    public float TimeBetweenPintAnimation = 1;

    public bool anim = false;
    public bool startAnimation;
    public bool animDone = true;
    private float timer;
    private float GlobalTimer;
    public bool allowPint = true;
    public float TimeBetweenPints = 10;
    private float pintSpawnTimer;
    private Vector3 KegRotation;
    // Use this for initialization
    void Start () {
        FullPint.SetActive(false);
        HalfFullPint.SetActive(false);
        EmptyPintRenderer = GetComponent<Renderer>();
        EmptyPintRenderer.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		GlobalTimer += Time.deltaTime;
        pintSpawnTimer += Time.deltaTime;
        if(pintSpawnTimer > TimeBetweenPints)
        {
            allowPint = true;
            pintSpawnTimer = 0;
        }
        if (startAnimation == true && allowPint == true)
        {
            anim = true;
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer < TimeBetweenPintAnimation)
            {
                Debug.Log("The glass is full");
                FullPint.SetActive(true);
                HalfFullPint.SetActive(false);
                EmptyPintRenderer.enabled = false;
            }
            if (timer > TimeBetweenPintAnimation)
            {
                Debug.Log("The glass is half full");
                FullPint.SetActive(false);
                HalfFullPint.SetActive(true);
                EmptyPintRenderer.enabled = false;
            }
            if (timer > (TimeBetweenPintAnimation * 2))
            {
                FullPint.SetActive(false);
                HalfFullPint.SetActive(false);
                EmptyPintRenderer.enabled = true;
            }
            if (timer > (TimeBetweenPintAnimation * 3))
            {
                Debug.Log("The glass is empty");
                allowPint = false;
                fire();
                EmptyPintRenderer.enabled = true;
                anim = false;
                timer = 0;
            }
        }

    }

    void fire()
    {
        KegRotation = new Vector3(0, 00, 0);
        var bullet = (GameObject)Instantiate(
           EmptyPint,
           koos.position,
           koos.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "VillainObjectTrigger")
        {
            Debug.Log("starting pint animation");
            if(animDone == true && allowPint == true)
            {
                startAnimation = true;
            }
        }
    }
}
