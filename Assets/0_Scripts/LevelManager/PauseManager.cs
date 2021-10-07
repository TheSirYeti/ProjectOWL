using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumeButton;

    private void Awake()
    {
        EventManager.Subscribe("EndGame", DisablePause);
    }

    private void Start()
    {
        EventManager.Trigger("SetPauseChallengeUI", PlayerPrefs.GetFloat("ScoreToBeat"), PlayerPrefs.GetFloat("DistanceToBeat"));
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        EventManager.Trigger("SetPauseChallengeUI", PlayerPrefs.GetFloat("ScoreToBeat"), PlayerPrefs.GetFloat("DistanceToBeat"));
        EventManager.Trigger("PauseGame");
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        EventManager.Trigger("ResumeGame");
    }

    public void DisablePause(object[] parameters)
    {
        pauseButton.SetActive(false);
        resumeButton.SetActive(false);
        pausePanel.SetActive(true);
    }
}
