using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPintCollide : MonoBehaviour {
    public GameObject bullet;
    public AudioSource GlassHitFX;
    public int HealthPoints = 100;
    public Text HealthText;
	// Use this for initialization
	void Start () {
        GlassHitFX = GetComponent<AudioSource>();
        HealthText.text = "ur health is 100% m8";
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
            if(HealthPoints > 0)
            {
                HealthPoints = HealthPoints - 10;
                HealthText.text = "ur health is " + HealthPoints + "% m8";
            } else
            {
                HealthText.text = "ur ded";
            }
            
            Destroy(bullet, 0.15f);
        }
    }
}
