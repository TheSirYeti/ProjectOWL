using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSlide : MonoBehaviour, IAbility
{
    IAbility next;

    public void OnSlideDown()
    {
        SoundManager.instance.PlaySound(SoundID.SLIDE);
        Debug.Log("NORMAL");
    }
    
    public IAbility GetNext()
    {
        return next;
    }

    public void SetNext(IAbility ability)
    {
        next = ability;
    }
}
