using UnityEngine;
using System.Collections;
public class Patrol : MonoBehaviour
{

    // put the points from unity interface
    public Transform[] wayPointList;

    public int ResetAfter = 0;
    public int currentWayPoint = 0;
    Transform targetWayPoint;

    public Rigidbody rb;

    int randomvar;
    float speed;
    // Use this for initialization
    void Start()
    {
        randomvar = Random.Range(60, 70);
        speed = randomvar / 10;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if we have somewere to walk
        if (currentWayPoint < this.wayPointList.Length)
        {
            if (targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            walk();
        }
    }

    void walk()
    {
        //base the speed of the NPC vehicles on a random float between 6.5 and 7, to avoid "waypoint fighting"
        randomvar = Random.Range(60, 70);
        speed = randomvar / 10;

        // rotate towards the target
        transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);

        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);


        if (transform.position == targetWayPoint.position)
        {
            if(currentWayPoint >= ResetAfter)
            {
                currentWayPoint = 0;
            } else
            {
                currentWayPoint++;
            }
            targetWayPoint = wayPointList[currentWayPoint];
        }
    }
}