using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject player;
    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;
    public GameObject npc4;
    public GameObject koos;
    public GameObject Menu;

    // Use this for initialization
    void Start () {
        Menu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauseButton(bool pause)
    {
        if(pause == true)
        {
            Debug.Log("shit me not");
            Menu.SetActive(true);
            player.GetComponent<UnityUIController>().pause = true;
            npc1.GetComponent<Patrol>().pause = true;
            npc2.GetComponent<Patrol>().pause = true;
            npc3.GetComponent<Patrol>().pause = true;
            npc4.GetComponent<Patrol>().pause = true;
            koos.GetComponent<Patrol2>().pause = true;
        }
        else
        {
            Menu.SetActive(false);
            player.GetComponent<UnityUIController>().pause = false;
            npc1.GetComponent<Patrol>().pause = false;
            npc2.GetComponent<Patrol>().pause = false;
            npc3.GetComponent<Patrol>().pause = false;
            npc4.GetComponent<Patrol>().pause = false;
            koos.GetComponent<Patrol2>().pause = false;
        }
    }
    public void PauseClose(bool close)
    {
        if (close == true)
        {
            Menu.SetActive(false);
            player.GetComponent<UnityUIController>().ready = true;
            npc1.GetComponent<Patrol>().ready = true;
            npc2.GetComponent<Patrol>().ready = true;
            npc3.GetComponent<Patrol>().ready = true;
            npc4.GetComponent<Patrol>().ready = true;
            koos.GetComponent<Patrol2>().ready = true;
        }
    }
}
