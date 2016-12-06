using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPCLapCounter : MonoBehaviour
{
    public int currentTrack = 0;
    public int ResetAfterTrack = 0;
    GameObject Track;
    public int trackCounterTotal;

    private int trackCounter = 0;
    //public AudioClip yay;
    //private AudioSource source;

    private int round = 0;

    private int randomvar;

    //public EngineAudioOptions engineSoundStyle = EngineAudioOptions.FourChannel;// Set the default audio options to be four channel
    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        //for (currentTrack = 0; currentTrack < this.TrackList.Length; randomvar++)
        //{
            if (currentTrack == ResetAfterTrack)
            {
                currentTrack = 0;
            }

            if (col.gameObject.name == "col" + (currentTrack + 1))
            {
                //Debug.Log("did some stuff to ur mom with an " + Track.name);
                //Debug.Log("got hit on the head with an " + col.gameObject.name);
                currentTrack++;
                trackCounter++;
                trackCounterTotal++;
            }
            /*if (trackCounter > (this.TrackList.Length - 1))
            {
                round++;
                trackCounter = 1;
                Debug.Log("the new round number is " + round);
            }*/
        //}
    }
}