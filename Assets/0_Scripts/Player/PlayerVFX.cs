﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class PlayerVFX : MonoBehaviour, ISubscriber
{
    [SerializeField] private List<GameObject> vfx;
    [SerializeField] private GameObject shieldFX;
    [SerializeField] private Observer _playerObserver;

    private void Start()
    {
        _playerObserver.Subscribe(this);
        
        EventManager.Subscribe("OnShieldCollected", SetShieldVFX);
        EventManager.Subscribe("OnShieldOver", SetShieldVFX);
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
        
        if (eventID == "HighJumpVFX")
        {
            vfx[(int) ParticleID.HIGHJUMP].SetActive(true);
        }

        if (eventID == "DisableVFX")
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
