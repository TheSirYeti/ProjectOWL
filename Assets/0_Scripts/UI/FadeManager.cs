using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
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
    
    public void FadeOutToBoss()
    {
        animator.Play("fadeOutToBoss");
        Time.timeScale = 1f;
    }

    public void FadeToLevel(int sceneID)
    {
        EventManager.Trigger("OnFadeOutOver", sceneID);
    }
}
