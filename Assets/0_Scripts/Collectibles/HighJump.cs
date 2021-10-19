using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJump : Collectible
{
    public float jumpValue;
    public float duration;
    
    public HighJump(float value, float speed, float jumpValue) : base(value, speed)
    {
        this.value = value;
        this.speed = speed;
        this.jumpValue = jumpValue;
        collectible = this;
    }
    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.HIGH_JUMP);
        EventManager.Trigger("OnHighJumpCollected", jumpValue, value, duration);
    }
}
