using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class Shield : Collectible
{
    public float duration;
    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.SHIELD);
        EventManager.Trigger("OnShieldCollected", true, value, duration);
    }
}
