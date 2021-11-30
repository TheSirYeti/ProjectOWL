using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideSlash : MonoBehaviour, IAbility
{
    IAbility next;

    public void OnSlideDown()
    {
        EventManager.Trigger("OnSlideSlashTriggered");
        Debug.Log("SLASH");
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
