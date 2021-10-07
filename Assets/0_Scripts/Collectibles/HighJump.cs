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
        EventManager.Trigger("UpdateScore", _value);
        StartCoroutine(StartHighJump());
    }

    IEnumerator StartHighJump()
    {
        EventManager.Trigger("EnableHighJump", jumpValue, duration);
        yield return new WaitForSeconds(duration);
        EventManager.Trigger("ResetHighJump");
    }
}
