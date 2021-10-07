using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] Transform originalPanelPosition;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumeButton;

    private void Awake()
    {
        EventManager.Subscribe("EndGame", DisablePause);
    }

    private void Start()
    {
        EventManager.Trigger("SetPauseChallengeUI", PlayerPrefs.GetFloat("ScoreToBeat"), PlayerPrefs.GetFloat("DistanceToBeat"));
        originalPanelPosition.position = pausePanel.transform.position;
        pausePanel.transform.position = new Vector2(-999f, -999f);
    }

    public void PauseGame()
    {
        pausePanel.transform.position = originalPanelPosition.position;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        EventManager.Trigger("SetPauseChallengeUI", PlayerPrefs.GetFloat("ScoreToBeat"), PlayerPrefs.GetFloat("DistanceToBeat"));
        EventManager.Trigger("PauseGame");
    }

    public void ResumeGame()
    {
        pausePanel.transform.position = new Vector2(-999f, -999f);
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        EventManager.Trigger("ResumeGame");
    }

    public void DisablePause(object[] parameters)
    {
        pausePanel.transform.position = originalPanelPosition.position;
        resumeButton.SetActive(false);
        pausePanel.SetActive(true);
    }
}
