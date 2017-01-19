using UnityEngine;
using System.Collections;

public class MoveTrainForward : MonoBehaviour
{
    public bool driveTrain;
    public Transform StartPosition;
    public Rigidbody rb;
    public float Timer;
    public float TrainBuildup;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //transform.Translate(Vector3.right * Time.deltaTime * 10);
        if (driveTrain == true)
        {
            Timer += Time.deltaTime;
            if(Timer < 10)
            {
                TrainBuildup = Timer * 200;
            }
            if(Timer > 19.9f)
            {
                TrainBuildup = 2000;
            }
            rb.AddForce(transform.right * TrainBuildup * -100);
        }
        if (driveTrain == false)
        {
            rb.AddForce(transform.right * 0);
            //transform.right = Vector3.RotateTowards(transform.right, StartPosition.position - transform.position, 10 * Time.deltaTime * 1, 0.0f);
            transform.position = Vector3.MoveTowards(transform.position, StartPosition.position, 10 * Time.deltaTime * 1000);
        }
    }
}