using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideExplosion : MonoBehaviour, IAbility
{
    public IAbility next;
    
    private void Start()
    {
        next = new NormalSlide();
    }
    
    public void OnSlideDown()
    {
        SoundManager.instance.PlaySound(SoundID.SLIDE);
        EventManager.Trigger("OnSlideExplosionTriggered");
        Debug.Log("EXPLOSION");
    }
}
