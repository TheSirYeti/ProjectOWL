using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideSlash : MonoBehaviour, IAbility
{
    public IAbility next;

    public void OnSlideDown()
    {
        SoundManager.instance.PlaySound(SoundID.SLIDE);
        EventManager.Trigger("OnSlideSlashTriggered");
        Debug.Log("SLASH");
    }
}
