using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJump : Collectible
{
    public float jumpValue;
    public float duration;
    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.HIGH_JUMP);
        EventManager.Trigger("OnHighJumpCollected", jumpValue, value, duration);
    }
}
