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
    
    public void FadeOut()
    {
        animator.Play("fadeOut");
    }

    public void FadeToLevel(int sceneID)
    {
        EventManager.Trigger("LoadScene", sceneID);
    }
}
