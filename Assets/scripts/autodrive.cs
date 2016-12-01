using UnityEngine;
using System.Collections;

public class autodrive : MonoBehaviour {
    public float forwardSpeed = 3.0f;
    public Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 10 * forwardSpeed * 5);
    }
}
