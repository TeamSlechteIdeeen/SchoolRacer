using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour {
    public Transform[] wayPointList;
    public GameObject Dingske;
    public Renderer dinges;
    public bool showSprite;
    public string VillainName;
    private Vector3 randlocation;
    public int currentWayPoint = 0;
    //public GameObject Player2;
    public bool launch = false;
    // Use this for initialization
    Transform targetWayPoint;
    void Start () {
        dinges = GetComponent<Renderer>();
        dinges.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(launch == true)
        {
            Debug.Log("BLITZKRIEG!!!");
            //transform.forward = Vector3.RotateTowards(transform.forward, playerTrigger.position - transform.position, Time.deltaTime, 0.0f);
            //transform.position = Vector3.MoveTowards(transform.position, playerTrigger.position, Time.deltaTime);

            //transform.forward = Vector3.RotateTowards(transform.forward, playerTrigger.position - transform.position, 1 * Time.deltaTime, 0.0f);
            //transform.position = Vector3.MoveTowards(transform.position, playerTrigger.position, 1 * Time.deltaTime);
            if (currentWayPoint < this.wayPointList.Length)
            {
                if (targetWayPoint == null)
                    targetWayPoint = wayPointList[currentWayPoint];
                walk();
            }
        }
        if(showSprite == true)
        {
            dinges.enabled = true;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "PlayerTriggerBump")
        {
            Debug.Log("hit with an oktoberfest");
            dinges.enabled = false;
            walk();
        }
        if (col.gameObject.name == VillainName)
        {
            dinges.enabled = true;
        }
    }

    void walk()
    {
            //base the speed of the NPC vehicles on a random float between 6.5 and 7, to avoid "waypoint fighting"
           
            // rotate towards the target
            //transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, 1 * Time.deltaTime, 0.0f);

            // move towards the target
            //transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, 1 * Time.deltaTime);


            if (transform.position == targetWayPoint.position)
            {
                if (currentWayPoint >= 1)
                {
                    currentWayPoint = 1;
                }
                else
                {
                    currentWayPoint++;
                }
                targetWayPoint = wayPointList[currentWayPoint];
            }
    }
}
