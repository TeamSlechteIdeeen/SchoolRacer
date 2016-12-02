 using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    public float Lap = 1f;
    public float AmountOfLaps = 3f;
    public AudioSource Music;

    public Text winText;
    //public AudioClip yay;
    //private AudioSource source;

    private int round = 0;
    private int finish = -1;
    private int checkpoint = 0;

    private string str = "";

    public enum EngineAudioOptions // Options for the engine audio
    {
        Simple, // Simple style audio
        FourChannel // four Channel audio
    }

    //public EngineAudioOptions engineSoundStyle = EngineAudioOptions.FourChannel;// Set the default audio options to be four channel
    // Use this for initialization
    void Start () {
        //source = GetComponent<AudioSource>();
        winText.text = "Lap 1/3";
        Music = GetComponent<AudioSource>();
        Debug.Log("kek");
        Music.Play();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "finish" && finish == checkpoint)
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
        {   if(checkpoint == 3)
            {
                //Music.Stop();
                //source.PlayOneShot(yay, 1);
                winText.text = "";
                Debug.Log("finish is bigger");
            }
            else
            {
                round = finish;
                Debug.Log("else");
            }
            winText.text = "Lap " + (round + 1) + "/3";
        }
    }
}
