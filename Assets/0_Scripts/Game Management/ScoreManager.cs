using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class ScoreManager : MonoBehaviour, IValueRecorder
{
    [SerializeField] private int score;

    private void Awake()
    {
        EventManager.Subscribe("OnExtraLifeCollected", AddValue);
        EventManager.Subscribe("OnCoinCollected", AddValue);
        EventManager.Subscribe("OnHighJumpCollected", AddValue);
        EventManager.Subscribe("OnShieldCollected", AddValue);
        EventManager.Subscribe("OnSlashCoinCollected", AddValue);
        EventManager.Subscribe("OnExplosionCoinCollected", AddValue);
        EventManager.Subscribe("OnEndGame", SaveValue);
    }

    public void AddValue(object[] parameters)
    {
        score += (int)parameters[1];
        EventManager.Trigger("OnScoreChange", score);
    }

    public void SaveValue(object[] parameters)
    {
        if(PlayerPrefs.GetFloat("HighScore") < score)
            PlayerPrefs.SetFloat("HighScore", score);
    }
}
