using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    public float Lap = 1f;
    public float AmountOfLaps = 3f;
    public AudioSource Music;

    public Text winText;
    public Text TimerTxt;
    //public AudioClip yay;
    //private AudioSource source;

    private float Timer = 0f;
    private int round = 0;
    private int finish = -1;
    private int checkpoint = 0;
    private int TimeRnd = 0;

    private float min = 0;
    private float sec = 0;

    private string str = "";

    public enum EngineAudioOptions // Options for the engine audio
    {
        Simple, // Simple style audio
        FourChannel // four Channel audio
    }

    //public EngineAudioOptions engineSoundStyle = EngineAudioOptions.FourChannel;// Set the default audio options to be four channel
    // Use this for initialization
    void Start()
    {
        //source = GetComponent<AudioSource>();
        winText.text = "Lap 1/3";
        TimerTxt.text = "";
        Music = GetComponent<AudioSource>();
        Debug.Log("kek");
        Music.Play();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        min = (Timer / 60f);
        sec = (Timer % 60f);
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
        if (finish == checkpoint)
        {
            round = finish;
            if(round > 2)
            {
                str = "";
                TimerTxt.text = "Time: " + Mathf.Round(Timer) + " seconds";
                Debug.Log(Timer);
            } else
            {
                str = "Lap " + (round + 1) + "/3";
                TimerTxt.text = "";
            }
            Debug.Log(checkpoint);
            Debug.Log(finish);
        }
        winText.text = str;
    }
}