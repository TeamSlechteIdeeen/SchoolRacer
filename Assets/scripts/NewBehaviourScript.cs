using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements; // Using the Unity Ads namespace.

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] TrackList;
    public int currentTrack = 0;
    public int ResetAfterTrack = 0;
    GameObject Track;

    private bool CountTimer = true;
    public float Lap = 1f;
    public float AmountOfLaps = 3f;
    public AudioSource Music;
    public GameObject player;
    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;
    public GameObject npc4;
    public GameObject koos;
    public int MaxSections;
    public int TotalHealth = 100;
    public int HealthDropAmount = 10;
    public bool HealthDrop;

    public int trackCounterTotal = 0;
    private int trackCounter = 0;
    public Text winText;
    public Text TimerTxt;
    public Text CountdownTxt;
    public Text RankTxt;
    public Text HealthText;
    public bool ActivatePointSystem;
    //public AudioClip yay;
    //private AudioSource source;

    public float Timer = 0f;
    public float round = -2.0f;
    private int finish = -1;
    private int checkpoint = 0;
    //private int TimeRnd = 0;
    //private float countdown = 0f;
    //private float min = 0;
    //private float sec = 0;
    private bool runshit;
    private float PlayerTrackCounter;
    private float NPC1TrackCounter;
    private float NPC2TrackCounter;
    private float NPC3TrackCounter;
    private float NPC4TrackCounter;
    private float PlayerPos = 0.0f;
    private bool checkround;
    private bool AdShown;

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
        checkround = true;
        MaxSections = this.TrackList.Length;
        //source = GetComponent<AudioSource>();
        winText.text = "Lap 1/3";
        TimerTxt.text = "";
        CountdownTxt.text = "";
        Music = GetComponent<AudioSource>();
        Debug.Log("kek");
        Music.Play();
        runshit = true;
        HealthText.text = "ur health is 100% m8";
        //lock the controls of the players and NPC's
        player.GetComponent<UnityUIController>().ready = false;
        npc1.GetComponent<Patrol>().ready = false;
        npc2.GetComponent<Patrol>().ready = false;
        npc3.GetComponent<Patrol>().ready = false;
        npc4.GetComponent<Patrol>().ready = false;
        koos.GetComponent<Patrol2>().ready = false;
        koos.GetComponent<VillainSoundFX>().start = false;
        AdShown = false;
    }

    void Update()
    {
        if (HealthDrop)
        {
            if (TotalHealth > 0)
            {
                TotalHealth = TotalHealth - HealthDropAmount;
                HealthText.text = "ur health is " + TotalHealth + "% m8";
            }
            else
            {
                HealthText.text = "ur ded";
            }
            HealthDrop = false;
        }
        if (CountTimer)
        {
            Timer += Time.deltaTime;
        }

        //might be useful to calculate minutes and seconds. not used right now
        //min = (Timer / 60f);
        //sec = (Timer % 60f);

        if (runshit == true)
        {
            if (Timer > 3 || Timer < 10)
            {
                //remove countdown text
                CountdownTxt.text = "";

                //unlock the controls
                player.GetComponent<UnityUIController>().ready = true;
                npc1.GetComponent<Patrol>().ready = true;
                npc2.GetComponent<Patrol>().ready = true;
                npc3.GetComponent<Patrol>().ready = true;
                npc4.GetComponent<Patrol>().ready = true;
            }
            if (Timer < 4)
            {
                if (Timer < 4)
                {
                    //because computers are austistic twats, tell it to lock the controls AGAIN!
                    CountdownTxt.text = "" + (4 - Mathf.Round(Timer));
                    player.GetComponent<UnityUIController>().ready = false;
                    npc1.GetComponent<Patrol>().ready = false;
                    npc2.GetComponent<Patrol>().ready = false;
                    npc3.GetComponent<Patrol>().ready = false;
                    npc4.GetComponent<Patrol>().ready = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (currentTrack == ResetAfterTrack)
        {
            //set the checkround boolean to true, to prove the whole track has been done
            checkround = true;
            currentTrack = 1;

        }
        if (col.gameObject.name == "finish" && checkround == true)
        {
            round++;
            Debug.Log("the new round number is " + round);
            checkround = false;
        }

        if (col.gameObject.name == "col" + (currentTrack + 1))
        {
            Debug.Log("BOOP! on col" + (currentTrack + 1));
            trackCounterTotal++;
            currentTrack++;
            PlayerTrackCounter++;
            NPC1TrackCounter = npc1.GetComponent<NPCLapCounter>().trackCounterTotal;
            NPC2TrackCounter = npc2.GetComponent<NPCLapCounter>().trackCounterTotal;
            NPC3TrackCounter = npc3.GetComponent<NPCLapCounter>().trackCounterTotal;
            NPC4TrackCounter = npc4.GetComponent<NPCLapCounter>().trackCounterTotal;
            PlayerPos = 5;
            if (PlayerTrackCounter > NPC1TrackCounter)
            {
                PlayerPos = PlayerPos - 0.5f;
            }
            else
            {
                PlayerPos = PlayerPos + 0.5f;
            }
            if (PlayerTrackCounter > NPC2TrackCounter)
            {
                PlayerPos = PlayerPos - 0.5f;
            }
            else
            {
                PlayerPos = PlayerPos + 0.5f;
            }
            if (PlayerTrackCounter > NPC3TrackCounter)
            {
                PlayerPos = PlayerPos - 0.5f;
            }
            else
            {
                PlayerPos = PlayerPos + 0.5f;
            }
            if (PlayerTrackCounter > NPC4TrackCounter)
            {
                PlayerPos = PlayerPos - 0.5f;
            }
            else
            {
                PlayerPos = PlayerPos + 0.5f;
            }
            PlayerPos = PlayerPos - 2;
            UpdateStat();
            Debug.Log("player position: " + PlayerPos);
        }
        if (col.gameObject.name == "villainPoint")
        {
            koos.GetComponent<Patrol2>().ready = true;
            koos.GetComponent<VillainSoundFX>().start = true;

        }
        if (round > 2)
        {
            str = "";
            TimerTxt.text = "Time: " + Mathf.Round(Timer) + " seconds";
            CountTimer = false;
            ActivatePointSystem = true;
            runshit = false;
            player.GetComponent<UnityUIController>().ready = false;
            npc1.GetComponent<Patrol>().ready = false;
            npc2.GetComponent<Patrol>().ready = false;
            npc3.GetComponent<Patrol>().ready = false;
            npc4.GetComponent<Patrol>().ready = false;
            if (AdShown == false)
            {
                //StartCoroutine(ShowAdWhenReady());
            }
        }
        else
        {
            ActivatePointSystem = false;
            str = "Lap " + (round + 1) + "/3";
            TimerTxt.text = "";
        }
        winText.text = str;
    }
    void UpdateStat()
    {
        if (PlayerPos == 1)
        {
            RankTxt.text = "1st";
            RankTxt.color = new Color(255, 255, 0, 1);
        }
        if (PlayerPos == 2)
        {
            RankTxt.text = "2nd";
            RankTxt.color = new Color(179, 179, 179, 1);
        }
        if (PlayerPos == 3)
        {
            RankTxt.text = "3rd";
            RankTxt.color = new Color(153, 0, 0, 1);
        }
        if (PlayerPos > 3)
        {
            RankTxt.text = PlayerPos + "th";
            RankTxt.color = new Color(255, 153, 51, 1);
        }
    }
    /*IEnumerator ShowAdWhenReady()
    {
#if !UNITY_ADS // If the Ads service is not enabled...
        if (Advertisement.isSupported)
        { // If runtime platform is supported...
            Advertisement.Initialize(gameId, enableTestMode); // ...initialize.
        }
#endif

        // Wait until Unity Ads is initialized,
        //  and the default ad placement is ready.
        while (!Advertisement.isInitialized || !Advertisement.IsReady())
        {
            yield return new WaitForSeconds(1.0f);
        }

        // Show the default ad placement.
        Advertisement.Show();
        AdShown = true;
    }
}*/
}