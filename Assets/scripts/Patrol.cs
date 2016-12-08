using UnityEngine;
using System.Collections;
public class Patrol : MonoBehaviour
{

    // put the points from unity interface
    public Transform[] wayPointList;
    public Transform[] wayPointList2;

    public float MaxOffset = 0.1f;
    public float NPCForce = 0f;
    public float speed = 6;
    public int ResetAfter = 0;
    public int currentWayPoint = 0;
    public int currentWayPoint2 = 0;
    public bool ready;
    public bool pause = false;

    private int randlist = 0;
    private float offset = 0;
    private float Xrand;
    private float Yrand;
    private float Zrand;
    private Vector3 randlocation;
    private float speedvar;

    Transform targetWayPoint;

    public Rigidbody rb;

    int randomvar;
    // Use this for initialization
    void Start()
    {
        offset = Random.Range(-1.0f, 1.0f);
        randomvar = Random.Range(60, 70);
        speed = randomvar / 10;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        randlist = Random.Range(1, 2);
        // check if we have somewere to walk
        if (currentWayPoint < this.wayPointList.Length)
        {
            if (targetWayPoint == null)
                if (randlist == 1)
                {
                    targetWayPoint = wayPointList[currentWayPoint];
                }
                else
                {
                    targetWayPoint = wayPointList[currentWayPoint];
                }

            walk();
        }
    }

    void walk()
    {
        if (ready == true && pause == false)
        {
            //base the speed of the NPC vehicles on a random float between 6.5 and 7, to avoid "waypoint fighting"
            //randomvar = Random.Range(60, 70);
            //speed = randomvar / 10;
            // rotate towards the target

            //var locVel = transform.InverseTransformDirection(rb.velocity);
            //locVel.z = NPCVel;
            //rb.velocity = transform.TransformDirection(locVel);

            rb.AddForce(transform.forward * NPCForce);

            speedvar = Random.Range(0.1f, 2.0f);
            Xrand = targetWayPoint.position.x + offset;
            Yrand = targetWayPoint.position.y;
            Zrand = targetWayPoint.position.z + offset;
            randlocation = new Vector3(Xrand, Yrand, Zrand);

            //transform.forward = Vector3.RotateTowards(transform.forward, randlocation - transform.position, (speed * speedvar) * Time.deltaTime, 0.0f);
            //transform.position = Vector3.MoveTowards(transform.position, randlocation, (speed * speedvar) * Time.deltaTime);

            transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, (speed * speedvar) * Time.deltaTime, 0.0f);
            transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, (speed * speedvar) * Time.deltaTime);
            //Debug.Log();

            if (transform.position == targetWayPoint.position)
            {
                if (currentWayPoint >= ResetAfter)
                {
                    currentWayPoint = 0;
                }
                else
                {
                    currentWayPoint++;
                    //Debug.Log("ahm at point numba " + currentWayPoint);
                }
                targetWayPoint = wayPointList[currentWayPoint];
            }
        }
    }
}