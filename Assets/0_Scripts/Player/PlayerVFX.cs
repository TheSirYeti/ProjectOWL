using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class PlayerVFX : MonoBehaviour, ISubscriber
{
    [SerializeField] private List<GameObject> vfx;
    [SerializeField] private Observer _playerObserver;

    private void Start()
    {
        _playerObserver.Subscribe(this);
        
        EventManager.Subscribe("OnShieldCollected", SetShieldVFX);
        EventManager.Subscribe("OnShieldOver", SetShieldVFX);
        EventManager.Subscribe("OnObstacleCollision", StartHurtVFX);
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

        if (eventID == "Die")
        {
            foreach (GameObject g in vfx)
            {
                g.gameObject.SetActive(false);
            }
        }
    }

    public void SetShieldVFX(object[] parameters)
    {
        vfx[(int) ParticleID.SHIELD].SetActive((bool)parameters[0]);
    }

    public void StartHurtVFX(object[] parameters)
    {
        StopCoroutine(ToggleHurtVFX());
        StartCoroutine(ToggleHurtVFX());
    }

    IEnumerator ToggleHurtVFX()
    {
        vfx[(int) ParticleID.AIR].SetActive(false);
        vfx[(int) ParticleID.HURT].SetActive(true);
        yield return new WaitForSeconds(1f);
        vfx[(int) ParticleID.AIR].SetActive(true);
        vfx[(int) ParticleID.HURT].SetActive(false);
    }
    
    public enum ParticleID
    {
        AIR,
        HIGHJUMP,
        SHIELD,
        HURT
    }
    
}
