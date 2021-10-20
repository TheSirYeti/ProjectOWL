using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
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
