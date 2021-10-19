using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : Collectible
{
    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.EXTRA_LIFE);
        EventManager.Trigger("OnExtraLifeCollected", 1f, value);
    }

}
