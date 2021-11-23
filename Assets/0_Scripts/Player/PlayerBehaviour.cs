using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private bool shield;

    private void Start()
    {
        EventManager.Subscribe("OnObstacleCollision", SetLives);
        EventManager.Subscribe("OnShieldCollected", SetShield);
        EventManager.Subscribe("OnShieldOver", SetShield);
        EventManager.Subscribe("OnExtraLifeCollected", SetLives);
    }

    public void SetLives(object[] parameters)
    {
        if ((!shield || (float)parameters[0] > 0) && hp > 0)
        {
            hp += (float)parameters[0];

            if (hp <= 0)
            {
                AdService.instance.Active(AdService.AdsType.Interstitial_Android, SecondChance, Died);
            }
            else if (hp >= 5)
            {
                hp = 5;
            }

            if ((float)parameters[0] < 0)
            {
                SoundManager.instance.PlaySound(SoundID.HURT);
            }
            EventManager.Trigger("OnHPChange", hp);
        }
    }

    public void SetShield(object[] parameters)
    {
        shield = (bool)parameters[0];
    }

    public void Died()
    {
        hp = 0;
        EventManager.Trigger("OnPlayerDeath", "Die");
    }

    public void SecondChance()
    {
        hp = 3f;
        EventManager.Trigger("OnHPChange", hp);
    }
}
