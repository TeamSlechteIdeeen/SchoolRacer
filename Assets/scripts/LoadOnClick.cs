using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

    void Start()
    {
        //Application.LoadLevel("MusicScene");
        //Application.LoadLevel("0");
    }

    public void LoadScene(int level)
    {
        //loadingImage.SetActive(true);
        //Application.UnloadLevel(1);
        Application.LoadLevel(level);
        Application.LoadLevel("MusicScene");
        //SceneManager.LoadScene(level);
    }
}
