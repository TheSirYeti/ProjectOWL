using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashCoin : Collectible
{
    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.YEAH);
        EventManager.Trigger("OnSlashCoinCollected", new SlideSlash(), value);
        TurnOff(this);
    }
}
