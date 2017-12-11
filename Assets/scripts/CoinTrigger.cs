using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTrigger : MonoBehaviour {

    public Text coinTxt;
    public NewBehaviourScript mainScript;
    public AudioSource coinSFX;

	// Use this for initialization
	void Start () {
        mainScript = mainScript.GetComponent<NewBehaviourScript>();
        coinSFX = coinSFX.GetComponent<AudioSource>();
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "player")
        {
            Debug.Log("The coin is touched");
            mainScript.coinCounter = mainScript.coinCounter + 1;
            coinTxt.text = "" + mainScript.coinCounter;
            coinSFX.Play();
            gameObject.SetActive(false);
            
        }
    }

}
