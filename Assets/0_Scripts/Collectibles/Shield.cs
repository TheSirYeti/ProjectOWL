using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Collectible
{
    public float duration;
    
    public Shield(float value, float speed, float duration) : base(value, speed)
    {
        this.value = value;
        this.speed = speed;
        this.duration = duration;
        collectible = this;
    }
    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.SHIELD);
        EventManager.Trigger("OnShieldCollected", true, value, duration);
    }
}
