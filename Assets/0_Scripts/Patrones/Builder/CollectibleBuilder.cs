using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CollectibleBuilder : ICollectibleBuilder
{
    public float value;
    public float speed;
    public float duration;
    public float jumpValue;

    public void BuildSpeed(float speed)
    {
        this.speed = speed;
    }

    public void BuildValue(float value)
    {
        this.value = value;
    }

    public void BuildDuration(float duration)
    {
        this.duration = duration;
    }

    public void BuildJumpValue(float jumpValue)
    {
        this.jumpValue = jumpValue;
    }

    public Token BuildCoin()
    {
        return new Token(value, speed);
    }

    public ExtraLife BuildExtraLife()
    {
        return new ExtraLife(value, speed);
    }

    public HighJump BuildHighJump()
    {
        return new HighJump(value, speed, jumpValue);
    }

    public Shield BuildShield()
    {
        return new Shield(value, speed, duration);
    }
}
