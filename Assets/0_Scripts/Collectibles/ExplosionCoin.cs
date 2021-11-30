using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCoin : Collectible
{
    [SerializeField] float time;
    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.YEAH);
        EventManager.Trigger("OnAbilityCollected", new SlideExplosion(), value, time);
        TurnOff(this);
    }
}
