using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public static SkinManager instance;

    public List<bool> skinStatus;

    public int currentSkin;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CheckSkinStatus();
    }

    public void CheckSkinStatus()
    {
        if (PlayerPrefs.HasKey("BeatBoss") && PlayerPrefs.GetInt("BeatBoss") == 1)
        {
            skinStatus[1] = true;
        }
        
        if (PlayerPrefs.HasKey("HighestTally") && PlayerPrefs.GetInt("HighestTally") == 10)
        {
            skinStatus[2] = true;
        }

        if (PlayerPrefs.HasKey("HighDistance") && PlayerPrefs.GetFloat("HighDistance") > 1000)
        {
            skinStatus[3] = true;
        }
    }
}
