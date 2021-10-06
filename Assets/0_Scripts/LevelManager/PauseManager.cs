using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseIcon;
    public GameObject playIcon;

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        pauseIcon.SetActive(false);
        playIcon.SetActive(true);
        EventManager.Trigger("PauseGame");
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        pauseIcon.SetActive(true);
        playIcon.SetActive(false);
        EventManager.Trigger("ResumeGame");
    }
}
