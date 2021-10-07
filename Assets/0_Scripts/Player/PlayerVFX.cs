﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFX : MonoBehaviour, ISubscriber
{
    [SerializeField] private List<GameObject> vfx;
    [SerializeField] private GameObject shieldFX;
    [SerializeField] private PlayerObserver _playerObserver;

    private void Start()
    {
        _playerObserver.Subscribe(this);
        
        EventManager.Subscribe("EnableShield", SetShieldVFX);
        EventManager.Subscribe("DisableShield", SetShieldVFX);
    }

    public void OnNotify(string eventID)
    {
        if (eventID == "ResetVFX")
        {
            foreach (GameObject g in vfx)
            {
                if(g.activeSelf)
                    g.SetActive(false);
            }
            vfx[(int) ParticleID.AIR].SetActive(true);
        }
        
        if (eventID == "HighJump")
        {
            vfx[(int) ParticleID.HIGHJUMP].SetActive(true);
        }

        if (eventID == "Die")
        {
            foreach (GameObject g in vfx)
            {
                g.SetActive(false);
            }
        }
    }

    public void SetShieldVFX(object[] parameters)
    {
        shieldFX.SetActive((bool)parameters[0]);
    }

    public enum ParticleID
    {
        AIR,
        HIGHJUMP
    }
    
}
