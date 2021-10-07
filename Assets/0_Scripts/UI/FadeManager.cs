using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public Animator animator;

    public void FadeIn()
    {
        animator.Play("FadeIn");
    }
    
    public void FadeOutToMenu()
    {
        animator.Play("fadeOutToMenu");
        Time.timeScale = 1f;
    }
    
    public void FadeOutToGame()
    {
        animator.Play("fadeOutToGame");
        Time.timeScale = 1f;
    }

    public void FadeToLevel(int sceneID)
    {
        EventManager.Trigger("LoadScene", sceneID);
    }
}
