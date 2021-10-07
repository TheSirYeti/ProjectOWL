using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;

    private void Awake()
    {
        EventManager.Subscribe("UpdateScore", AddScore);
        EventManager.Subscribe("EndGame", SaveScore);
    }

    void AddScore(object[] parameters)
    {
        score += (int)parameters[0];
        EventManager.Trigger("UpdateUIScore", score);
    }

    void SaveScore(object[] parameters)
    {
        if(PlayerPrefs.GetFloat("HighScore") < score)
            PlayerPrefs.SetFloat("HighScore", score);
        UpdateChallenges();
    }
    
    
    public void UpdateChallenges()
    {
        if (score > PlayerPrefs.GetFloat("ScoreToBeat"))
        {
            EventManager.Trigger("SetScorePauseCheck");
        }
    }
}
