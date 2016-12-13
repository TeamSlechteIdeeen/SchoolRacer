using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagMove : MonoBehaviour {
    public SpriteRenderer flag1Top;
    public SpriteRenderer flag1Mid;
    public SpriteRenderer flag1Low;
    public SpriteRenderer flag2Top;
    public SpriteRenderer flag2Mid;
    public SpriteRenderer flag2Low;

    private float timer;
    // Use this for initialization
    void Start () {
        flag1Top = GetComponent<SpriteRenderer>();
        flag1Mid = GetComponent<SpriteRenderer>();
        flag1Low = GetComponent<SpriteRenderer>();
        flag2Top = GetComponent<SpriteRenderer>();
        flag2Mid = GetComponent<SpriteRenderer>();
        flag2Low = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer < 1)
        {
            flag1Top.enabled = false;
            flag1Mid.enabled = true;
            flag1Low.enabled = false;
            flag2Top.enabled = false;
            flag2Mid.enabled = true;
            flag2Low.enabled = false;
        }
        if (timer > 1 && timer < 2)
        {
            flag1Top.enabled = false;
            flag1Mid.enabled = true;
            flag1Low.enabled = false;
            flag2Top.enabled = true;
            flag2Mid.enabled = false;
            flag2Low.enabled = false;
        }
        if (timer > 2 && timer < 3)
        {
            flag1Top.enabled = true;
            flag1Mid.enabled = false;
            flag1Low.enabled = false;
            flag2Top.enabled = true;
            flag2Mid.enabled = false;
            flag2Low.enabled = false;
        }
        if (timer > 3 && timer < 4)
        {
            flag1Top.enabled = true;
            flag1Mid.enabled = false;
            flag1Low.enabled = false;
            flag2Top.enabled = false;
            flag2Mid.enabled = true;
            flag2Low.enabled = false;
        }
        if (timer > 4 && timer < 5)
        {
            flag1Top.enabled = false;
            flag1Mid.enabled = true;
            flag1Low.enabled = false;
            flag2Top.enabled = false;
            flag2Mid.enabled = false;
            flag2Low.enabled = true;
        }
        if (timer > 5 && timer < 6)
        {
            flag1Top.enabled = false;
            flag1Mid.enabled = false;
            flag1Low.enabled = true;
            flag2Top.enabled = false;
            flag2Mid.enabled = false;
            flag2Low.enabled = true;
        }
        if (timer > 5 && timer < 6)
        {
            flag1Top.enabled = false;
            flag1Mid.enabled = false;
            flag1Low.enabled = true;
            flag2Top.enabled = false;
            flag2Mid.enabled = true;
            flag2Low.enabled = false;
        }
        if(timer > 6)
        {
            timer = 1.1f;
        }
    }
}
