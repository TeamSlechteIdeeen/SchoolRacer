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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauseButton(bool pause)
    {
        if(pause == true)
        {
            SceneManager.LoadScene("menu", LoadSceneMode.Additive);
            player.GetComponent<UnityUIController>().ready = false;
            npc1.GetComponent<Patrol>().ready = false;
            npc2.GetComponent<Patrol>().ready = false;
            npc3.GetComponent<Patrol>().ready = false;
            npc4.GetComponent<Patrol>().ready = false;
            koos.GetComponent<Patrol2>().ready = false;
        }
    }
    public void PauseClose(bool close)
    {
        if (close == true)
        {
            SceneManager.UnloadSceneAsync("menu");
            player.GetComponent<UnityUIController>().ready = true;
            npc1.GetComponent<Patrol>().ready = true;
            npc2.GetComponent<Patrol>().ready = true;
            npc3.GetComponent<Patrol>().ready = true;
            npc4.GetComponent<Patrol>().ready = true;
            koos.GetComponent<Patrol2>().ready = true;
        }
    }
}
