using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideExplosion : MonoBehaviour, IAbility
{
    IAbility next;

    public void OnSlideDown()
    {
        EventManager.Trigger("OnSlideExplosionTriggered");
        Debug.Log("EXPLOSION");
        next.OnSlideDown();
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
