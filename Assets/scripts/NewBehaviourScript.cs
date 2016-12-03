using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    public float Lap = 1f;
    public float AmountOfLaps = 3f;
    public AudioSource Music;
    public GameObject player;
    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;
    public GameObject npc4;
    public GameObject koos;


    public Text winText;
    public Text TimerTxt;
    public Text CountdownTxt;
    //public AudioClip yay;
    //private AudioSource source;

    private float Timer = 0f;
    private int round = 0;
    private int finish = -1;
    private int checkpoint = 0;
    private int TimeRnd = 0;
    private float countdown = 0f;
    private float min = 0;
    private float sec = 0;
    private bool runshit;

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
        CountdownTxt.text = "";
        Music = GetComponent<AudioSource>();
        Debug.Log("kek");
        Music.Play();
        runshit = true;

        player.GetComponent<test>().ready = false;
        npc1.GetComponent<Patrol>().ready = false;
        npc2.GetComponent<Patrol>().ready = false;
        npc3.GetComponent<Patrol>().ready = false;
        npc4.GetComponent<Patrol>().ready = false;
        koos.GetComponent<Patrol2>().ready = false;


        // accesses the bool named "isOnFire" and changed it's value.
        //boolBoy.ready = false;
    }

    void Update()
    {
        Timer += Time.deltaTime;
        min = (Timer / 60f);
        sec = (Timer % 60f);

        if (runshit == true)
        {
            if (Timer > 3 || Timer < 10)
            {
                CountdownTxt.text = "";
                player.GetComponent<test>().ready = true;
                npc1.GetComponent<Patrol>().ready = true;
                npc2.GetComponent<Patrol>().ready = true;
                npc3.GetComponent<Patrol>().ready = true;
                npc4.GetComponent<Patrol>().ready = true;
            }
            if (Timer < 4)
            {
                if (Timer < 4)
                {
                    CountdownTxt.text = "" + (4 - Mathf.Round(Timer));
                    player.GetComponent<test>().ready = false;
                    npc1.GetComponent<Patrol>().ready = false;
                    npc2.GetComponent<Patrol>().ready = false;
                    npc3.GetComponent<Patrol>().ready = false;
                    npc4.GetComponent<Patrol>().ready = false;
                    Debug.Log("nope");
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "finish")
        {
            //Debug.Log("booped da finish");
            finish++;
        }
        if (col.gameObject.name == "checkpoint1")
        {
            //Debug.Log("booped da shagpoint");
            checkpoint++;
        }
        if (col.gameObject.name == "villainPoint")
        {
            //Debug.Log("booped da shagpoint");
            koos.GetComponent<Patrol2>().ready = true;

        }
        if (finish == checkpoint)
        {
            round = finish;
            if(round > 2)
            {
                str = "";
                TimerTxt.text = "Time: " + Mathf.Round(min) + " seconds";
                runshit = false;
                player.GetComponent<test>().ready = false;
                npc1.GetComponent<Patrol>().ready = false;
                npc2.GetComponent<Patrol>().ready = false;
                npc3.GetComponent<Patrol>().ready = false;
                npc4.GetComponent<Patrol>().ready = false;
                //TimerTxt.text = "Time: " + Mathf.Round(Timer) + " seconds";
                //Debug.Log(Timer);
            } else
            {
                str = "Lap " + (round + 1) + "/3";
                TimerTxt.text = "";
            }
            //Debug.Log(checkpoint);
            //Debug.Log(finish);
        }
        winText.text = str;
    }
}