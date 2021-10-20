using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;

    private void Awake()
    {
        EventManager.Subscribe("OnExtraLifeCollected", AddScore);
        EventManager.Subscribe("OnCoinCollected", AddScore);
        EventManager.Subscribe("OnHighJumpCollected", AddScore);
        EventManager.Subscribe("OnShieldCollected", AddScore);
        EventManager.Subscribe("OnEndGame", SaveScore);
    }

    void AddScore(object[] parameters)
    {
        score += (int)parameters[1];
        EventManager.Trigger("OnScoreChange", score);
    }

    void SaveScore(object[] parameters)
    {
        if(PlayerPrefs.GetFloat("HighScore") < score)
            PlayerPrefs.SetFloat("HighScore", score);
    }
}
