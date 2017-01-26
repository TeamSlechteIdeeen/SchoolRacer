using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour
{
    public AudioSource BoopFX;
    public float Speed = 0.1f;
    void Start()
    {
        BoopFX = GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.Rotate(0, (Input.GetAxis("Horizontal") * Speed * 15), 0);
        transform.Rotate(0, (Input.acceleration.x * Speed * 10), 0);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Debug.Log("KRANKENHAUZE");
            BoopFX.Play();
        }
    }
}