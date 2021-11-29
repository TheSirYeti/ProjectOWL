using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCoin : Collectible
{
    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.YEAH);
        EventManager.Trigger("OnExplosionCoinCollected", new SlideExplosion(), value);
        TurnOff(this);
    }
}
