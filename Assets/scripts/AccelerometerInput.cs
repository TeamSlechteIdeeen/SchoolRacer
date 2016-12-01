using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour
{
    public float Speed = 0.1f;
    void Update()
    {
        transform.Rotate(0, (Input.GetAxis("Horizontal") * Speed * 15), 0);
        transform.Rotate(0, (Input.acceleration.x * Speed * 10), 0);
    }
}