using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPintCollide : MonoBehaviour {
    public GameObject bullet;
    public AudioSource GlassHitFX;
    public int HealthPoints = 100;
    public GameObject Player;
    
	// Use this for initialization
	void Start () {
        GlassHitFX = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "PlayerTrigger")
        {
            Debug.Log("FUKKN GLAZZ");
            GlassHitFX.Play();
            Player.GetComponent<NewBehaviourScript>().HealthDrop = true;
            Destroy(bullet, 0.15f);
        }
    }
}
