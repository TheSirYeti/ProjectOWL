using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengesScript : MonoBehaviour, IChallengeGenerator
{
    [SerializeField] private float distanceToBeat;
    [SerializeField] private float scoreToBeat;

    private void Start()
    {
        CreateChallenges();
    }

    void CreateChallenges()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            BuildScoreChallenge();
        }
        else
        {
            scoreToBeat = 1000f;
        }
        PlayerPrefs.SetFloat("ScoreToBeat", scoreToBeat);

        if (PlayerPrefs.HasKey("HighDistance"))
        {
            BuildDistanceChallenge();
        }
        else
        {
            distanceToBeat = 200f;
        }
        PlayerPrefs.SetFloat("DistanceToBeat", distanceToBeat);
        EventManager.Trigger("OnChallengeGenerated", scoreToBeat, distanceToBeat);
    }

    public void BuildScoreChallenge()
    {
        scoreToBeat = (Mathf.Round(PlayerPrefs.GetFloat("HighScore") / 1000) * 1000) + 1000;
    }

    public void BuildDistanceChallenge()
    {
        distanceToBeat = (Mathf.Round(PlayerPrefs.GetFloat("HighDistance") / 100) * 100) + 100;
    }
}
