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
        EventManager.Subscribe("OnEndGame", DisablePause);
    }

    private void Start()
    {
        EventManager.Trigger("SetPauseChallengeUI", PlayerPrefs.GetFloat("ScoreToBeat"), PlayerPrefs.GetFloat("DistanceToBeat"));
        originalPanelPosition.position = pausePanel.transform.position;
        pausePanel.transform.position = new Vector2(-999f, -999f);
    }

    //Via button
    public void PauseGame()
    {
        pausePanel.transform.position = originalPanelPosition.position;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        EventManager.Trigger("SetPauseChallengeUI", PlayerPrefs.GetFloat("ScoreToBeat"), PlayerPrefs.GetFloat("DistanceToBeat"));
        SoundManager.instance.StopAllSounds();
        EventManager.Trigger("OnPauseGame");
    }

    //Via button
    public void ResumeGame()
    {
        pausePanel.transform.position = new Vector2(-999f, -999f);
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        SoundManager.instance.ResumeAllSounds();
        EventManager.Trigger("OnResumeGame");
    }

    public void DisablePause(object[] parameters)
    {
        pausePanel.transform.position = originalPanelPosition.position;
        resumeButton.SetActive(false);
        pauseButton.SetActive(false);
    }
}
