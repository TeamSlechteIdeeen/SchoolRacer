using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGlass : MonoBehaviour {
    public GameObject glass;
    public GameObject player;
    public bool GlassLock = false;

    private float timer;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCillisionEnter(Collision col)
    {
        if (col.gameObject.name == "PlayerTrigger")
        {
            //TempLock();
            //glass.GetComponent<ThrowPint>().destroyTheGlass = true;
            Debug.Log("BLITZKRIEG MIT EINEM PINT BIER!");
            
        }
    }

    void TempLock()
    {
        Debug.Log("MAG NIE");
        timer += Time.deltaTime;
        GlassLock = true;
        if(timer > 1.5f)
        {
            GlassLock = false;
        }
    }
}
