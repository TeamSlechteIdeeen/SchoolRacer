using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainSoundFX : MonoBehaviour {
    public AudioSource BumpSound;
    public AudioSource StartSound;
    public bool start;
    // Use this for initialization
    void Start () {
        BumpSound = GetComponent<AudioSource>();
        StartSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (start)
        {
            StartSound.Play();
        }
        if (col.gameObject.name == "PlayerTrigger")
        {
            BumpSound.Play();
        }
    }
}
