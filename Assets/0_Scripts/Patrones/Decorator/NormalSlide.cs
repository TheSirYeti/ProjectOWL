using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSlide : MonoBehaviour, IAbility
{
    public IAbility next;

    public void OnSlideDown()
    {
        SoundManager.instance.PlaySound(SoundID.SLIDE);
        Debug.Log("NORMAL");
    }
}
