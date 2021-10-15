using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJump : Collectible
{
    public int _value;
    public float jumpValue;
    public float duration;
    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.HIGH_JUMP);
        EventManager.Trigger("OnHighJumpCollected", jumpValue, _value, duration);
    }
}
