using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        EventManager.Subscribe("LoadScene", LoadScene);
    }

    public void LoadScene(object[] parameters)
    {
        EventManager.ResetEventDictionary();
        SceneManager.LoadSceneAsync((int)parameters[0]);
    }
}
