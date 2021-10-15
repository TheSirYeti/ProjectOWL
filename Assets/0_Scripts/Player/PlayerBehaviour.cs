using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private bool shield;

    private void Start()
    {
        EventManager.Subscribe("OnObstacleCollision", SetLives);
        EventManager.Subscribe("OnShieldEnabled", SetShield);
        EventManager.Subscribe("OnShieldEnd", SetShield);
        EventManager.Subscribe("OnExtraLifeCollected", SetLives);
    }

    public void SetLives(object[] parameters)
    {
        if ((!shield || (float)parameters[0] > 0) && hp > 0)
        {
            hp += (float)parameters[0];

            if (hp <= 0)
            {
                hp = 0;
                EventManager.Trigger("OnPlayerDeath");
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

}
