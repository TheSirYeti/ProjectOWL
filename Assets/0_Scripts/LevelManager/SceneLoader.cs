using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        EventManager.Subscribe("PlayerDied", ReturnToMainMenu);
    }

    public enum SceneID
    {
        MAINMENU,
        MAINLEVEL
    }

    public void LoadScene(int sceneID)
    {
        EventManager.ResetEventDictionary();
        SceneManager.LoadSceneAsync(sceneID);
    }

    public void ReturnToMainMenu(object[] parameters)
    {
        LoadScene((int)parameters[0]);
    }
}
