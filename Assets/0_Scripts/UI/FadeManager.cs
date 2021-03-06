using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class FadeManager : MonoBehaviour
{
    public Animator animator;
    public GameObject loading;
    
    public void FadeIn()
    {
        animator.Play("FadeIn");
        loading.SetActive(false);
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
    
    public void FadeOutToBoss()
    {
        animator.Play("fadeOutToBoss");
        Time.timeScale = 1f;
    }

    public void FadeOutToMinigame()
    {
        animator.Play("fadeOutToMinigame");
        Time.timeScale = 1f;
    }
    
    public void FadeToLevel(int sceneID)
    {
        EventManager.Trigger("OnFadeOutOver", sceneID);
    }

    public void EnableLoading()
    {
        loading.SetActive(true);
    }
}
