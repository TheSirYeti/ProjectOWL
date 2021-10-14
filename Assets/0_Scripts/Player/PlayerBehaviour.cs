using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private bool shield;

    public void SetLives(float value)
    {
        if ((!shield || value > 0) && hp > 0)
        {
            hp += value;

            if (hp <= 0)
            {
                hp = 0;
                EventManager.Trigger("OnPlayerDeath");
            }
            else if (hp >= 5)
            {
                hp = 5;
            }

            if (value < 0)
            {
                SoundManager.instance.PlaySound(SoundID.HURT);
            }
            EventManager.Trigger("OnHPChange", hp);
        }
    }

    public void SetShield(bool state)
    {
        shield = state;
    }

}
