using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengesScript : MonoBehaviour
{
    [SerializeField] private float distanceToBeat;
    [SerializeField] private float scoreToBeat;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            scoreToBeat = (Mathf.Round(PlayerPrefs.GetFloat("HighScore") / 1000) * 1000) + 1000;
        }
        else
        {
            scoreToBeat = 1000f;
        }
        PlayerPrefs.SetFloat("ScoreToBeat", scoreToBeat);

        if (PlayerPrefs.HasKey("HighDistance"))
        {
            distanceToBeat = (Mathf.Round(PlayerPrefs.GetFloat("HighDistance") / 100) * 100) + 100;
        }
        else
        {
            distanceToBeat = 200f;
        }
        PlayerPrefs.SetFloat("DistanceToBeat", distanceToBeat);
        EventManager.Trigger("SetChallengeUI", scoreToBeat, distanceToBeat);
    }

    
    
    
    
}
