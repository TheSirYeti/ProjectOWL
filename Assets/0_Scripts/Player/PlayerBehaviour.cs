using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private bool shield;

    private void Awake()
    {
        EventManager.Subscribe("SetHP", SetLives);
        EventManager.Subscribe("EnableShield", SetShield);
        EventManager.Subscribe("DisableShield", SetShield);
    }

    private void Start()
    {
        EventManager.Trigger("UpdateUIhp", hp);
    }

    public void SetLives(object[] parameters)
    {
        if (!shield || (float) parameters[0] > 0)
        {
            hp += (float)parameters[0];
            if (hp <= 0)
            {
                hp = 0;
                EventManager.Trigger("PlayerDeath");
            }
            else if (hp >= 5)
            {
                hp = 5;
            }
            EventManager.Trigger("UpdateUIhp", hp);
        }
    }

    void SetShield(object[] parameters)
    {
        shield = (bool)parameters[0];
    }

}
