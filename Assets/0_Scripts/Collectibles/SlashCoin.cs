using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class SlashCoin : Collectible
{
    [SerializeField] float time;
    public override void OnCollect()
    {
        SoundManager.instance.PlaySound(SoundID.YEAH);
        EventManager.Trigger("OnAbilityCollected", new SlideSlash(), value, time);
        TurnOff(this);
    }
}
