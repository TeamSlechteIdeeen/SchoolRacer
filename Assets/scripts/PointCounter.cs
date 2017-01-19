using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour {
    public GameObject player;
    public int MinimalPoints = 200;
    public int MaxTrackTime = 150;
    public float totalpoints;
    public Text PointText;
    // Use this for initialization
    void Start () {
        PointText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<NewBehaviourScript>().ActivatePointSystem)
        {
            totalpoints = MinimalPoints + (MaxTrackTime - Mathf.Round(player.GetComponent<NewBehaviourScript>().Timer));
            PointText.text = "Points: " + totalpoints;
        }
	}
}
