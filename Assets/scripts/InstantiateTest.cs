using UnityEngine;
using System.Collections;

public class InstantiateTest : MonoBehaviour
{
    public Rigidbody rocketPrefab;
    public GameObject BulletPrefab;
    public Transform barrelEnd;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("RUSH B SUKA");
            Rigidbody rocketInstance;
            
            rocketInstance = Instantiate(rocketPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            rocketInstance.AddForce(barrelEnd.up * 900);
            //rocketInstance.GetComponent<Rigidbody>().velocity = transform.GetComponent<Rigidbody>().velocity * 10;

            /*
            Vector3 start = transform.position;
            start += transform.up.normalized * 3;
            GameObject obj = (GameObject)Instantiate(BulletPrefab, start, transform.rotation);
            obj.GetComponent<Rigidbody>().velocity = transform.GetComponent<Rigidbody>().velocity;
            obj.GetComponent<Rigidbody>().AddForce(barrelEnd.forward * 5000);*/
        }
    }
}