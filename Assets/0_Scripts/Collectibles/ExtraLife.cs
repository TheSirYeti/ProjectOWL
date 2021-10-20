using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class ExtraLife : Collectible
{
    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.EXTRA_LIFE);
        EventManager.Trigger("OnExtraLifeCollected", 1f, value);
    }

}
