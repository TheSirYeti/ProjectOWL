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
    }

    void AddScore(object[] parameters)
    {
        score += (int)parameters[0];
        EventManager.Trigger("UpdateUIScore", score);
    }
}
