 using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    public float Lap = 1f;
    public float AmountOfLaps = 3f;

    public Text winText;
    //public AudioClip yay;
    //private AudioSource source;

    private int round = 0;
    private int finish = -1;
    private int checkpoint = 0;
    // Use this for initialization
    void Start () {
        //source = GetComponent<AudioSource>();
        winText.text = "Lap 1/3";
        Debug.Log("kek");
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "finish")
        {
            Debug.Log("booped da finish");
            
            finish++;
        }
        if (col.gameObject.name == "checkpoint1")
        {
            Debug.Log("booped da shagpoint");
            checkpoint++;
        }
        if(finish == checkpoint)
        {   if(finish > 3)
            {
                round = 3;
                //source.PlayOneShot(yay, 1);
            } else
            {
                round = finish;
            }
            winText.text = "Lap " + (round + 1) + "/3";
        }
    }
}
