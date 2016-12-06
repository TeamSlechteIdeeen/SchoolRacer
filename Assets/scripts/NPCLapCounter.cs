using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPCLapCounter : MonoBehaviour
{
    public GameObject[] TrackList;
    public int currentTrack = 0;
    public int ResetAfterTrack = 0;
    GameObject Track;
    public int trackCounterTotal;

    private int trackCounter = 0;
    //public AudioClip yay;
    //private AudioSource source;

    private int round = 0;

    //public EngineAudioOptions engineSoundStyle = EngineAudioOptions.FourChannel;// Set the default audio options to be four channel
    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (currentTrack < this.TrackList.Length)
        {
            if (Track == null)
                Track = TrackList[currentTrack];
            if (currentTrack == ResetAfterTrack)
            {
                currentTrack = 0;
            }
            else
            {
                currentTrack++;
            }
            if (col.gameObject.name == Track.name)
            {
                Debug.Log("nagged da track with name " + Track.name);
                trackCounter++;
                trackCounterTotal++;
            }
            if (col.gameObject.name != Track.name)
            {
                //Debug.Log(col.gameObject.name + "did not hit " + Track.name);
            }
        }
        if (trackCounter > (this.TrackList.Length - 1))
        {
            round++;
            trackCounter = 1;
            Debug.Log("the new round number is " + round);
        }
    }
}