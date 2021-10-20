using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
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
        originalPanelPosition.position = pausePanel.transform.position;
        pausePanel.transform.position = new Vector2(-999f, -999f);
    }

    //Via button
    public void PauseGame()
    {
        pausePanel.transform.position = originalPanelPosition.position;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
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
