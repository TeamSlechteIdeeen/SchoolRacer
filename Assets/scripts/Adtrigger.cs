using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements; // Using the Unity Ads namespace.

public class Adtrigger : MonoBehaviour {
    public bool ShowAd;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    IEnumerator Update() { 
        if (ShowAd)
        {
            while (!Advertisement.isInitialized || !Advertisement.IsReady())
            {
                yield return new WaitForSeconds(0.5f);
            }

            // Show the default ad placement.
            Advertisement.Show();
        }
    }
}
