using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashCoin : Collectible
{
    [SerializeField] float time;
    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.YEAH);
        EventManager.Trigger("OnAbilityCollected", new SlideSlash(), value, time);
        TurnOff(this);
    }
}
