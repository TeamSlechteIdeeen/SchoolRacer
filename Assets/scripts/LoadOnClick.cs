using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

    public void LoadScene(int level)
    {
        //loadingImage.SetActive(true);
        //Application.UnloadLevel(1);
        Application.LoadLevel(level);
        //SceneManager.LoadScene(level);
    }
}
