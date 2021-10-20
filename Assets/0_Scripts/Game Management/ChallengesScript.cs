using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class ChallengesScript : MonoBehaviour, IChallengeGenerator
{
    [SerializeField] private float distanceChallenge;
    [SerializeField] private float scoreChallenge;

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
            scoreChallenge = 1000f;
        }
        PlayerPrefs.SetFloat("ScoreToBeat", scoreChallenge);

        if (PlayerPrefs.HasKey("HighDistance"))
        {
            BuildDistanceChallenge();
        }
        else
        {
            distanceChallenge = 200f;
        }
        PlayerPrefs.SetFloat("DistanceToBeat", distanceChallenge);
        EventManager.Trigger("OnChallengeGenerated", scoreChallenge, distanceChallenge);
    }

    public void BuildScoreChallenge()
    {
        scoreChallenge = (Mathf.Round(PlayerPrefs.GetFloat("HighScore") / 1000) * 1000) + 1000;
    }

    public void BuildDistanceChallenge()
    {
        distanceChallenge = (Mathf.Round(PlayerPrefs.GetFloat("HighDistance") / 100) * 100) + 100;
    }
}
