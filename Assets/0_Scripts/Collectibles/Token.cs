﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class Token : Collectible
{
    public override void OnCollect()
    {
        EventManager.Trigger("OnCoinCollected", value, value);
        SoundManager.instance.PlaySound(SoundID.COIN);
    }
}
